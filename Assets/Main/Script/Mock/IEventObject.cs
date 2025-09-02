using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MockScene
{
    public interface IEventObject
    {
        public GimmickName_Enum GetGimmickName_();
        public void ActionEventProcess();
        public void AutoEventStartProcess();
        public void AutoEventStayProcess(GameObject playerObject);
        public void AutoEventEndProcess();
    }
}