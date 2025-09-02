using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

namespace MainScenes
{
    public class TitleMain_Button : MonoBehaviour
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject[] logTag=new GameObject[3];

        [SerializeField]
        MapChangeSceneName_Enum MapChangeSceneName_;

        string folderPath;
        string fileName = "playLogData.json";

        private void Start()
        {
            folderPath = $"{Application.persistentDataPath}/";
        }
        public void FileDeleteProcess()
        {
            SaveAndLoadSystem saveAndLoadSystem = new SaveAndLoadSystem();
            if (saveAndLoadSystem.CheckSaveData())
            {
                for (int i = 0; i < StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum.Length; i++)
                {
                    StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum[i] = false;
                }

                for (int i = 0; i < StackData.instance.gameObject.GetComponent<MyItemData>().myItem.Length; i++)
                {
                    StackData.instance.gameObject.GetComponent<MyItemData>().myItem[i] = false;
                }

                StackData.instance.gameObject.GetComponent<RoomData>().lastDoorNumber_L = 0;
                StackData.instance.gameObject.GetComponent<RoomData>().lastDoorNumber_R = 0;
                StackData.instance.gameObject.GetComponent<RoomData>().roomId_R = 0;
                StackData.instance.gameObject.GetComponent<RoomData>().roomId_L = 0;

                for (int i = 0; i < StackData.instance.gameObject.GetComponent<RoomData>().roomClear_R.Length; i++)
                {
                    StackData.instance.gameObject.GetComponent<RoomData>().roomClear_R[i] = false;
                }
                for (int i = 0; i < StackData.instance.gameObject.GetComponent<RoomData>().roomClear_L.Length; i++)
                {
                    StackData.instance.gameObject.GetComponent<RoomData>().roomClear_L[i] = false;
                }

                saveAndLoadSystem.FolderDelete();
            }
        }

        public void StartButton()
        {
            StackData.instance.lastDoorNumber = -1;
            SaveAndLoadSystem saveAndLoadSystem = new SaveAndLoadSystem();
            if (saveAndLoadSystem.CheckSaveData())
            {
                saveAndLoadSystem.LoadSystem();
            }

            var accessSystem = new DataAccessSystem();
            PlayNumCountData playNumCountData = new PlayNumCountData();
            if (File.Exists(fileName))
            {
                accessSystem.LoadFileSystem(folderPath, fileName, out playNumCountData);
            }
            StackData.instance.playNumCountData = playNumCountData;
            StackData.instance.playNumCountData.playNum++;
            accessSystem.SaveFileSystem(folderPath, fileName, playNumCountData);

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
        public void BackButton2()
        {
            logTag[0].SetActive(false);
        }
        
        private void Update()
        {
            if(Input.GetKey(KeyCode.Tab)&& Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.P))
            {
                FileDeleteProcess();
            }
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                var accessSystem = new DataAccessSystem();
                PlayNumCountData playNumCountData = new PlayNumCountData();
                accessSystem.LoadFileSystem(folderPath, fileName, out playNumCountData);
                StackData.instance.playNumCountData = playNumCountData;
                logTag[0].SetActive(true);
                logTag[1].GetComponent<Text>().text = StackData.instance.playNumCountData.playNum.ToString();
                logTag[2].GetComponent<Text>().text = StackData.instance.playNumCountData.clearNum.ToString();
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