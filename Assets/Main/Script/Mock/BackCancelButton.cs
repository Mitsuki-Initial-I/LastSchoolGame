using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MockScene
{
    public class BackCancelButton : MonoBehaviour
    {
        [SerializeField]
        GameObject mother;
        [SerializeField]
        bool endButton = false;
        public void BackCancelButtonProcess()
        {
            mother.SetActive(false);
            if (endButton)
            {
                StackDataObject.instance.playerControllerMode_ = PlayerControllerMode_Enum.PlayerCharacterControllerMode;
            }
        }
    }
}