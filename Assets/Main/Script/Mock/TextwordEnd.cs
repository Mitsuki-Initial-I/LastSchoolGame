using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MockScene
{
    public class TextwordEnd : MonoBehaviour
    {
        [SerializeField]
        GameObject player;
        [SerializeField]
        GameObject mother;
        [SerializeField]
        GameObject gimmickStartObject;
        [SerializeField]
        int key;
        [SerializeField]
        Text[] textObject;

        [SerializeField]
        GameObject gimmickEndObject;

        public void CheckPasswoed()
        {
            string password=default;
            for (int i = 0; i < textObject.Length; i++)
            {
                password += textObject[i].text;
            }
            if (int.Parse(password) == key)
            {
                PasswordGimmick();
            }
        }
        void PasswordGimmick()
        {
            Destroy(gimmickEndObject);
            gimmickStartObject.GetComponent<BoxCollider2D>().isTrigger = true;
            var textComponent = gimmickStartObject.GetComponent<TestActionObject>();
            Destroy(textComponent);
            mother.SetActive(false);
            var playerComponent = player.GetComponent<PlayerMove>();
            playerComponent.NullSealItem();
            StackDataObject.instance.playerControllerMode_ = PlayerControllerMode_Enum.PlayerCharacterControllerMode;
        }
    }
}
