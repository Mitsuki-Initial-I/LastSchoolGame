using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class EndButton : MonoBehaviour
    {
        public void EndButtonEvent()
        {
            this.gameObject.transform.parent.gameObject.SetActive(false);
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_ = InputMode_Enum.MovePlayerCharacter_Mode;
        }
    }
}
