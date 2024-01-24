using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    public class ItemData_DataText : MonoBehaviour
    {
        [SerializeField]
        GameObject[] dataObject;

        public void SetData(Sprite si,string getText)
        {
            dataObject[0].GetComponent<Image>().sprite = si;
            dataObject[1].GetComponent<Text>().text = getText;
        }
    }
}