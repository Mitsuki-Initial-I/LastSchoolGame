using UnityEngine;

namespace MainScenes
{
    public class Gimmick_EndBed : BaseGimmick
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