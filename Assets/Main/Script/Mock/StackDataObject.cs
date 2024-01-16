using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MockScene
{
    public class StackDataObject : MonoBehaviour
    {
        public static StackDataObject instance;
        
        public int sceneNum = 0;
        public SceneNameEnum SceneName;
        public PlayerControllerMode_Enum playerControllerMode_ = PlayerControllerMode_Enum.GimmickControllerMode;
        public MapChangeCheckAreaName_Enum mapChangeCheckAreaName_Enum;

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
        private void Start()
        {

        }
    }
}