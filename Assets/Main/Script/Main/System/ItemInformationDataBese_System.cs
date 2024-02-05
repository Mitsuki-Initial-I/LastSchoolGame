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
                    return "���B1�����Ə�����Ă���";
                case ItemName_Enum.RoomKey_3:
                    return "���B3�����Ə�����Ă���";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "�����̏����ꂽ��(��) 302�Ə�����Ă���";
                case ItemName_Enum.Password_RightDoor_01:
                    return "�����̏����ꂽ��(�E) 101�Ə�����Ă���";
                case ItemName_Enum.Password_LeftDoor_02:
                    return "�����̏����ꂽ��(��) 406�Ə�����Ă���";
                case ItemName_Enum.Password_RightDoor_02:
                    return "�����̏����ꂽ��(�E) 013�Ə�����Ă���";
                case ItemName_Enum.Password_LeftDoor_03:
                    return "�����̏����ꂽ��(��) 297�Ə�����Ă���";
                default:
                    return "";
            }
        }
    }
}