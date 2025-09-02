using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    // TODO: �M�~�b�N�ɂ���ĈقȂ�͂�������C�����鎖(����A�I�u�W�F�N�g�j���݂̂��s���Ă��镔��)
    public class Passwoed_GimmickButton_Delete : ClearGimmickBase
    {
        //GimmickName_Enum gimmickName_;  // �M�~�b�N��
        [SerializeField]
        int password;                   // �ݒ�ς݂̃p�X���[�h
        [SerializeField]
        Text[] passwordTexts;           // ���͂��ꂽ�p�X���[�h
        [SerializeField]
        GameObject[] desGimmickObject;  // �폜����I�u�W�F�N�g 
        [SerializeField]
        GameObject[] gimmickObject;     // �\������I�u�W�F�N�g 
        [SerializeField]
        GameObject[] panel;             // �S�Ẵp�l��

        public override void GimmickClear()
        {
            for (int i = 0; i < desGimmickObject.Length; i++)
            {
                Destroy(desGimmickObject[i]);
            }
            for (int i = 0; i < gimmickObject.Length; i++)
            {
                gimmickObject[i].SetActive(true);
            }
        }

        //private void Start()
        //{
        //    if(StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)gimmickName_] )
        //    {
        //        GimmickClear();
        //    }
        //}

        public void CheckPasswordButton()
        {
            string getPassword = "";
            for (int i = 0; i < passwordTexts.Length; i++)
            {
                getPassword += passwordTexts[i].text;
            }
            if (password != int.Parse(getPassword))
            {
                return;
            }
            else
            {
                for (int i = 0; i < panel.Length; i++)
                {
                    panel[i].SetActive(false); 
                }

                PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
                playerAction.inputMode_=InputMode_Enum.MovePlayerCharacter_Mode;

                GimmickClear();
                StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)gimmickName_] = true;
//                gimmickObject.transform.position += new Vector3(0, -1, 0); 
            }
        }
    }
}