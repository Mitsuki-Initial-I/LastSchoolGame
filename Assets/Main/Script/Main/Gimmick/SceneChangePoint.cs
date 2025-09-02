using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class SceneChangePoint : BaseGimmick
    {
        public int myId;
        public MapChangeCheckAreaName_Enum MapChangeCheckAreaName_;    // Ç«Ç±Ç©ÇÁÉvÉåÉCÉÑÅ[Ç™ì¸Ç¡ÇƒóàÇÈÇ©
        [SerializeField]
        MapChangeSceneName_Enum MapChangeSceneName_;

        const float OBJECTSCALE_OFFSET = 0.5f;

        void ChangeScene()
        {
            StackData.instance.lastDoorNumber = myId;
            var SaveAndLoadSystem = new SaveAndLoadSystem();
            SaveAndLoadSystem.SaveSystem();
            var SceneChangeSystem = new SceneChange_System();
            SceneChangeSystem.ChangeSceneSystem(MapChangeSceneName_);
        }

        void CheckPosition(GameObject player)
        {
            Vector3 p_Pos = player.transform.position;
            Vector3 my_Pos = this.gameObject.transform.position;

            bool checkFlg = false;

            switch (MapChangeCheckAreaName_)
            {
                case MapChangeCheckAreaName_Enum.Under:
                    checkFlg = my_Pos.y <= (p_Pos.y + OBJECTSCALE_OFFSET);
                    break;
                case MapChangeCheckAreaName_Enum.Over:
                    checkFlg = my_Pos.y >= (p_Pos.y - OBJECTSCALE_OFFSET);
                    break;
                case MapChangeCheckAreaName_Enum.RightSide:
                    checkFlg = my_Pos.x >= (p_Pos.x - OBJECTSCALE_OFFSET);
                    break;
                case MapChangeCheckAreaName_Enum.LeftSiide:
                    checkFlg = my_Pos.x <= (p_Pos.x + OBJECTSCALE_OFFSET);
                    break;
            }

            if (checkFlg)
            {
                ChangeScene();
            }
        }

        public override void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.name == "P")
            {
                CheckPosition(collision.gameObject);
            }
        }
    }
}