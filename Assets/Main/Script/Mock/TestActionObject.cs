using UnityEngine;

namespace MockScene
{
    public class TestActionObject : MonoBehaviour, IEventObject
    {
        [SerializeField]
        GameObject gimmickPanel;

        public GimmickName_Enum GetGimmickName_()
        {
            return GimmickName_Enum.Action;
        }
        void IEventObject.ActionEventProcess()
        {
            StackDataObject.instance.playerControllerMode_ = PlayerControllerMode_Enum.GimmickControllerMode;
            gimmickPanel.SetActive(true);

            //            Debug.Log("ƒAƒNƒVƒ‡ƒ“");
            //if (wallObject != null)
            //{
            //    Destroy(wallObject);
            //}
        }
        void IEventObject.AutoEventStartProcess()
        {
            return;
        }

        void IEventObject.AutoEventStayProcess(GameObject playerObject)
        {
            return;
        }
        void IEventObject.AutoEventEndProcess()
        {
            return;
        }
    }
}