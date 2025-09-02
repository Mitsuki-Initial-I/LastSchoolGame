using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Gimmick_investigate_CrystlBall : ClearGimmickBase,IGetGimmick
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        GameObject button;
        [SerializeField]
        bool isRight;

        int pw;

        void GetData()
        {
            pw = isRight ? StackData.instance.GetComponent<RoomData>().lastDoorNumber_R : StackData.instance.GetComponent<RoomData>().lastDoorNumber_L;
        }

        public override void GimmickClear()
        {
            GetData();
        }

        public void UseGimmick()
        {
            panel.SetActive(true);
            PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
            playerAction.inputMode_++;
            GetData(); 
            button.GetComponent<Passwoed_GimmickButton_NoDelete_CrystlBall>().SetData(pw, isRight);
        }
    }
}