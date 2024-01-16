namespace MainScenes
{
    public class ItemNameDataBese_System 
    {
        public string Search_ItemName(ItemName_Enum itemName_)
        {
            switch (itemName_)
            {
                case ItemName_Enum.RoomKey_1:
                    return "1号室の鍵";
                case ItemName_Enum.RoomKey_3:
                    return "3号室の鍵";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "数字の書かれた紙 01";
                default:
                    return "";
            }
        }
    }
}