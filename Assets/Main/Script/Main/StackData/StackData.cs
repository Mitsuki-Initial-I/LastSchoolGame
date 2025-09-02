using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class StackData : MonoBehaviour
    {
        public static StackData instance;
        public int lastDoorNumber;
        public PlayNumCountData playNumCountData=new PlayNumCountData();

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