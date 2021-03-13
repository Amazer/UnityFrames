using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AtlasImporter : AssetPostprocessor
{
    void OnPostprocessTexture(Texture2D texture)
    {
        string lowerCaseAssetPath = assetPath.ToLower();
        if(!lowerCaseAssetPath.Contains("assets/textures/atlas/"))
        {
            return;
        }
        TextureImporter importer = (TextureImporter)assetImporter;
        int atlasIndex = lowerCaseAssetPath.IndexOf("atlas/") + 6;
        int lastSplashIndex = lowerCaseAssetPath.LastIndexOf('/');
        string dirName = lowerCaseAssetPath.Substring(atlasIndex, lastSplashIndex - atlasIndex);
        string packingTag = "sprite_" + dirName;

        importer.textureType = TextureImporterType.Sprite;
        importer.spriteImportMode = SpriteImportMode.Single;
        importer.spritePackingTag = packingTag;
        importer.mipmapEnabled = false;

        TextureImporterSettings textureSettings = new TextureImporterSettings();
        importer.ReadTextureSettings(textureSettings);
        textureSettings.spriteMeshType = SpriteMeshType.FullRect;
        textureSettings.spriteExtrude = 0;

        importer.SetTextureSettings(textureSettings);

        importer.sRGBTexture = true;
        importer.alphaSource = TextureImporterAlphaSource.FromInput;
        importer.alphaIsTransparency = false;
        importer.wrapMode = TextureWrapMode.Clamp;
        importer.filterMode = FilterMode.Point;


    }
}
