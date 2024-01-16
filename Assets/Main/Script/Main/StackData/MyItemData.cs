using UnityEngine;

namespace MainScenes
{
    public class MyItemData : MonoBehaviour
    {
        public bool[] myItem;
        private void Awake()
        {
            int gimmickCount = System.Enum.GetValues(typeof(ItemName_Enum)).Length;
            myItem = new bool[gimmickCount];
        }
    }
}