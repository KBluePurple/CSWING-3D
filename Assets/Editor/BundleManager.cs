using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
public class BundleManager : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DownLoadAndChase());
    }
    IEnumerator DownLoadAndChase()
    {
        while (!Caching.ready)
            yield return null;
        // ���¹����� ĳ�ÿ� ������ �ε��ϰ�, ������ �ٿ�ε��Ͽ� ĳ�������� �����մϴ�.
        AssetBundle.LoadFromFile("Assets/Bundles").LoadAllAssets();
    }

    [MenuItem("Tools/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/Bundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
