using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Gimmick_Switch : BaseGimmick
    { 
        [SerializeField] GameObject[] runObject;
        [SerializeField] bool onceSwitch=false;
        bool switchBool=false;

        public override void UseGimmick()
         {
            if (!onceSwitch)
            {
                if (switchBool)
                {
                    Debug.Log("runobjectの動かしたいものを実行する(true)");
                    switchBool = false;
                }
                else
                {
                    Debug.Log("runobjectの動かしたいものを実行する(false)");
                    switchBool = true;
                }
            }
            else
            {
                if (!switchBool)
                {
                    Debug.Log("runobjectの動かしたいものを実行する(once)");
                    switchBool = true;
                }
            }
        }
    }
}
