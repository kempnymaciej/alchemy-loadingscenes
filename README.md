# AlchemyBow.LoadingScenes
**AlchemyBow.LoadingScenes** is a package that provides a very simple method of handling loading scenes.

### Installation
In your project:

Open a package manager window. (menu: Window > Package Manager).
Click the plus button and select "Add package from git URL...".
Paste the link: https://github.com/kempnymaciej/alchemy-loadingscenes.git#v1.0.0. (Replace 1.0.0 with version you would like to download.)
Alternatively, you can clone the package repository.

## Getting started
The setup is very simple. Create a prefab with the content of your loading scene (for example a game object with the `Camera` component attached, and some animated `Canvas` in a child object) and place it under `Resources\LoadingSceneContents\` somewhere in the `Assets` folder. 
(Example path: `Assets\Resources\LoadingSceneContents\MyLoadingSceneContentPrefabName`).

Now, you can use `LoadingScene.EnsureActive(string yourSceneContentPrefabName)` to enable the loading scene. Its content is created on the new additive scene at the exact moment the method is called.
To disable the loading scene use `LoadingScene.EnsureInactive()`. 
Note: You can call `LoadingScene.EnsureActive(...)` multiple times, but it will only work the first time, until the next time the loading scene is disabled.

If you want to interact with the loading scene (for example update some progress bar) use `LoadingScene.ActiveSceneContent`. The property returns the instance the active loading scene content prefab.
