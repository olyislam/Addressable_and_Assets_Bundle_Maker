using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Addressable
{

    public class AddressableLoader
    {
        /// <summary>
        /// return assets resources location  By  Assets Name OR Lable
        /// </summary>
        /// <param name="nameORlabel"> Assets Label </param>
        /// <param name="loadedlocation">returned Assets resource Locations </param>
        /// <returns></returns>
        public static async Task GetLocations(string nameORlabel, IList<IResourceLocation> loadedlocation)
        {
            var unLoadedLocation = await Addressables.LoadResourceLocationsAsync(nameORlabel).Task;
            foreach (var location in unLoadedLocation)
            {
                loadedlocation.Add(location);
            }
        }

        /// <summary>
        /// Load assets from location list
        /// </summary>
        /// <typeparam name="T"> returned object type </typeparam>
        /// <param name="loadedLocation"> Resorces Location collection </param>
        /// <param name="createObjects"> Return object collection from resorce location </param>
        /// <returns></returns>
        public static async Task LoadObjects<T>(IList<IResourceLocation> loadedLocations, List<T> createObjects) where T : Object
        {
            foreach (var location in loadedLocations)
            {
                var obj = await Addressables.InstantiateAsync(location).Task as T;
                createObjects.Add(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">returned object type</typeparam>
        /// <param name="lableORName">Asset Nmae or Label</param>
        /// <param name="createedObject">Return object collection from resorce location</param>
        /// <returns></returns>
        public static async Task LoadObjects<T>(string lableORName, List<T> loadededObject) where T : Object
        {
            var locations = await Addressables.LoadResourceLocationsAsync(lableORName).Task;

            foreach (var location in locations)
            {
                loadededObject.Add(await Addressables.InstantiateAsync(location).Task as T);
            }
        }


        /// <summary>
        /// release object
        /// </summary>
        /// <param name="asset"></param>
        public static void Release(GameObject asset) => Addressables.Release(asset);

        /// <summary>
        /// change Scene by addressable name
        /// </summary>
        /// <param name="AddressableName"></param>
        public static void LoadScene(string AddressableName) => Addressables.LoadSceneAsync(AddressableName);


        /// <summary>
        /// add new Scene with current scene
        /// </summary>
        /// <param name="AddressableName"> addressable name that saved in under addressable grup</param>
        /// <param name="LoadedScene">return sceneinstance that added with current scene</param>
        public static void AddScene(string AddressableName, System.Action<AsyncOperationHandle<SceneInstance>> LoadedScene ) => 
                                    Addressables.LoadSceneAsync(AddressableName, LoadSceneMode.Additive).Completed += LoadedScene;

        /// <summary>
        /// remove sub scene that running with current main scene
        /// </summary>
        /// <param name="scene">running sub scene</param>
        /// <param name="UnLoadedScene"> removed scene</param>
        public static void RemoveScene(SceneInstance scene, System.Action<AsyncOperationHandle<SceneInstance>> UnLoadedScene) =>
                                       Addressables.UnloadSceneAsync(scene).Completed += UnLoadedScene;





        public static async Task CreateAssetAddToList<T>(AssetReference reference, List<T> completeObjs) where T : Object
        {
            completeObjs.Add(await reference.InstantiateAsync().Task as T);
        }

        public static async Task LoadObjects<T>(List<AssetReference> references, List<T> completeObjs) where T : Object
        {
            foreach (AssetReference reference in references)
            {
                completeObjs.Add(await reference.InstantiateAsync().Task as T);
            }
        }


    }
}