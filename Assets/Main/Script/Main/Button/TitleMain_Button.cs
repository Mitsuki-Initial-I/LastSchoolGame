using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class TitleMain_Button : MonoBehaviour
    {
        [SerializeField]
        GameObject panel;

        [SerializeField]
        MapChangeSceneName_Enum MapChangeSceneName_;

        public void StartButton()
        {
            StackData.instance.lastDoorNumber = -1;
            SaveAndLoadSystem saveAndLoadSystem = new SaveAndLoadSystem();
            if (saveAndLoadSystem.CheckSaveData())
            {
                saveAndLoadSystem.LoadSystem();
            }
            
            var SceneChangeSystem = new SceneChange_System();
            SceneChangeSystem.ChangeSceneSystem(MapChangeSceneName_);
        }
        public void GuideButton()
        {
            panel.SetActive(true);
        }
        public void BackButton()
        {
            panel.SetActive(false);
        }
    }
}