namespace MainScenes
{
    public class ItemNameDataBese_System 
    {
        public string Search_ItemName(ItemName_Enum itemName_)
        {
            switch (itemName_)
            {
                case ItemName_Enum.RoomKey_1:
                    return "Œ®";
                case ItemName_Enum.RoomKey_3:
                    return "Œ®";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "”š‚Ì‘‚©‚ê‚½†(¶) 01";
                case ItemName_Enum.Password_RightDoor_01:
                    return "”š‚Ì‘‚©‚ê‚½†(‰E) 01";
                case ItemName_Enum.Password_LeftDoor_02:
                    return "”š‚Ì‘‚©‚ê‚½†(¶) 02";
                case ItemName_Enum.Password_RightDoor_02:
                    return "”š‚Ì‘‚©‚ê‚½†(‰E) 02";
                case ItemName_Enum.Password_LeftDoor_03:
                    return "”š‚Ì‘‚©‚ê‚½†(¶) 03";
                default:
                    return "";
            }
        }
    }
}