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
                    Debug.Log("runobjectÇÃìÆÇ©ÇµÇΩÇ¢Ç‡ÇÃÇé¿çsÇ∑ÇÈ(true)");
                    switchBool = false;
                }
                else
                {
                    Debug.Log("runobjectÇÃìÆÇ©ÇµÇΩÇ¢Ç‡ÇÃÇé¿çsÇ∑ÇÈ(false)");
                    switchBool = true;
                }
            }
            else
            {
                if (!switchBool)
                {
                    Debug.Log("runobjectÇÃìÆÇ©ÇµÇΩÇ¢Ç‡ÇÃÇé¿çsÇ∑ÇÈ(once)");
                    switchBool = true;
                }
            }
        }
    }
}
