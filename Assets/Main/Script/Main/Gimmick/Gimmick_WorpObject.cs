using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Gimmick_WorpObject : BaseGimmick
    {
        [SerializeField] GameObject pairObject;

        public override void UseGimmick()
        {
            Transform Player = GameObject.Find("P").GetComponent<Transform>();
            Player.position = pairObject.transform.position;
        }
    }
}