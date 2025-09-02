using UnityEngine;

namespace MainScenes
{
    public class GimmickClearData : MonoBehaviour
    {
        public bool[] gimmickClearNum;

        private void Awake()
        {
            int gimmickCount = System.Enum.GetValues(typeof(GimmickName_Enum)).Length;
            gimmickClearNum = new bool[gimmickCount];
        }
    }
}