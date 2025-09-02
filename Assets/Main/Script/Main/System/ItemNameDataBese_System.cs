namespace MainScenes
{
    public class ItemNameDataBese_System 
    {
        public string Search_ItemName(ItemName_Enum itemName_)
        {
            switch (itemName_)
            {
                case ItemName_Enum.RoomKey_1:
                    return "��";
                case ItemName_Enum.RoomKey_3:
                    return "��";
                case ItemName_Enum.Password_LeftDoor_01:
                    return "�����̏����ꂽ��(��) 01";
                case ItemName_Enum.Password_RightDoor_01:
                    return "�����̏����ꂽ��(�E) 01";
                case ItemName_Enum.Password_LeftDoor_02:
                    return "�����̏����ꂽ��(��) 02";
                case ItemName_Enum.Password_RightDoor_02:
                    return "�����̏����ꂽ��(�E) 02";
                case ItemName_Enum.Password_LeftDoor_03:
                    return "�����̏����ꂽ��(��) 03";
                default:
                    return "";
            }
        }
    }
}