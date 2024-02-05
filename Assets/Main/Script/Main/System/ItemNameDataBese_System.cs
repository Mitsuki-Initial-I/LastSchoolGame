namespace MainScenes
{
    public class ItemNameDataBese_System 
    {
        public string Search_ItemName(ItemName_Enum itemName_)
        {
            switch (itemName_)
            {
                case ItemName_Enum.RoomKey_1:
                    return "鍵";
                case ItemName_Enum.RoomKey_3:
                    return "鍵";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "数字の書かれた紙(左) 01";
                case ItemName_Enum.Password_RightDoor_01:
                    return "数字の書かれた紙(右) 01";
                case ItemName_Enum.Password_LeftDoor_02:
                    return "数字の書かれた紙(左) 02";
                case ItemName_Enum.Password_RightDoor_02:
                    return "数字の書かれた紙(右) 02";
                case ItemName_Enum.Password_LeftDoor_03:
                    return "数字の書かれた紙(左) 03";
                default:
                    return "";
            }
        }
    }
}