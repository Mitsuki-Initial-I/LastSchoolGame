using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainScenes
{
    public class Gimmick_Cannon : BaseGimmick
    {
        public override void UseGimmick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
