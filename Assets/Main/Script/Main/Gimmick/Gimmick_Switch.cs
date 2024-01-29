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
                    Debug.Log("runobject�̓������������̂����s����(true)");
                    switchBool = false;
                }
                else
                {
                    Debug.Log("runobject�̓������������̂����s����(false)");
                    switchBool = true;
                }
            }
            else
            {
                if (!switchBool)
                {
                    Debug.Log("runobject�̓������������̂����s����(once)");
                    switchBool = true;
                }
            }
        }
    }
}
