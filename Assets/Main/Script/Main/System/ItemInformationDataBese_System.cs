using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class ItemInformationDataBese_System
    {
        public string Search_ItemInformation(ItemName_Enum itemName_)
        {
            switch (itemName_)
            {
                case ItemName_Enum.RoomKey_1:
                    return "鍵。1号室と書かれている";
                case ItemName_Enum.RoomKey_3:
                    return "鍵。3号室と書かれている";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "数字の書かれた紙(左) 302と書かれている";
                case ItemName_Enum.Password_RightDoor_01:
                    return "数字の書かれた紙(右) 101と書かれている";
                case ItemName_Enum.Password_LeftDoor_02:
                    return "数字の書かれた紙(左) 406と書かれている";
                case ItemName_Enum.Password_RightDoor_02:
                    return "数字の書かれた紙(右) 013と書かれている";
                case ItemName_Enum.Password_LeftDoor_03:
                    return "数字の書かれた紙(左) 297と書かれている";
                default:
                    return "";
            }
        }
    }
}