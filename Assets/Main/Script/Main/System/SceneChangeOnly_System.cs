using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class SceneChangeOnly_System : MonoBehaviour
    {
        [SerializeField]
        MapChangeSceneName_Enum MapChangeSceneName_;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StackData.instance.lastDoorNumber = -1;
                var SceneChangeSystem = new SceneChange_System();
                SceneChangeSystem.ChangeSceneSystem(MapChangeSceneName_);
            }
        }
    }
}