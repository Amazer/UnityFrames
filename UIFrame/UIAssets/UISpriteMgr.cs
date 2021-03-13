using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteMgr : SinClass<UISpriteMgr>
{
    private Dictionary<UIAtlasName, UIAtlas> dict;
    public override void Init()
    {
        base.Init();
        dict = new Dictionary<UIAtlasName, UIAtlas>();
    }

    public Sprite GetSprite(UIAtlasName atlasName,string spriteName)
    {
        UIAtlas a = null;
        if(!dict.TryGetValue(atlasName,out a))
        {
            a = new UIAtlas();
            AssetsList al = LoadAsset(atlasName.ToString());
            a.Init(al);
        }
        if(a!=null)
        {
            Sprite s = a.Get(spriteName);
            if(s==null)
            {
                Debug.LogError(string.Format("atlas.Get not find {0} in {1}",spriteName,atlasName));
            }
            return s;
        }
        Debug.LogError(string.Format("GetSprite not find {0} in {1}",spriteName,atlasName));
        return null;

    }
    private AssetsList LoadAsset(string assetName)
    {
        string path = "Prefab/AssetsList/" + assetName;
        Object o = Resources.Load<Object>(path);
        GameObject go = o as GameObject;
        AssetsList al = go.GetComponent<AssetsList>();
        return al;
    }
    
}
