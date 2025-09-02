using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class BackButton : MonoBehaviour
    {
        public void BackButtonEvent()
        {
            this.gameObject.transform.parent.gameObject.SetActive(false);
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_--;
        }
    }
}