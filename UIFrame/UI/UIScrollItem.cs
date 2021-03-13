using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollItem:MonoBehaviour  {
    public GameObject go;
    public object data;

    public void Init(GameObject go)
    {
        this.go = go;
        this.OnInit();
    }
    protected virtual void OnInit()
    {

    }

    public void Show(object data)
    {
        this.data = data;
        this.OnShow();
    }
    protected virtual void OnShow()
    {

    }

}
