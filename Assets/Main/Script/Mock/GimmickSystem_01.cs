using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MockScene
{
    public class GimmickSystem_01 : MonoBehaviour
    {
        [SerializeField]
        GameObject panel;
        public void OpenPanelProcess()
        {
            panel.SetActive(true);
        }
    }
}
