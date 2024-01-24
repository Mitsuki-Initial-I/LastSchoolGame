using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    public class Debug_EndDoorLook : MonoBehaviour
    {
        [SerializeField]
        GameObject[] lightColors = new GameObject[2];
        [SerializeField]
        Sprite[] lights;

        private void Start()
        {
            bool r_Flg = StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)GimmickName_Enum.Light_Right];
            bool l_Flg = StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)GimmickName_Enum.Light_Left];
            if (r_Flg)
            {
                lightColors[0].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =lights[0];
            }
            if (l_Flg)
            {
                lightColors[1].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = lights[1];
            }
            if (r_Flg && l_Flg)
            {
                Destroy(this.gameObject);
            }
        }
    }
}