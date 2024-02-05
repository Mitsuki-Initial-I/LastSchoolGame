using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class BaseUIButtons : MonoBehaviour
    {
        [SerializeField]
        GameObject menuPanel;
        [SerializeField]
        GameObject myItemPanel;
        [SerializeField]
        GameObject hintPanel;

        IGetKeyData getKeyData;
        PlayerAction playerAction;

        private void Start()
        {
            getKeyData = StackData.instance.gameObject.GetComponent<IGetKeyData>();

            playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
        }
        private void Update()
        {
            if (getKeyData.CheckEscKey() && playerAction.inputMode_ == InputMode_Enum.MovePlayerCharacter_Mode)
            {
                menuPanel.SetActive(true);
                // プレイヤの入力モード変更
                playerAction.inputMode_ = InputMode_Enum.UserInterface_Mode;
            }
        }

        public void ItemButton()
        {
            myItemPanel.SetActive(true);
            myItemPanel.GetComponent<ItemPanel_System>().GetItem();

            // プレイヤの入力モード変更
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;
        }
        public void SaveButton()
        {
            var SaveAndLoadSystem = new SaveAndLoadSystem();
            SaveAndLoadSystem.SaveSystem();
            menuPanel.SetActive(false);
            // プレイヤの入力モード変更
            playerAction.inputMode_ = InputMode_Enum.MovePlayerCharacter_Mode;
        }
        public void ChangeTitleScene()
        {
            var SceneChangeSystem = new SceneChange_System();
            SceneChangeSystem.ChangeSceneSystem(0);
        }
        public void HintButton()
        {
            hintPanel.SetActive(true);
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;
        }
    }
}