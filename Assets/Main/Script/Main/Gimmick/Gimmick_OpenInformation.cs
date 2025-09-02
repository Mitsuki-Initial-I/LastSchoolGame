using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Gimmick_OpenInformation : BaseGimmick
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject commuTextObject;
        [SerializeField]
        GimmickInformationName_Enum InformationName_;

        public override void UseGimmick()
        {
            // プレイヤの入力モード変更
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;

            // オブジェクトの状態変更
            panel.SetActive(true);
            GimmickInformationDataBese_System itemNameDataBese_ = new GimmickInformationDataBese_System();
            var getItemName = itemNameDataBese_.Search_ItemInformation(InformationName_);
            // テキスト表示
            var commuTextData = commuTextObject.GetComponent<Communication_MainText>();
            commuTextData.TextReset();
            commuTextData.SetText(CommunicationTextMode_Enum.searchInformation, getItemName);
        }
    }
}