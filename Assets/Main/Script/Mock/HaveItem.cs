using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MockScene
{
    public class HaveItem : MonoBehaviour
    {
        [SerializeField]
        GameObject panel;

        public void GetItemButton()
        {
            panel.SetActive(true);
            Destroy(gameObject);
        }
    }
}