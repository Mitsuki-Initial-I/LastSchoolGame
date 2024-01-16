using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MockScene
{
    public class Textword : MonoBehaviour
    {
        int number = 1;

        public void NumberUp()
        {
            number++;
            if (number == 10)
            {
                number = 0;
            }
            Textupdate();
        }
        public void NumberDown()
        {
            number--;
            if (number == -1)
            {
                number = 9;
            }
            Textupdate();
        }
        void Textupdate()
        {
            this.GetComponent<Text>().text = number.ToString();
        }
    }
}
