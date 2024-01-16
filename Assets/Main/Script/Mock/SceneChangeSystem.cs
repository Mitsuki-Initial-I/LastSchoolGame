using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MockScene
{
    public class SceneChangeSystem 
    {
        public void SceneChangeProcess(SceneNameEnum sceneNameEnum)
        {
            SceneManager.LoadScene((int)sceneNameEnum);
        }
        public void SceneChangeProcess(int sceneNameEnum)
        {
            SceneManager.LoadScene(sceneNameEnum);
        }
    }
}