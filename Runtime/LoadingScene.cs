using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlchemyBow.LoadingScenes
{
    /// <summary>
    /// Provides an interface to control loading scenes.
    /// </summary>
    public static class LoadingScene
    {
        private static Tuple<Scene, GameObject> sceneAndContent;

        /// <summary>
        /// Returns <c>true</c> if there is any active loading scene; otherwise, <c>false</c>.
        /// </summary>
        public static bool LoadingSceneActive => sceneAndContent != null;

        /// <summary>
        /// Returns the content of the active loading scene or <c>null</c>.
        /// </summary>
        public static GameObject ActiveSceneContent => sceneAndContent?.Item2;

        /// <summary>
        /// Ensures the loading scene is active.
        /// </summary>
        /// <param name="loadingSceneContentPrefabName">The name of the loading scene content prefab under the path <c>'LoadingSceneContents\...'</c> in the <c>Resources</c> folder.</param>
        /// <remarks>You can call this method multiple times, but it will only work the first time, until the next time the loading scene is disabled.</remarks>
        public static void EnsureActive(string loadingSceneContentPrefabName)
        {
            if (!LoadingSceneActive)
            {
                var scene = SceneManager.CreateScene("AlchemyBow_LoadingScene", new CreateSceneParameters(LocalPhysicsMode.None));
                string resourcesPath = $"LoadingSceneContents/{loadingSceneContentPrefabName}";
                var sceneContentPrefab = Resources.Load<GameObject>(resourcesPath);
                GameObject sceneContent;
                if (sceneContentPrefab != null)
                {
                    sceneContent = GameObject.Instantiate(sceneContentPrefab);
                }
                else
                {
                    Debug.LogError($"There is no prefab of the loading scene content at `Resources/{resourcesPath}`.");
                    sceneContent = new GameObject("DummyLoadingSceneContent");
                }
                SceneManager.MoveGameObjectToScene(sceneContent, scene);
                sceneAndContent = new Tuple<Scene, GameObject>(scene, sceneContent);
            }
        }

        /// <summary>
        /// Ensures the loading scene is inactive.
        /// </summary>
        public static void EnsureInactive()
        {
            if (LoadingSceneActive)
            {
                sceneAndContent.Item2.SetActive(false);
                SceneManager.UnloadSceneAsync(sceneAndContent.Item1);
                sceneAndContent = null;
            }
        }
    } 
}