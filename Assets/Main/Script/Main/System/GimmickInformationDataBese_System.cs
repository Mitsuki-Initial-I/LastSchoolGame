namespace MainScenes
{
    public class GimmickInformationDataBese_System
    {
        public string Search_ItemInformation(GimmickInformationName_Enum informationName)
        {
            switch (informationName)
            {
                case GimmickInformationName_Enum.Hint_01:
                    return "部屋に入るには水晶玉へお願いしましょう";
                default:
                    return "";
            }
        }
    }
}