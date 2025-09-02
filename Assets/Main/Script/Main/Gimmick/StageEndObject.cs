using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class StageEndObject : BaseGimmick
    {
        [SerializeField]
        bool isRight;
        [SerializeField]
        RoomId_L_Enum roomId_L_;
        [SerializeField]
        RoomId_R_Enum roomId_R_;

        public override void UseGimmick()
        {
            if (isRight)
            {
                StackData.instance.GetComponent<RoomData>().roomClear_R[(int)roomId_R_] = true;
                StackData.instance.GetComponent<GimmickClearData>().gimmickClearNum[(int)GimmickName_Enum.Light_Right] = true;
            }
            else
            {
                StackData.instance.GetComponent<RoomData>().roomClear_L[(int)roomId_L_] = true;
                StackData.instance.GetComponent<GimmickClearData>().gimmickClearNum[(int)GimmickName_Enum.Light_Left] = true;
            }

            StackData.instance.lastDoorNumber = -1;

            var SceneChangeSystem = new SceneChange_System();
            SceneChangeSystem.ChangeSceneSystem(MapChangeSceneName_Enum.MainHome);
        }
    }
}
