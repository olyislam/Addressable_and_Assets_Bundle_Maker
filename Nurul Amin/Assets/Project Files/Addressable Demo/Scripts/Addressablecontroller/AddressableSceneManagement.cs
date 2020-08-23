using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Addressable
{
    public class AddressableSceneManagement : MonoBehaviour
    {
        public enum SceneOperation{
            Change,
            Additive
        }

        [SerializeField] private bool UseUnityMessage; //handle unity start methode action
        [SerializeField] private SceneOperation Operation = SceneOperation.Change;
        [SerializeField] private string AddressableName;

        private void Start()
        {
            if (UseUnityMessage)
            { 
                Load();
            }
        }
        public void Load()
        {
            switch (Operation)
            {
                case SceneOperation.Change:
                    AddressableLoader.LoadScene(AddressableName);
                    break;
                case SceneOperation.Additive:
                    AddressableLoader.AddScene(AddressableName, LoadedCallback);
                    break;
            }
        }
       
        private void LoadedCallback(AsyncOperationHandle<SceneInstance> LoadedScene)
        {
            Debug.Log("Added");
        }
        
    }

}