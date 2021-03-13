using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIView的资源加载状态
/// </summary>
public enum UIViewResState
{
    CLOSED,         // 关闭
    LOADING,        // 正在加载
    LOAD_SUCCESS,   // 加载成功
    LOAD_FAILED,    // 加载失败
    BREAK_LOAD,     // 中断加载（放弃加载）
    UNLOAD,         // 卸载
    OPENED,         // 打开状态
}
public enum UIViewState
{
    NONE,               // 无状态，还没有开始
    LOADING,            // 正在加载
    LOADED,             // 加载完成
    INITING,            // 正在初始化
    OPENING,            // 已经打开
    CLOSED,             // 界面关闭
}

public class UIBaseView2
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
//        this._go = gameObject;
//        this._tr = transform;
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
