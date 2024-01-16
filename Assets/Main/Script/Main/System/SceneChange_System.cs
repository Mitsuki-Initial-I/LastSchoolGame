using UnityEngine.SceneManagement;

namespace MainScenes
{
    public class SceneChange_System 
    {
        public void ChangeSceneSystem(MapChangeSceneName_Enum sceneName_)
        {
            SceneManager.LoadScene((int)sceneName_);
        }
    }
}