namespace MainScenes
{
    public class GimmickInformationDataBese_System
    {
        public string Search_ItemInformation(GimmickInformationName_Enum informationName)
        {
            switch (informationName)
            {
                case GimmickInformationName_Enum.Hint_01:
                    return "�����ɓ���ɂ͐����ʂւ��肢���܂��傤";
                default:
                    return "";
            }
        }
    }
}