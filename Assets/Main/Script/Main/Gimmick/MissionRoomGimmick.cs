using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class MissionRoomGimmick : MonoBehaviour
    {
        [SerializeField]
        bool isRight;
        [SerializeField]
        GameObject[] stages;
        private void Start()
        {
            if (isRight)
            {
                switch (StackData.instance.GetComponent<RoomData>().roomId_R)
                {
                    case RoomId_R_Enum.NoMission:
                        stages[(int)RoomId_R_Enum.NoMission].SetActive(true);
                        break;
                    case RoomId_R_Enum.Mission_01:
                        stages[(int)RoomId_R_Enum.Mission_01].SetActive(true);
                        break;
                    case RoomId_R_Enum.Mission_02:
                        stages[(int)RoomId_R_Enum.Mission_02].SetActive(true);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (StackData.instance.GetComponent<RoomData>().roomId_L)
                {
                    case RoomId_L_Enum.NoMission:
                        stages[(int)RoomId_L_Enum.NoMission].SetActive(true);
                        break;
                    case RoomId_L_Enum.Mission_01:
                        stages[(int)RoomId_L_Enum.Mission_01].SetActive(true);
                        break;
                    case RoomId_L_Enum.Mission_02:
                        stages[(int)RoomId_L_Enum.Mission_02].SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}