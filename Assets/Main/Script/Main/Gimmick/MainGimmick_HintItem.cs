using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MainScenes
{
    public class MainGimmick_HintItem : MonoBehaviour
    {
        [SerializeField]
        ClearGimmickBase[] gimmickObjects;

        void Start()
        {
            var getData = StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum;
            for (int i = 0; i < gimmickObjects.Length; i++)
            {
                if (getData[(int)gimmickObjects[i].gimmickName_])
                {
                    gimmickObjects[i].GimmickClear();
                }
            }
            bool[] nonGimmickFlg = new bool[gimmickObjects.Length];
            for (int i = 0; i < gimmickObjects.Length; i++)
            {
                nonGimmickFlg[i] = gimmickObjects[i] != null;
            }
            List<int> getnonGimmickNumList = new List<int>();
            for (int i = 0; i < gimmickObjects.Length; i++)
            {
                if (nonGimmickFlg[i])
                    getnonGimmickNumList.Add(i);
            }
            if (getnonGimmickNumList.Count == 0) return;
            int setNumber = Random.Range(0, getnonGimmickNumList.Count);
            gimmickObjects[getnonGimmickNumList[setNumber]].gameObject.SetActive(true);
            Debug.Log(getnonGimmickNumList[setNumber]);
        }
    }
}