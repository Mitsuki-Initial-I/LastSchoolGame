using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MockScene
{
    public class GimmickSystem_02 : MonoBehaviour
    {
        bool a_b_Flg = true;
        [SerializeField]
        Text buttonText;

        public void OpenPanelProcess()
        {
            string word = "";
            a_b_Flg = !a_b_Flg;

            if (a_b_Flg)
            {
                word = "é ê^";
            }
            else
            {
                word = "1234";
            }

            buttonText.text = word;
        }
    }
}
