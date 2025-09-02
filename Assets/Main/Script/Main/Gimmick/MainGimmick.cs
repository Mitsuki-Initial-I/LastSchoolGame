using UnityEngine;

namespace MainScenes
{
    public class MainGimmick : MonoBehaviour
    {
        [SerializeField]
        ClearGimmickBase[] gimmickObjects;

        private void Start()
        {
            var getData = StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum;
            for (int i = 0; i < gimmickObjects.Length; i++)
            {
                if (getData[(int)gimmickObjects[i].gimmickName_])
                {
                    gimmickObjects[i].GimmickClear();
                }
            }
        }
    }
}