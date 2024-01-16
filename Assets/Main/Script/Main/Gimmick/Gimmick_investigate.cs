using UnityEngine;

namespace MainScenes
{
    public class Gimmick_investigate : BaseGimmick
    {
        [SerializeField]
        GameObject panel;

        public override void UseGimmick()
        {
            panel.SetActive(true);
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;
        }
    }
}