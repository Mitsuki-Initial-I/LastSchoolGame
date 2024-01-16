using UnityEngine;
using UnityEngine.UI;

namespace MainScenes
{
    public class Communication_MainText : MonoBehaviour
    {
        [SerializeField]
        GameObject cursorTextObject;    // 文字表示終わりがわかるようにする
        [SerializeField]
        float textSpeed = 5.0f;
        
        public string viewText;         // 表示したいテキスト
        private string stockText;       // 表示するテキスト
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
                    viewText = $"{text}を手に入れた";
                    break;
                case CommunicationTextMode_Enum.noRoomKey:
                    viewText = $"鍵がかかっている";
                    break;
                case CommunicationTextMode_Enum.useRoomKey:
                    viewText = $"{text}を使用した";
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