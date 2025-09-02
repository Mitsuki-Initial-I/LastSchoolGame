using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MockScene
{
    public class MapChangeObject : MonoBehaviour, IEventObject
    {
        public int myId;
        [SerializeField]
        SceneNameEnum sceneNameEnum;
        [SerializeField]
        MapChangeCheckAreaName_Enum mapChangeCheckArea;

        bool chengFlg = false;

        public GimmickName_Enum GetGimmickName_()
        {
            return GimmickName_Enum.MapCheng;
        }
        void IEventObject.ActionEventProcess()
        {
            return;
        }
        void IEventObject.AutoEventStartProcess()
        {
            return;
        }

        void CheckGimmickProcess(GameObject playerObject)
        {
            switch (mapChangeCheckArea)
            {
                case MapChangeCheckAreaName_Enum.Under:
                    if (transform.position.y >= playerObject.transform.position.y - playerObject.transform.localScale.y / 2)
                    {
                        SceneChangeProcess();
                    }
                    break;
                case MapChangeCheckAreaName_Enum.Over:
                    if (transform.position.y <= playerObject.transform.position.y + playerObject.transform.localScale.y / 2)
                    {
                        SceneChangeProcess();
                    }
                    break;
                case MapChangeCheckAreaName_Enum.RightSide:
                    if (transform.position.x <= playerObject.transform.position.x + playerObject.transform.localScale.x / 2)
                    {
                        SceneChangeProcess();
                    }
                    break;
                case MapChangeCheckAreaName_Enum.LeftSide:
                    if (transform.position.x >= playerObject.transform.position.x - playerObject.transform.localScale.x / 2)
                    {
                        SceneChangeProcess();
                    }
                    break;
                default:
                    break;
            }
        }

        void SceneChangeProcess()
        {
            if (!chengFlg)
            {
                chengFlg = true;
                StackDataObject.instance.sceneNum = myId;
                StackDataObject.instance.SceneName = sceneNameEnum;
                StackDataObject.instance.mapChangeCheckAreaName_Enum = mapChangeCheckArea;
                SceneChangeSystem sceneChangeSystem = new SceneChangeSystem();
                sceneChangeSystem.SceneChangeProcess(sceneNameEnum);
            }
        }

        void IEventObject.AutoEventStayProcess(GameObject playerObject)
        {
            if (playerObject == null)
            {
                return;
            }
            else
            {
                CheckGimmickProcess(playerObject);
            }
        }
        void IEventObject.AutoEventEndProcess()
        {
            return;
        }
    }
}