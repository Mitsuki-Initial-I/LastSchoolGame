namespace MainScenes
{
    public class ItemNameDataBese_System 
    {
        public string Search_ItemName(ItemName_Enum itemName_)
        {
            switch (itemName_)
            {
                case ItemName_Enum.RoomKey_1:
                    return "1�����̌�";
                case ItemName_Enum.RoomKey_3:
                    return "3�����̌�";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "�����̏����ꂽ�� 01";
                default:
                    return "";
            }
        }
    }
}