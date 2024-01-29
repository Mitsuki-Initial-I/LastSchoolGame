using UnityEngine;
using UnityEngine.UI;

public class CreateStageButtonController : MonoBehaviour, ICreateStageButtonAccess
{
    int id;
    Color myColor = Color.white;
    public void SetData(int getId)
    {
        id = getId;
        myColor = getId == 1 ? Color.red : Color.white;
        this.GetComponent<Image>().color = myColor;
    }
    public void ButtonEvent()
    {
        var getSystem = GameObject.Find("CreateStage").GetComponent<ICreateStageAccess>();
        getSystem.GetMyNum(id);
        switch ((StageItemName_Enum)getSystem.GetMyNum(id))
        {
            case StageItemName_Enum.noWall:
                myColor = Color.white;
                break;
            case StageItemName_Enum.wall:
                myColor = Color.red;
                break;
            case StageItemName_Enum.cahra:
                myColor = Color.cyan;
                break;
            case StageItemName_Enum.goal:
                myColor = Color.green;
                break;
            case StageItemName_Enum.cannon:
                myColor = Color.gray;
                break;
            case StageItemName_Enum.warpgate:
                myColor = Color.blue;
                break;
            case StageItemName_Enum.switchButton:
                myColor = Color.magenta;
                break;
            default:
                break;
        }
        this.GetComponent<Image>().color = myColor;

    }
}