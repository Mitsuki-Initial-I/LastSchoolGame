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
        
        private void Update()
        {
            if(Input.GetKey(KeyCode.Tab)&& Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.P))
            {
                SaveAndLoadSystem saveAndLoadSystem = new SaveAndLoadSystem();
                if (saveAndLoadSystem.CheckSaveData())
                {
                    saveAndLoadSystem.FolderDelete();
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
            }
        }
    }
}