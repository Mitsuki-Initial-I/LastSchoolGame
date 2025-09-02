using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Gimmick_GetItem_Password : BaseGimmick
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject commuTextObject;
        [SerializeField]
        string itemName;
        [SerializeField]
        string gimmickName;
        [SerializeField]
        bool isRight;

        private string[] GetEnumNames<T>() where T : Enum
        {
            return Enum.GetNames(typeof(T));
        }
        private void Start()
        {
            string[] enumNames = GetEnumNames<ItemName_Enum>();
            List<int> itemNuns = new List<int>();
            for (int i = 0; i < enumNames.Length; i++)
            {
                if(enumNames[i].Contains(itemName))
                {
                    itemNuns.Add(i);
                }
            }
            bool[] getItemFlgs = StackData.instance.GetComponent<MyItemData>().myItem;
            for (int i = 0; i < itemNuns.Count; i++)
            {
                if (getItemFlgs[itemNuns[i]])
                {
                    itemNuns.Remove(itemNuns[i]);
                    i--;
                }
            }
            int randItemNumber = UnityEngine.Random.Range(0, itemNuns.Count);

            ItemNameDataBese_System itemNameDataBese_ = new ItemNameDataBese_System();
            ItemName_Enum itemName_ = (ItemName_Enum)itemNuns[randItemNumber];
            var getImteName = itemNameDataBese_.Search_ItemName(itemName_);

            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;

            string gimmickNumberStr = enumNames[itemNuns[randItemNumber]].Replace(itemName, "");
            gimmickName = gimmickName + gimmickNumberStr;


//            StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)g]

        }

        public override void UseGimmick()
        {

        }
    }
}