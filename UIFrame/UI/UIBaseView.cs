using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBaseView : MonoBehaviour
{
    protected GameObject _go;
    protected Transform _tr;
    public bool isOpened = false;
    protected bool _isResOk = false;
    protected bool _isInited = false;
    private bool _needOpenView = false;
    private object[] _param;
    private void Awake()
    {
        this._go = gameObject;
        this._tr = transform;
        _isResOk = true;
    }
    private void Start()
    {
        _Init();
        _isInited = true;
        if(_needOpenView)
        {
            OpenView(_param);
            _param = null;
            _needOpenView = false;
        }
    }

    protected virtual void _Init()
    {

    }
    public void OpenView(params object[] param)
    {
        if (!_isInited)
        {
            _needOpenView = true;
            _param = param;
        }
        else
        {
            isOpened = true;
            _OpenView(param);
            _HandleAfterOpenView();
        }

    }
    public void CloseView()
    {
        isOpened = false;
        _HandleBeforeCloseView();

    }
    public void Update()
    {
        this._Update();
    }
    public void LateUpdate()
    {
        this._LateUpdate();

    }
    protected virtual void _OpenView(params object[] param)
    {

    }
    protected virtual void _HandleAfterOpenView()
    {

    }
    protected virtual void _HandleBeforeCloseView()
    {

    }
    protected virtual void _Update()
    {

    }
    protected virtual void _LateUpdate()
    {

    }

    protected T GetChild<T>(string name) 
    {
        return _tr.FindChild(name).GetComponent<T>();
    }
}
