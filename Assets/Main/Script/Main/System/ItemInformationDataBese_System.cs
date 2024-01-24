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
                    return "Œ®B1†º‚Æ‘‚©‚ê‚Ä‚¢‚é";
                case ItemName_Enum.RoomKey_3:
                    return "Œ®B3†º‚Æ‘‚©‚ê‚Ä‚¢‚é";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "”š‚Ì‘‚©‚ê‚½†(¶) 302‚Æ‘‚©‚ê‚Ä‚¢‚é";
                case ItemName_Enum.Password_RightDoor_01:
                    return "”š‚Ì‘‚©‚ê‚½†(‰E) 101‚Æ‘‚©‚ê‚Ä‚¢‚é";
                default:
                    return "";
            }
        }
    }
}