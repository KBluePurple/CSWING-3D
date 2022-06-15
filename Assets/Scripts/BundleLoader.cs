using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BundleLoader : MonoSingleton<BundleLoader>
{
    private string _bundleAdress;
    private UnityWebRequest _bundleRequest;
    private AssetBundle _bundle;
    private void Awake()
    {
        StartCoroutine(LoadBundle());
    }

    private IEnumerator LoadBundle()
    {
        _bundleAdress = "file:///" + Application.dataPath + "/Bundles/sprites";
        _bundleRequest = UnityWebRequestAssetBundle.GetAssetBundle(_bundleAdress, 0);
        yield return _bundleRequest.SendWebRequest();
        _bundle = DownloadHandlerAssetBundle.GetContent(_bundleRequest);
        Debug.Log("번들 로딩 완료!");
    }

    public Sprite FindAsset(string assetName)
    {
        return _bundle.LoadAsset<Sprite>(assetName);
    }
}
