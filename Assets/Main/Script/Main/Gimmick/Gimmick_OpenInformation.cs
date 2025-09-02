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
            // �v���C���̓��̓��[�h�ύX
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;

            // �I�u�W�F�N�g�̏�ԕύX
            panel.SetActive(true);
            GimmickInformationDataBese_System itemNameDataBese_ = new GimmickInformationDataBese_System();
            var getItemName = itemNameDataBese_.Search_ItemInformation(InformationName_);
            // �e�L�X�g�\��
            var commuTextData = commuTextObject.GetComponent<Communication_MainText>();
            commuTextData.TextReset();
            commuTextData.SetText(CommunicationTextMode_Enum.searchInformation, getItemName);
        }
    }
}