using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    public class Communication_MainText : MonoBehaviour
    {
        [SerializeField]
        GameObject cursorTextObject;    // �����\���I��肪�킩��悤�ɂ���
        [SerializeField]
        float textSpeed = 5.0f;
        
        public string viewText;         // �\���������e�L�X�g
        private string stockText;       // �\������e�L�X�g
        private int frameCount;
        private int textNum = 0;
        private Text myText;            
        private bool textMaxFlg = false;
        private IGetKeyData getKeyData;

        public void SetText(CommunicationTextMode_Enum textMode_, string text = "")
        {
            switch (textMode_)
            {
                case CommunicationTextMode_Enum.getItem:
                    viewText = $"{text}����ɓ��ꂽ";
                    break;
                case CommunicationTextMode_Enum.noRoomKey:
                    viewText = $"�����������Ă���";
                    break;
                case CommunicationTextMode_Enum.useRoomKey:
                    viewText = $"{text}���g�p����";
                    break;
                default:
                    break;
            }
        }
        public void TextReset()
        {
            textNum = 0;
            frameCount = 0;
            stockText = "";
            TryGetComponent(out myText);
            myText.text = "";
            textMaxFlg = false;
        }

        void Start()
        {
            TryGetComponent(out myText);
            GameObject.Find("StackDataObject").TryGetComponent(out getKeyData);
            cursorTextObject.SetActive(false);
        }

        void Update()
        {
            if (textMaxFlg && getKeyData.Check_ClickMouseLeftButton())
            {
                PlayerAction playerAction = GameObject.Find("P").GetComponent<PlayerAction>();
                playerAction.inputMode_ = InputMode_Enum.MovePlayerCharacter_Mode;
                this.transform.parent.gameObject.SetActive(false);
            }
            else if(!textMaxFlg)
            {
                if (getKeyData.Check_ClickMouseLeftButton())
                {
                    stockText = viewText;
                    myText.text = stockText;
                }
                if (frameCount % textSpeed == 0)
                {
                    stockText += viewText.Substring(textNum, 1);
                    textNum++;
                    frameCount = 0;
                    myText.text = stockText;
                }
                if(viewText==stockText)
                {
                    textMaxFlg = true;
                    cursorTextObject.SetActive(true);
                }

                frameCount++;
            }
        }
    }
}