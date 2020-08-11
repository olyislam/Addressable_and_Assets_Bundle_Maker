using UnityEditor;
using UnityEngine;

namespace MenuItemAttribute
{
    public class CreateAssetBundles
    {

#if UNITY_EDITOR

        [MenuItem("Asset Bundle/Build AssetBundles")]
        static void BuildAllAssetBundles()
        {
            string ExportPath = "AssetBundles";
           
            /*if (!AssetDatabase.IsValidFolder(ExportPath)) {//check path is valid or not
                AssetDatabase.CreateFolder("Assets", "AssetBundles");
                UnityEngine.Debug.Log("<color=red> Export path does not exist.</color>  creating new path <color=green>'Assets/AssetBundles'</color>");
            }*/



            BuildPipeline.BuildAssetBundles(ExportPath, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);
        }

        [MenuItem("Asset Bundle/Clean Cache")]
        public static void CleanCache()
        {
            if (Caching.ClearCache())
            {
                Debug.Log("Successfully cleaned the cache.");
            }
            else
            {
                Debug.Log("Cache is being used.");
            }
        }


#endif
    }
    
}