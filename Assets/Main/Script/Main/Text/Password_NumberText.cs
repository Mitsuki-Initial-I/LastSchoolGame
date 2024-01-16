using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    public class Password_NumberText : MonoBehaviour
    {
        int number = 0;

        const int MINNUMBER = 0;
        const int MAXNUMBER = 9;

        private void TextUpdata()
        {
            this.GetComponent<Text>().text = number.ToString();
        }

        public void TexeNumberUp()
        {
            number++;
            number = number > MAXNUMBER ? MINNUMBER : number;
            TextUpdata();
        }
        public void TexeNumberDown()
        {
            number--;
            number = number < MINNUMBER ? MAXNUMBER : number;
            TextUpdata();
        }
    }
}