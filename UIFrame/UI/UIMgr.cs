using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : SinClass<UIMgr>
{
    public Dictionary<string, GameObject> openViewDict;
    public Dictionary<string, GameObject> closeViewDict;
    public List<UIViewName> openViewStack;
    public Transform openLayer;
    public Transform hideLayer;
    public GameObject uiRootGo;
    public override void Init()
    {
        base.Init();
        openViewDict = new Dictionary<string, GameObject>();
        closeViewDict = new Dictionary<string, GameObject>();
        openViewStack = new List<UIViewName>();

        uiRootGo = ResLoadMgr.instance.LoadGameObject("Prefab/UIRoot");
        uiRootGo.name = "UIRoot";
        hideLayer = uiRootGo.transform.FindChild("Canvas/HideLayer");
        openLayer = uiRootGo.transform.FindChild("Canvas/OpenLayer");
    }
    public override void UnInit()
    {
        base.UnInit();
    }


    public void OpenView(UIViewName uiName,params object[] param)
    {
        for(int i=0;i<openViewStack.Count;++i)
        {
            CloseView(openViewStack[i]);
        }
        openViewStack.Clear();
        openViewStack.Add(uiName);

        string ViewName = uiName.ToString();
        if(openViewDict.ContainsKey(ViewName))
        {
            return;
        }
        GameObject ui = null;
        if(closeViewDict.ContainsKey(ViewName))
        {
            ui = closeViewDict[ViewName];
            closeViewDict.Remove(ViewName);
            openViewDict[ViewName] = ui;
        }
        else
        {
            GameObject resGo = Resources.Load<Object>("Prefab/UI/" + ViewName ) as GameObject;
            ui = GameObject.Instantiate(resGo);
            CanvasDepth cd= ui.AddComponent<CanvasDepth>();
            cd.isUI = true;
            openViewDict[ViewName] = ui;
        }
        ui.transform.parent = openLayer;
        ui.transform.localScale = Vector3.one;
        ui.transform.localEulerAngles = Vector3.zero;
        ui.transform.localPosition = Vector3.zero;
        UIBaseView uiView = ui.GetComponent<UIBaseView>();
        uiView.OpenView(param);
    }
    public void CloseView(UIViewName uiName)
    {
        string ViewName = uiName.ToString();
        if(!openViewDict.ContainsKey(ViewName))
        {
            return;
        }
        GameObject ui = openViewDict[ViewName];
        openViewDict.Remove(ViewName);
        closeViewDict[ViewName] = ui;
        UIBaseView uiView = ui.GetComponent<UIBaseView>();
        uiView.CloseView();

        ui.transform.parent = hideLayer;
        ui.transform.localScale = Vector3.one;
        ui.transform.localEulerAngles = Vector3.zero;
        ui.transform.localPosition = Vector3.zero;
    }
}
