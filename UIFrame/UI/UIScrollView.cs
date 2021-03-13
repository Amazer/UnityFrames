using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UIScrollView  {
    public ScrollRect scrollRect;
    public Transform content;
    public GameObject itemGo;
    public System.Type itemType;

    public List<UIScrollItem> itemList;

    public void Init(GameObject scrollView,GameObject itemGo,Type itemType)
    {
        this.scrollRect = scrollView.transform.GetComponent<ScrollRect>();
        this.content = this.scrollRect.content;
        itemList = new List<UIScrollItem>();
        this.itemGo = itemGo;
        this.itemGo.SetActive(false);
        this.itemType = itemType;
    }

    public void RemoveAllArray()
    {
        for(int i =0,imax=itemList.Count;i<imax; ++i)
        {
            itemList[i].go.SetActive(false);
        }

    }
    public void AddData(List<object> dataList)
    {
        for (int i = 0, imax = dataList.Count; i < imax;++i)
        {
            UIScrollItem item;
            if(itemList.Count<=i)
            {
                GameObject newItemGo = GameObject.Instantiate(itemGo);
                newItemGo.transform.parent = content;
                newItemGo.transform.localPosition = Vector3.zero;
                newItemGo.transform.localScale = Vector3.one;
                item = newItemGo.AddComponent(itemType) as UIScrollItem;
                item.Init(newItemGo);
                itemList.Add(item);
            }
            else
            {
                item = itemList[i];
            }
            item.go.SetActive(true);
            item.Show(dataList[i]);
        }
    }

}
