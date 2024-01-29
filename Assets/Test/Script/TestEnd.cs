using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainScenes;

public class TestEnd : BaseGimmick
{
    public override void UseGimmick()
    {
        GameObject.Find("CreateStage").GetComponent<MainSystem_CreateGimmickMap>().PlayButton();
    }
}