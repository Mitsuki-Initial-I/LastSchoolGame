using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class InputKeyData : MonoBehaviour, IGetKeyData
    {
        public bool CheckActionKey()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        public int InputKey_Horizontal()
        {
            int p = Input.GetKey(KeyCode.D) ? 1 : 0;
            int m = Input.GetKey(KeyCode.A) ? -1 : 0;
            return p + m;
        }

        public int InputKey_Vertical()
        {
            int p = Input.GetKey(KeyCode.W) ? 1 : 0;
            int m = Input.GetKey(KeyCode.S) ? -1 : 0;
            return p + m;
        }
        public bool Check_ClickMouseLeftButton()
        {
            return Input.GetMouseButtonDown(0);
        }
        public bool CheckLeftShiftKeyDown()
        {
            return Input.GetKeyDown(KeyCode.LeftShift);
        }
        public bool CheckLeftShiftKeyUp()
        {
            return Input.GetKeyUp(KeyCode.LeftShift);
        }
        public bool CheckEscKey()
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }
    }
}