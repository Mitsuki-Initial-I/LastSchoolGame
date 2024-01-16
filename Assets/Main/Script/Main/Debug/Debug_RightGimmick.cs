namespace MainScenes
{
    public class Debug_RightGimmick : ClearGimmickBase, IGetGimmick
    {
        public override void GimmickClear()
        {
            Destroy(this.gameObject);
        }
        public void UseGimmick()
        {
            StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[(int)gimmickName_] = true;
            Destroy(this.gameObject);
        }
    }
}