using Addressable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AddScenes : MonoBehaviour
{
	public string addressToAdd;
	SceneInstance m_LoadedScene;
	bool m_ReadyToLoad = true;


	public string scenename;

	async void OnEnable()
	{
		DontDestroyOnLoad(this.gameObject);
		AddressableLoader.LoadScene(scenename);

	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			OnButtonClick();
	}

	void OnButtonClick()
	{
		if(string.IsNullOrEmpty(addressToAdd))
			Debug.LogError("Address To Add not set.");
		else
		{
			if (m_ReadyToLoad)
				AddressableLoader.AddScene(addressToAdd, OnSceneLoaded);
			else
				AddressableLoader.RemoveScene(m_LoadedScene, OnSceneUnloaded) ;
			
		}
	}

	void OnSceneUnloaded(AsyncOperationHandle<SceneInstance> obj)
	{
		if (obj.Status == AsyncOperationStatus.Succeeded)
		{
			m_ReadyToLoad = true;
			m_LoadedScene = new SceneInstance();
		}
		else
		{
			Debug.LogError("Failed to unload scene at address: " + addressToAdd);
		}
	}

	void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
	{
		if (obj.Status == AsyncOperationStatus.Succeeded)
		{
			m_LoadedScene = obj.Result;
			m_ReadyToLoad = false;
		}
		else
		{
			Debug.LogError("Failed to load scene at address: " + addressToAdd);
		}
	}

}
	
