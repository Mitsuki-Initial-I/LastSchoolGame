using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    public class Passwoed_GimmickButton_NoDelete_CrystlBall : ClearGimmickBase
    {
        [SerializeField]
        GameObject[] panels;
        [SerializeField]
        Text[] passwordTexts;           // 入力されたパスワード
        [SerializeField]
        int[] canPws_R;
        [SerializeField]
        int[] canPws_L;
        bool isRight;

        public void SetData(int pwNum, bool isFlg)
        {
            var pwStr = pwNum.ToString();
            if (pwStr == "0")
            {
                passwordTexts[0].text = "0";
                passwordTexts[1].text = "0";
                passwordTexts[2].text = "0";
            }
            else
            {
                for (int i = 0; i < passwordTexts.Length; i++)
                {
                    passwordTexts[i].text = pwStr.Substring(i, 1);
                }
            }
            isRight = isFlg;
        }
        public void CheckPasswordButton()
        {
            string getPassword = "";
            for (int i = 0; i < passwordTexts.Length; i++)
            {
                getPassword += passwordTexts[i].text;
            }
            if (isRight)
            {
                for (int i = 0; i < canPws_R.Length; i++)
                {
                    if (canPws_R[i] == int.Parse(getPassword))
                    {
                        StackData.instance.gameObject.GetComponent<RoomData>().lastDoorNumber_R = int.Parse(getPassword);
                        StackData.instance.gameObject.GetComponent<RoomData>().roomId_R = (RoomId_R_Enum)i+1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < canPws_L.Length; i++)
                {
                    if (canPws_L[i] == int.Parse(getPassword))
                    {
                        StackData.instance.gameObject.GetComponent<RoomData>().lastDoorNumber_L = int.Parse(getPassword);
                        StackData.instance.gameObject.GetComponent<RoomData>().roomId_L = (RoomId_L_Enum)i + 1;
                    }
                }
            }
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].SetActive(false);
            }
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_--;
        }
    }
}