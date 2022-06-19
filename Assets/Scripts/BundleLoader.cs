using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class BundleLoader : MonoSingleton<BundleLoader>
{
    public Sprite FindAsset(string assetName)
    {
        return Resources.Load<Sprite>(assetName);
    }
}
