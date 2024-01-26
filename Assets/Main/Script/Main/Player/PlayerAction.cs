using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField]
        GameObject[] door_GameObjects;

        [SerializeField]
        float moveSpeedOffset = 5.0f;
        [SerializeField]
        float defaultSpeed = 0.025f;

        float moveSpeed;
        IGetGimmick getGimmick;
        IGetKeyData getKeyData;
        Rigidbody2D rig2d;

        public InputMode_Enum inputMode_ = InputMode_Enum.MovePlayerCharacter_Mode;

        private void Start()
        {
            GameObject.Find("StackDataObject").TryGetComponent(out getKeyData);
            TryGetComponent(out rig2d);
            moveSpeed = moveSpeedOffset * defaultSpeed;// Time.deltaTime;

            var getNumber = StackData.instance.lastDoorNumber;
            for (int i = 0; i < door_GameObjects.Length; i++)
            {
                if(door_GameObjects[i].GetComponent<SceneChangePoint>().myId == getNumber)
                {
                    Vector3 offSetNum = Vector3.zero;
                    switch (door_GameObjects[i].GetComponent<SceneChangePoint>().MapChangeCheckAreaName_)
                    {
                        case MapChangeCheckAreaName_Enum.Under:
                            offSetNum = new Vector3(0, -1);
                            break;
                        case MapChangeCheckAreaName_Enum.Over:
                            offSetNum = new Vector3(0, 1);
                            break;
                        case MapChangeCheckAreaName_Enum.RightSide:
                            offSetNum = new Vector3(1, 0);
                            break;
                        case MapChangeCheckAreaName_Enum.LeftSiide:
                            offSetNum = new Vector3(-1, 0);
                            break;
                    }
                    transform.position = door_GameObjects[i].transform.position + offSetNum;
                    break;
                }
            }
        }

        private void Update()
        {
            if (getKeyData.CheckLeftShiftKeyDown())
            {
                var offSetSpeed = defaultSpeed + defaultSpeed;
                moveSpeed = moveSpeedOffset * offSetSpeed;
            }
            else if (getKeyData.CheckLeftShiftKeyUp())
            {
                moveSpeed = moveSpeedOffset * defaultSpeed;
            }

            if (inputMode_ == InputMode_Enum.MovePlayerCharacter_Mode)
            {
                bool isMoing = getKeyData.InputKey_Horizontal() != 0 || getKeyData.InputKey_Vertical() != 0;
                if (isMoing)
                {
                    var moveNumData = transform.position + new Vector3(getKeyData.InputKey_Horizontal(), getKeyData.InputKey_Vertical()).normalized * moveSpeed;
                    rig2d.MovePosition(moveNumData);
                }
                if (getKeyData.CheckActionKey() && getGimmick != null)
                {
                    getGimmick.UseGimmick();
                }
            }

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<IGetGimmick>() != null)
            {
                getGimmick = collision.GetComponent<IGetGimmick>();
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if(getGimmick!=null)
            {
                return;
            }
            if (getGimmick == null && collision.GetComponent<IGetGimmick>() != null)
            {
                getGimmick = collision.GetComponent<IGetGimmick>();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<IGetGimmick>() == getGimmick)
            {
                getGimmick = null;
            }
        }
    }
}