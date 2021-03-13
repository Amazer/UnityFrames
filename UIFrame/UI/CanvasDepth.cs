using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDepth : MonoBehaviour
{
    public bool isUI = false;
    public int sortingOrder = 0;
    public string sortingLayer;

    private Canvas canvas;
    private GraphicRaycaster caster;
    private int _setOrder = -1;
    private string _layerName;
    private bool _inited = false;


    void Start()
    {
        Init();
    }
    private void Init()
    {
        if (!_inited)
        {
            _inited = true;
            if (isUI)
            {
                Transform tr = this.transform;
                GameObject go = this.gameObject;

                canvas = go.GetComponent<Canvas>();
                if (canvas == null)
                {
                    canvas = go.AddComponent<Canvas>();
                }
                caster = go.GetComponent<GraphicRaycaster>();
                if (caster == null)
                {
                    caster = go.AddComponent<GraphicRaycaster>();
                }
            }

        }
    }

    public void SetLayerAndOrder(string layerName, int order)
    {
        sortingLayer = layerName;
        sortingOrder = order;
    }

    private void Set()
    {
        Init();
        _setOrder = sortingOrder;
        if (isUI)
        {
            canvas.overrideSorting = true;
            canvas.sortingLayerName = sortingLayer;
            canvas.sortingOrder = sortingOrder;

        }
        else
        {
            Renderer[] renders = this.GetComponentsInChildren<Renderer>(true);
            for (int i = 0, imax = renders.Length; i < imax; ++i)
            {
                renders[i].sortingOrder = sortingOrder;
                renders[i].sortingLayerName = this.sortingLayer;
            }
        }

    }

    void Update()
    {
        if (_setOrder != sortingOrder || _layerName != sortingLayer)
        {
            Set();
        }
    }
}
