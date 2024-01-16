using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    public class Debug_EndDoorLook : MonoBehaviour
    {
        [SerializeField]
        GameObject[] lightColors = new GameObject[2];

        private void Start()
        {
            bool r_Flg = StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)GimmickName_Enum.Debug_Right];
            bool l_Flg = StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)GimmickName_Enum.Debug_Left];
            if (r_Flg)
            {
                lightColors[0].GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (l_Flg)
            {
                lightColors[1].GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if (r_Flg && l_Flg)
            {
                Destroy(this.gameObject);
            }
        }
    }
}