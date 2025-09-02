using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Gimmick_GetItem_Delete : ClearGimmickBase, IGetGimmick
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject commuTextObject;
        [SerializeField]
        ItemName_Enum ItemName_;

        public override void GimmickClear()
        {
            Destroy(gameObject);
        }
        public void UseGimmick()
        {
            // �A�C�e���l�[���擾
            ItemNameDataBese_System itemNameDataBese_ = new ItemNameDataBese_System();
            var getItemName = itemNameDataBese_.Search_ItemName(ItemName_);

            // �v���C���̓��̓��[�h�ύX
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;

            // �t���O����
            StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)gimmickName_] = true;
            StackData.instance.gameObject.GetComponent<MyItemData>().myItem[(int)ItemName_] = true;

            // �I�u�W�F�N�g�̏�ԕύX
            panel.SetActive(true);
            Destroy(gameObject);

            // �e�L�X�g�\��
            var commuTextData = commuTextObject.GetComponent<Communication_MainText>();
            commuTextData.TextReset();
            commuTextData.SetText(CommunicationTextMode_Enum.getItem, getItemName);
        }
    }
}