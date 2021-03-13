using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UITools
{

    public static T FindInChild<T>(Transform tr, string path)
    {
        return tr.FindChild(path).GetComponent<T>();
    }
    public static GameObject FindChild(Transform tr, string path)
    {
        return tr.FindChild(path).gameObject;
    }
}
