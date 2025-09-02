namespace MainScenes
{
    public interface IGetKeyData
    {
        public bool CheckActionKey();
        public int InputKey_Vertical();
        public int InputKey_Horizontal();
        public bool Check_ClickMouseLeftButton();
        public bool CheckLeftShiftKeyDown();
        public bool CheckLeftShiftKeyUp();
        public bool CheckEscKey();
    }
}