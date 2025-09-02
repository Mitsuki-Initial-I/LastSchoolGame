using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class ItemPanel_System : MonoBehaviour
    {
        [SerializeField]
        GameObject[] uiItems;
        [SerializeField]
        GameObject[] itemsObejcts;

        int pageNumber = 0;
        List<int> itemIds = new List<int>();

        const int ITEMDATASMAXNUM = 3;
        
        public void GetItem()
        {
            itemIds.Clear();
            var getItemFlgs = StackData.instance.gameObject.GetComponent<MyItemData>().myItem;
            for (int i = 0; i < getItemFlgs.Length; i++)
            {
                if (getItemFlgs[i])
                {
                    itemIds.Add(i);
                }
            }
            pageNumber = 0;
            ItemDataOpen();
        }
        void ItemDataOpen()
        {
            for (int i = 0; i < ITEMDATASMAXNUM; i++)
            {
                itemsObejcts[i].SetActive(false);
            }

            var openMaxNum = (pageNumber + 1) * ITEMDATASMAXNUM;
            int openNum = openMaxNum switch
            {
                var o when o <= itemIds.Count => ITEMDATASMAXNUM,
                _ => itemIds.Count - pageNumber * ITEMDATASMAXNUM
            };
            var itemInformationDataBese = new ItemInformationDataBese_System();
            for (int i = 0; i < openNum; i++)
            {
                itemsObejcts[i].SetActive(true);

                string getItemDataStr = itemInformationDataBese.Search_ItemInformation((ItemName_Enum)itemIds[i + pageNumber * ITEMDATASMAXNUM]);
                itemsObejcts[i].GetComponent<ItemData_DataText>().SetData(null, getItemDataStr);
            }

            if (pageNumber != 0)
            {
                uiItems[1].SetActive(true);
            }
            else
            {
                uiItems[1].SetActive(false);
            }
            if (itemIds.Count / ITEMDATASMAXNUM != pageNumber && itemIds.Count % ITEMDATASMAXNUM != 0)
            {
                uiItems[2].SetActive(true);
            }
            else
            {
                uiItems[2].SetActive(false);
            }
            if (itemIds.Count == 0)
            {
                uiItems[0].SetActive(true);
            }
            else
            {
                uiItems[0].SetActive(false);
            }
        }

        public void UpButton()
        {
            pageNumber--;
            ItemDataOpen();
        }
        public void DownButton()
        {
            pageNumber++;
            ItemDataOpen();
        }

    }
}