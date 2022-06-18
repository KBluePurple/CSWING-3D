using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BundleLoader : MonoSingleton<BundleLoader>
{
    private string _bundleAddress;
    private UnityWebRequest _bundleRequest;
    private AssetBundle _bundle;
    private void Awake()
    {
        if(_bundleAddress!=null)
        {
            StartCoroutine(LoadBundle());
        }
    }

    private IEnumerator LoadBundle()
    {
        _bundleAddress = "file:///" + Application.dataPath + "/Bundles/sprites";
        _bundleRequest = UnityWebRequestAssetBundle.GetAssetBundle(_bundleAddress, 0);
        yield return _bundleRequest.SendWebRequest();
        _bundle = DownloadHandlerAssetBundle.GetContent(_bundleRequest);
        Debug.Log("���� �ε� �Ϸ�!");
    }

    public Sprite FindAsset(string assetName)
    {
        
        return _bundle.LoadAsset<Sprite>(assetName);
    }
}
