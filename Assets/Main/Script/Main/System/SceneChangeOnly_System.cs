using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class SceneChangeOnly_System : MonoBehaviour
    {
        [SerializeField]
        MapChangeSceneName_Enum MapChangeSceneName_;

        string folderPath ;
        string fileName = "playLogData.json";

        private void Start()
        {
            StartCoroutine(TestData());
            folderPath = $"{Application.persistentDataPath}/";
        }

        void ResetMode()
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
            StackData.instance.playNumCountData.clearNum++; 
            var accessSystem = new DataAccessSystem();
            PlayNumCountData playNumCountData = new PlayNumCountData();
            accessSystem.SaveFileSystem(folderPath, fileName, playNumCountData);

            StackData.instance.lastDoorNumber = -1;
            var SceneChangeSystem = new SceneChange_System();
            SceneChangeSystem.ChangeSceneSystem(MapChangeSceneName_);

        }
        IEnumerator TestData()
        {
            yield return new WaitForSeconds(5.0f);
            ResetMode();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResetMode();
            }
        }
    }
}