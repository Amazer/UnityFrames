using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAtlas
{
    public string atlasName;
    public AssetsList assetsList;
    public Dictionary<string, Sprite> dict;
    public void Init(AssetsList list)
    {
        this.dict = new Dictionary<string, Sprite>();
        this.assetsList = list;
        for(int i=0,imax = this.assetsList.list.Count;i<imax;++i)
        {
            Object o = this.assetsList.list[i];
            this.dict[o.name] = o as Sprite;
        }
    }

    public Sprite Get(string name)
    {
        Sprite s = null;
        dict.TryGetValue(name, out s);
        return s;

    }
}
