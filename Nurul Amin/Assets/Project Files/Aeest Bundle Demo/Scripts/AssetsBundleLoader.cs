using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class AssetsBundleLoader : MonoBehaviour
{
#pragma warning disable 649
    [Header("UI References")]
    [SerializeField] private Button DownloadAndPlayButton;
    [SerializeField] private Slider DownloadStatus;


    [SerializeField, Header("Not Use This Fild For Online Server")] protected string BundleName;//last file name with extension in assets bundle data

    [SerializeField, Header("Server URL")] protected string BundleUri;
    public static AssetBundle assetBundle;

#pragma warning restore


    private void Start()
    {
        DownLoadProgress(0.2f);
        DownloadAndPlayButton.onClick.RemoveAllListeners();
        DownloadAndPlayButton.onClick.AddListener(StartDownload);
    }


    public void StartDownload()
    {
        StartCoroutine(Download());
    }


    protected IEnumerator Download()
    {
        string uri = BundleUri + BundleName; // Path to Asset Bundle file

        using (UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(uri, 0, 0))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("AssetBundle Error: " + www.error);
                yield break;
            }

            while (!www.isDone)
            {
                DownloadAndPlayButton.interactable = false;
                DownLoadProgress(www.downloadProgress);

                yield return null;
            }
            DownloadAndPlayButton.interactable = true;

            // Get downloaded Asset Bundle
            assetBundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(www);

            if (assetBundle.GetAllScenePaths().Length > 0)
                LoadScene(0);


            assetBundle.Unload(false);
        }
    }


    // Load Scene From Assets Bundle
    protected void LoadScene(int indx)
    {
        string[] scenesName = assetBundle.GetAllScenePaths();
        SceneHandeller.LoadScene(scenesName[indx]);
    }

    // Load All Assets from Assets Bundle
    protected void LoadAllAssets()
    {
        string[] assetsName = assetBundle.GetAllAssetNames();
        foreach (var name in assetsName)
        {
            GameObject playerPrefab = assetBundle.LoadAsset<GameObject>(name);
            Instantiate(playerPrefab);
        }
    }


    //Show download Status on ui
    public void DownLoadProgress(float progress)
    {
        Debug.Log("P "+progress);
        DownloadStatus.value = progress;
    }

    }
