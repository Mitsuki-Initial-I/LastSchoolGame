using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Camera_PlayerStalker : MonoBehaviour
    {
        GameObject player;
        Vector3 offset = new Vector3(0, 0, - 10);
        void Start()
        {
            player = GameObject.Find("P");
        }
        void Update()
        {
            transform.position = player.transform.position + offset;
        }
    }
}