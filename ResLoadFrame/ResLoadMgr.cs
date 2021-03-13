using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResLoadMgr : SinClass<ResLoadMgr>
{
    public override void Init()
    {
        base.Init();
    }
    public override void UnInit()
    {
        base.UnInit();
    }

    public GameObject LoadGameObject(string path)
    {
        Object o = Resources.Load<Object>(path);
        return GameObject.Instantiate(o) as GameObject;
    }
}
