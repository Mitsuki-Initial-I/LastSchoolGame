namespace MainScenes
{
    public class ItemNameDataBese_System 
    {
        public string Search_ItemName(ItemName_Enum itemName_)
        {
            switch (itemName_)
            {
                case ItemName_Enum.RoomKey_1:
                    return "1†º‚ÌŒ®";
                case ItemName_Enum.RoomKey_3:
                    return "3†º‚ÌŒ®";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "”š‚Ì‘‚©‚ê‚½† 01";
                default:
                    return "";
            }
        }
    }
}