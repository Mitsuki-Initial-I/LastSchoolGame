using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class RoomData : MonoBehaviour
    {
        public int lastDoorNumber_R;
        public int lastDoorNumber_L;
        public RoomId_R_Enum roomId_R;
        public RoomId_L_Enum roomId_L;
        public bool[] roomClear_R;
        public bool[] roomClear_L;

        private void Awake()
        {
            int roomClearCountR = System.Enum.GetValues(typeof(RoomId_R_Enum)).Length;
            roomClear_R = new bool[roomClearCountR];
            int roomClearCountL = System.Enum.GetValues(typeof(RoomId_L_Enum)).Length;
            roomClear_L = new bool[roomClearCountL];
        }
    }
}
