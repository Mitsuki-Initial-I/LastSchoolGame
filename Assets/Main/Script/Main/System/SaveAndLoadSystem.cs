using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MainScenes
{
    public class SaveAndLoadSystem
    {
        private string folderPath = $"{Application.persistentDataPath}/SaveData/";
        private string fileName = "playSaveData.json";
        public bool CheckSaveData()
        {
            fileName = folderPath + fileName;
            return Directory.Exists(folderPath) && File.Exists(fileName);
        }
        public void FolderDelete()
        {
            foreach (string filename in Directory.GetFiles(folderPath)) 
            {
                File.Delete(filename);
            }
            Directory.Delete(folderPath);
        }
        public void SaveSystem()
        {
            var saveDatabese = new SaveData();

            saveDatabese.gimmickClearNum = StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum;
            saveDatabese.myItem = StackData.instance.gameObject.GetComponent<MyItemData>().myItem;
            saveDatabese.roomClear_R = StackData.instance.gameObject.GetComponent<RoomData>().roomClear_R;
            saveDatabese.roomClear_L = StackData.instance.gameObject.GetComponent<RoomData>().roomClear_L;

            var accessSystem = new DataAccessSystem();
            accessSystem.SaveFileSystem(folderPath, fileName, saveDatabese);
        }
        public void LoadSystem()
        {
            var saveDatabese = new SaveData();
            var accessSystem = new DataAccessSystem();
            accessSystem.LoadFileSystem(folderPath, fileName, out saveDatabese);
            StackData.instance.gameObject.GetComponent<GimmickClearData>().gimmickClearNum = saveDatabese.gimmickClearNum;
            StackData.instance.gameObject.GetComponent<MyItemData>().myItem = saveDatabese.myItem ;
            StackData.instance.gameObject.GetComponent<RoomData>().roomClear_R = saveDatabese.roomClear_R;
            StackData.instance.gameObject.GetComponent<RoomData>().roomClear_L = saveDatabese.roomClear_L;
        }
    }
}