using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Gimmick_LockDoor : ClearGimmickBase, IGetGimmick
    {
        [SerializeField]
        ItemName_Enum ItemName_;

        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject commuTextObject;

        public override void GimmickClear()
        {
            Destroy(this.gameObject);
        }
        public void UseGimmick()
        {
            // �A�C�e���l�[���擾
            ItemNameDataBese_System itemNameDataBese_ = new ItemNameDataBese_System();
            var getItemName = itemNameDataBese_.Search_ItemName(ItemName_);

            // �v���C���̓��̓��[�h�ύX
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;

            bool getItemFlg = StackData.instance.gameObject.GetComponent<MyItemData>().myItem[(int)ItemName_];

            // �e�L�X�g�\��
            panel.SetActive(true);
            var commuTextData = commuTextObject.GetComponent<Communication_MainText>();
            if (getItemFlg)
            {
                commuTextData.SetText(CommunicationTextMode_Enum.useRoomKey, getItemName);
                Destroy(this.gameObject);
                StackData.instance.gameObject.GetComponent<MyItemData>().myItem[(int)ItemName_] = false;
                StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)gimmickName_] = true;
            }
            else
            {
                commuTextData.TextReset();
                commuTextData.SetText(CommunicationTextMode_Enum.noRoomKey);
            }
        }
    }
}