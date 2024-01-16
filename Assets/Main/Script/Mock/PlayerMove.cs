using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MockScene
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField]
        float moveSpeed = 5.0f;

        float movePower;
        [SerializeField]
        GameObject sealItem;

        [SerializeField]
        MapChangeObject[] mapChangeObjects;

        Rigidbody2D rig2d;
        IEventObject getAction;

        const float OFFSETPOS = 1.5f;

        void Start()
        {
            if (StackDataObject.instance.sceneNum != 0)
            {
                var getMapChangeNumber = StackDataObject.instance.sceneNum;
                var getMapName = StackDataObject.instance.SceneName;
                var pos = Vector3.zero;
                var getDis = StackDataObject.instance.mapChangeCheckAreaName_Enum;

                switch (getDis)
                {
                    case MapChangeCheckAreaName_Enum.Under:
                        pos.y = OFFSETPOS;
                        break;
                    case MapChangeCheckAreaName_Enum.Over:
                        pos.y = -OFFSETPOS;
                        break;
                    case MapChangeCheckAreaName_Enum.RightSide:
                        pos.x = -OFFSETPOS;
                        break;
                    case MapChangeCheckAreaName_Enum.LeftSide:
                        pos.x = OFFSETPOS;
                        break;
                    default:
                        break;
                }

                /*
                if (getMapName != SceneNameEnum.Comdor)
                {
                    pos.y = OFFSETPOS;
                }
                else
                {
                    switch (getMapChangeNumber)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            pos.x = -OFFSETPOS;
                            break;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            pos.x = OFFSETPOS;
                            break;
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                            pos.y = -OFFSETPOS;
                            break;
                    }
                }
                 */

                for (int i = 0; i < mapChangeObjects.Length; i++)
                {
                    if (mapChangeObjects[i].myId == getMapChangeNumber)
                    {
                        pos += mapChangeObjects[i].transform.position;
                        transform.position = pos;
                        break;
                    }
                }
            }
            TryGetComponent(out rig2d);
            movePower = moveSpeed * Time.deltaTime;
        }
        void Update()
        {
            if (StackDataObject.instance.playerControllerMode_ ==PlayerControllerMode_Enum.PlayerCharacterControllerMode)
            {
                float horizontalKey = Input.GetAxisRaw("Horizontal");
                float verticalKey = Input.GetAxisRaw("Vertical");
                Vector2 moveVector = new Vector2(horizontalKey, verticalKey);
                bool isMoving = (horizontalKey != 0 || verticalKey != 0);
                if (isMoving)
                {
                    var move = transform.position + new Vector3(moveVector.x, moveVector.y).normalized * movePower;
                    rig2d.MovePosition(move);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    getAction.ActionEventProcess();
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<IEventObject>() != null && getAction==null)
            {
                collision.TryGetComponent(out getAction);
                if (getAction.GetGimmickName_() != GimmickName_Enum.MapCheng) 
                {
                    sealItem.SetActive(true);
                }
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (getAction != null) 
            { 
                getAction.AutoEventStayProcess(this.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (getAction!=null)
            {
                if (collision.GetComponent<IEventObject>() == getAction)
                {
                    NullSealItem();
                }
            }
        }
        public void NullSealItem()
        {
            if (getAction.GetGimmickName_() != GimmickName_Enum.MapCheng)
            {
                sealItem.SetActive(false);
            }
            getAction = null;
        }
    }
}