namespace MainScenes
{
    public class GimmickInformationDataBese_System
    {
        public string Search_ItemInformation(GimmickInformationName_Enum informationName)
        {
            switch (informationName)
            {
                case GimmickInformationName_Enum.Hint_01:
                    return "•”‰®‚É“ü‚é‚É‚Í…»‹Ê‚Ö‚¨Šè‚¢‚µ‚Ü‚µ‚å‚¤";
                default:
                    return "";
            }
        }
    }
}