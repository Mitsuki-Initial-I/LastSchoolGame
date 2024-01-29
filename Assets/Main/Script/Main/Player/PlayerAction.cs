using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField]
        Sprite[] playerSprites;

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
        SpriteRenderer sr;

        public InputMode_Enum inputMode_ = InputMode_Enum.MovePlayerCharacter_Mode;

        private void Start()
        {
            GameObject.Find("StackDataObject").TryGetComponent(out getKeyData);
            TryGetComponent(out rig2d);
            TryGetComponent(out sr);
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
        private int AnimationNumber()
        {
            if (getKeyData.InputKey_Horizontal() != 0)
            {
                return 1;
            }
            else if (getKeyData.InputKey_Vertical() > 0)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        public Vector3 MoveRotation()
        {

            if (getKeyData.InputKey_Horizontal() < 0)
            {
                return new Vector3(0, 180, 0);
            }
            else
            {
                return Vector3.zero;
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
                    sr.sprite = playerSprites[AnimationNumber()];
                    transform.localEulerAngles = MoveRotation();
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