using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Debug_EndRoomGimmick : BaseGimmick
    {
        [SerializeField]
        MapChangeSceneName_Enum MapChangeSceneName_;
        public override void UseGimmick()
        {
            var SceneChangeSystem = new SceneChange_System();
            SceneChangeSystem.ChangeSceneSystem(MapChangeSceneName_);
        }
    }
}