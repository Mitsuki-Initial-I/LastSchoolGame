using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class StackData : MonoBehaviour
    {
        public static StackData instance;
        public int lastDoorNumber;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}