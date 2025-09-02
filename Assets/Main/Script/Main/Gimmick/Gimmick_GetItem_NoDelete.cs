using UnityEngine;

namespace MainScenes
{
    public class Gimmick_GetItem_NoDelete : ClearGimmickBase, IGetGimmick
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject commuTextObject;
        [SerializeField]
        GameObject onObject;
        [SerializeField]
        GameObject desObject;
        [SerializeField]
        ItemName_Enum ItemName_;

        public override void GimmickClear()
        {
            onObject.SetActive(true);
            Destroy(desObject);
        }

        public void UseGimmick()
        {
            // アイテムネーム取得
            ItemNameDataBese_System itemNameDataBese_ = new ItemNameDataBese_System();
            var getItemName = itemNameDataBese_.Search_ItemName(ItemName_);

            // プレイヤの入力モード変更
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;

            // フラグ建設
            StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)gimmickName_] = true;
            StackData.instance.gameObject.GetComponent<MyItemData>().myItem[(int)ItemName_] = true;

            // オブジェクトの状態変更
            panel.SetActive(true);
            onObject.SetActive(true);
            Destroy(desObject);

            // テキスト表示
            var commuTextData = commuTextObject.GetComponent<Communication_MainText>();
            commuTextData.SetText(CommunicationTextMode_Enum.getItem, getItemName);
        }
    }
}