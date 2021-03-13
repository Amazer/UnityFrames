using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// 将rootPath下的每一个文件夹，都生成一个资源prefab
/// </summary>
public class AssetListEditor : EditorWindow
{
    static string rootPath = "Assets/Textures/Atlas/";
    static string assetListPrefabPath = "Assets/Resources/Prefab/AssetsList/";
    [MenuItem("Tool/生成所有AssetList")]
    public static void GenAllAssetList()
    {
        string[] dirs = Directory.GetDirectories(rootPath);
        for (int i = 0; i < dirs.Length; ++i)
        {
            string dirName = Path.GetFileName(dirs[i]);
            GenAssetsPrefab(dirs[i], dirName);
        }
    }

    public static void GenAssetsPrefab(string path, string assetsName)
    {
        string[] files = Directory.GetFiles(path, "*.png");
        GameObject prefab = GetAssetsPrefab(assetsName);
        AssetsList list = prefab.GetComponent<AssetsList>();
        list.list.Clear();

        for (int i = 0; i < files.Length; ++i)
        {
            Sprite s = AssetDatabase.LoadAssetAtPath<Sprite>(files[i]);
            if (s != null)
            {
                list.list.Add(s);
            }
        }
        EditorUtility.SetDirty(prefab);
        AssetDatabase.SaveAssets();

        Debug.Log("GenPrefabOK:"+prefab.name);
    }

    public static GameObject GetAssetsPrefab(string name)
    {
        name = name.ToLower();
        GameObject o = null;
        string path = assetListPrefabPath + "assets_" + name + ".prefab";
        if (!File.Exists(path))
        {
            o = new GameObject("assets_" + name);
            o.AddComponent<AssetsList>();
            PrefabUtility.CreatePrefab(path, o);
            GameObject.DestroyImmediate(o);
        }

        o = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        return o;
    }
}
