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
            Destroy(gameObject);

            // テキスト表示
            var commuTextData = commuTextObject.GetComponent<Communication_MainText>();
            commuTextData.TextReset();
            commuTextData.SetText(CommunicationTextMode_Enum.getItem, getItemName);
        }
    }
}