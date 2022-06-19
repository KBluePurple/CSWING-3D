using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BundleLoader : MonoSingleton<BundleLoader>
{
    private static string _bundleAddress;
    private static UnityWebRequest _bundleRequest;
    private static AssetBundle _bundle;

    private void Awake()
    {
        if(_bundle==null)
            StartCoroutine(LoadBundle());
    }

    private IEnumerator LoadBundle()
    {
        _bundleAddress = "file:///" + Application.dataPath + "/Bundles/sprites";
        _bundleRequest = UnityWebRequestAssetBundle.GetAssetBundle(_bundleAddress, 0);
        yield return _bundleRequest.SendWebRequest();
        _bundle = DownloadHandlerAssetBundle.GetContent(_bundleRequest);
        Debug.Log("번들 로딩 완료!");
    }

    public Sprite FindAsset(string assetName)
    {

        return _bundle.LoadAsset<Sprite>(assetName);
    }
}
