using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICreateStageAccess
{
    public int GetMyNum(int getId);
}
public enum StageItemName_Enum
{
    noWall,
    wall,
    cahra,
    goal,
    cannon,
    warpgate,
    switchButton,
}
public enum CreateStageMove_Enum
{
    SetthingMode,
    CreateMode,
    TestPlayMode,
}
public class MainSystem_CreateGimmickMap : MonoBehaviour, ICreateStageAccess
{
    #region
    // セル情報
    private class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    // 方向
    private enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    public class CreateMapAlSystem
    {
        const int Path = 0;
        const int Wall = 1;

        private int[,] Maze;
        private int Width { get; set; }
        private int Height { get; set; }
        private List<Cell> StartCells;

        public CreateMapAlSystem(int getWidth, int getHeight)
        {
            if (getWidth < 5 || getHeight < 5) throw new ArgumentOutOfRangeException();
            this.Width = getWidth;
            this.Height = getHeight;
            Maze = new int[getWidth, getHeight];
            StartCells = new List<Cell>();
        }

        private void SetPath(int getX, int getY)
        {
            this.Maze[getX, getY] = Path;
            if (getX % 2 == 1 && getY % 2 == 1)
            {
                // 穴掘り候補座標
                StartCells.Add(new Cell() { X = getX, Y = getY });
            }
        }

        private Cell GetStartCell()
        {
            if (StartCells.Count == 0) return null;

            // ランダムに開始座標を取得する
            var rnd = new System.Random();
            var index = rnd.Next(StartCells.Count);
            var cell = StartCells[index];
            StartCells.RemoveAt(index);

            return cell;
        }

        private void Dig(int getX, int getY)
        {
            var rnd = new System.Random();
            while (true)
            {
                var directions = new List<Direction>();
                if (this.Maze[getX, getY - 1] == Wall && this.Maze[getX, getY - 2] == Wall)
                    directions.Add(Direction.Up);
                if (this.Maze[getX + 1, getY] == Wall && this.Maze[getX + 2, getY] == Wall)
                    directions.Add(Direction.Right);
                if (this.Maze[getX, getY + 1] == Wall && this.Maze[getX, getY + 2] == Wall)
                    directions.Add(Direction.Down);
                if (this.Maze[getX - 1, getY] == Wall && this.Maze[getX - 2, getY] == Wall)
                    directions.Add(Direction.Left);

                if (directions.Count == 0) break;

                SetPath(getX, getY);

                var dirIndex = rnd.Next(directions.Count);
                switch (directions[dirIndex])
                {
                    case Direction.Up:
                        SetPath(getX, --getY);
                        SetPath(getX, --getY);
                        break;
                    case Direction.Right:
                        SetPath(++getX, getY);
                        SetPath(++getX, getY);
                        break;
                    case Direction.Down:
                        SetPath(getX, ++getY);
                        SetPath(getX, ++getY);
                        break;
                    case Direction.Left:
                        SetPath(--getX, getY);
                        SetPath(--getX, getY);
                        break;
                }
            }
            var cell = GetStartCell();
            if (cell != null)
            {
                Dig(cell.X, cell.Y);
            }
        }

        public int[,] CreateMaze()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == 0 || y == 0 || x == this.Width - 1 || y == this.Height - 1)
                    {
                        Maze[x, y] = Path;
                    }
                    else
                    {
                        Maze[x, y] = Wall;
                    }
                }
            }
            Dig(1, 1);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == 0 || y == 0 || x == this.Width - 1 || y == this.Height - 1)
                    {
                        Maze[x, y] = Wall;
                    }
                }
            }
            return Maze;
        }
    }

    #endregion
    [SerializeField]
    private Text[] startSetTexts; // 0:名前,1:x,2:y
    [SerializeField]
    private GameObject prefab_StageButton;  // プレハブ
    [SerializeField]
    private GameObject[] panels;            // パネル
    [SerializeField]
    private GameObject[] guideOjbects;      // ガイド
    [SerializeField]
    private GameObject[] stageItems;        // プレハブ
    [SerializeField]
    private GameObject playerObject;


    private CreateStageMove_Enum createStageMove_;
    private int width = 10;
    private int height = 10;
    private int myNum = 0;
    private int[,] mapData;
    private bool menuPanelFlg = false;

    public int GetMyNum(int getId)
    {
        mapData[getId / (int)height, getId % (int)height] = myNum;
        return myNum;
    }

    /// <summary>
    /// 初期値入力後に押されるボタン
    /// </summary>
    public void SetButton()
    {
        width = int.Parse(startSetTexts[1].text);
        height = int.Parse(startSetTexts[2].text);

        CreateMapAlSystem createMap = new CreateMapAlSystem(width, height);
        mapData = createMap.CreateMaze();

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject go = Instantiate(prefab_StageButton, transform);
                go.transform.localPosition = new Vector3((-height / 2 + j) * 100, (-width / 2 + i) * 100, 0);
                go.transform.GetComponent<ICreateStageButtonAccess>().SetData(i * (int)height + j);
                go.transform.GetComponent<Button>().onClick.AddListener(go.transform.GetComponent<ICreateStageButtonAccess>().ButtonEvent);
                go.GetComponent<Image>().color = mapData[i, j] == 1 ? Color.red : Color.white;
            }
        }
        float scalex = 1920f / (width * 100f);
        float scaley = 1080f / (height * 100f);

        float ScaleNum = scalex < scaley ? scalex : scaley;
        this.transform.localScale = new Vector3(ScaleNum, ScaleNum, 1);

        panels[0].SetActive(false);
        panels[1].SetActive(false);
        createStageMove_ = CreateStageMove_Enum.CreateMode;
    }

    public void PlayButton()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(false);

        switch (createStageMove_)
        {
            case CreateStageMove_Enum.SetthingMode:
                break;
            case CreateStageMove_Enum.CreateMode:
                createStageMove_ = CreateStageMove_Enum.TestPlayMode;
                foreach (Transform n in transform)
                {
                    n.gameObject.SetActive(false);
                }
                CreateStageData();
                panels[1].transform.Find("Button").GetComponent<Image>().color = Color.red;
                panels[1].transform.Find("Button").GetChild(0).GetComponent<Text>().text = "中止";
                break;
            case CreateStageMove_Enum.TestPlayMode:
                playerObject.SetActive(false);
                Destroy(GameObject.Find(startSetTexts[0].text));
                foreach (Transform n in transform)
                {
                    n.gameObject.SetActive(true);
                }
                createStageMove_ = CreateStageMove_Enum.CreateMode;
                panels[1].transform.Find("Button").GetComponent<Image>().color = Color.white;
                panels[1].transform.Find("Button").GetChild(0).GetComponent<Text>().text = "試遊";
                break;
        }
    }

    public void EndButton()
    {
        ResetDatas();
        createStageMove_ = CreateStageMove_Enum.SetthingMode;
        Destroy(GameObject.Find(startSetTexts[0].text));
        panels[0].SetActive(true);
        panels[1].SetActive(false);
    }

    private void CreateStageData()
    {
        GameObject motherObject = new GameObject(startSetTexts[0].text);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                switch ((StageItemName_Enum)mapData[i,j])
                {
                    case StageItemName_Enum.noWall: 
                        GameObject noWallObject = Instantiate(stageItems[0], motherObject.transform);
                        noWallObject.transform.localPosition = new Vector3((-height / 2 + j), (-width / 2 + i));
                        break;
                    case StageItemName_Enum.wall:
                        GameObject wallObject = Instantiate(stageItems[1], motherObject.transform);
                        wallObject.transform.localPosition = new Vector3((-height / 2 + j), (-width / 2 + i));
                        break;
                    case StageItemName_Enum.cahra:
                        playerObject.SetActive(true);
                        playerObject.transform.localPosition = new Vector3((-height / 2 + j), (-width / 2 + i+0.5f));
                        GameObject p_noWallObject = Instantiate(stageItems[0], motherObject.transform);
                        p_noWallObject.transform.localPosition = new Vector3((-height / 2 + j), (-width / 2 + i));
                        break;
                    case StageItemName_Enum.goal:
                        GameObject goalObject = Instantiate(stageItems[2], motherObject.transform);
                        goalObject.transform.localPosition = new Vector3((-height / 2 + j), (-width / 2 + i));
                        break;
                    case StageItemName_Enum.cannon:
                        GameObject cannonObject = Instantiate(stageItems[3], motherObject.transform);
                        cannonObject.transform.localPosition = new Vector3((-height / 2 + j), (-width / 2 + i));
                        break;
                    case StageItemName_Enum.warpgate:
                        GameObject warpgateObject = Instantiate(stageItems[4], motherObject.transform);
                        warpgateObject.transform.localPosition = new Vector3((-height / 2 + j), (-width / 2 + i));
                        break;
                    case StageItemName_Enum.switchButton:
                        GameObject switchButtonObject = Instantiate(stageItems[5], motherObject.transform);
                        switchButtonObject.transform.localPosition = new Vector3((-height / 2 + j), (-width / 2 + i));
                        break;
                    default:
                        break;
                }
            }
        }
    }
    private void ResetDatas()
    {

        foreach (Transform n in transform)
        {
            Destroy(n.gameObject);
        }
        for (int i = 0; i < startSetTexts.Length; i++)
        {
            startSetTexts[i].text = "";
        }
    }


    private string SetGuideText(int id)
    {
        switch ((StageItemName_Enum)id)
        {
            case StageItemName_Enum.noWall:
                return "通路の配置";
            case StageItemName_Enum.wall:
                return "壁の配置";
            case StageItemName_Enum.cahra:
                return "プレイヤの配置";
            case StageItemName_Enum.goal:
                return "ゴールの配置";
            case StageItemName_Enum.cannon:
                return "大砲の配置";
            case StageItemName_Enum.warpgate:
                return "ワープゲートの配置";
            case StageItemName_Enum.switchButton:
                return "スイッチの配置";
            default:
                return "ガイドテキスト";
        }
    }
    private Color SetGuideColor(int id)
    {
        switch ((StageItemName_Enum)id)
        {
            case StageItemName_Enum.noWall:
                return Color.white;
            case StageItemName_Enum.wall:
                return Color.red;
            case StageItemName_Enum.cahra:
                return Color.cyan;
            case StageItemName_Enum.goal:
                return Color.green;
            case StageItemName_Enum.cannon:
                return Color.gray;
            case StageItemName_Enum.warpgate:
                return Color.blue;
            case StageItemName_Enum.switchButton:
                return Color.magenta;
            default:
                return Color.white;
        }
    }

    private void Update()
    {
        switch (createStageMove_)
        {
            case CreateStageMove_Enum.SetthingMode:
                break;
            case CreateStageMove_Enum.CreateMode:
                if (Input.mouseScrollDelta.y != 0)
                {
                    myNum += (int)Input.mouseScrollDelta.y;
                    myNum = myNum >= Enum.GetValues(typeof(StageItemName_Enum)).Length ? 0 : myNum < 0 ? Enum.GetValues(typeof(StageItemName_Enum)).Length - 1 : myNum;
                    guideOjbects[0].GetComponent<Text>().text = SetGuideText(myNum);
                    guideOjbects[1].GetComponent<Image>().color = SetGuideColor(myNum);
                }

                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    menuPanelFlg = !menuPanelFlg;
                    panels[1].SetActive(menuPanelFlg);
                }
                break;
            case CreateStageMove_Enum.TestPlayMode:
                if (Input.GetKeyDown(KeyCode.Tab))
                {

                }
                break;
            default:
                break;
        }
    }
}