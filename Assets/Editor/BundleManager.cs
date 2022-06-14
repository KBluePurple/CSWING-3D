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
        // 에셋번들을 캐시에 있으면 로드하고, 없으면 다운로드하여 캐시폴더에 저장합니다.
        AssetBundle.LoadFromFile("Assets/Bundles").LoadAllAssets();
    }

    [MenuItem("Tools/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/Bundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
