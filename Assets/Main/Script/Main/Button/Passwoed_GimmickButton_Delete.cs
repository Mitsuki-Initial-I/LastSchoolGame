using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    // TODO: ギミックによって異なるはずだから修正する事(現状、オブジェクト破棄のみを行っている部分)
    public class Passwoed_GimmickButton_Delete : ClearGimmickBase
    {
        //GimmickName_Enum gimmickName_;  // ギミック名
        [SerializeField]
        int password;                   // 設定済みのパスワード
        [SerializeField]
        Text[] passwordTexts;           // 入力されたパスワード
        [SerializeField]
        GameObject[] desGimmickObject;  // 削除するオブジェクト 
        [SerializeField]
        GameObject[] gimmickObject;     // 表示するオブジェクト 
        [SerializeField]
        GameObject[] panel;             // 全てのパネル

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