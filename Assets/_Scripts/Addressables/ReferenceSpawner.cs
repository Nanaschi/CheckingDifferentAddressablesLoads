using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scripts.Gameplay.Tiles;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public partial class ReferenceSpawner : MonoBehaviour
{
    [SerializeField] private SetOfTileItems _setOfTileItems;
    [SerializeField] private UIReferenceController _uiReferenceController;
    List<GameObject> gameObjects;
    AsyncOperationHandle<SceneInstance> scene;
    
    private void Awake()
    {
        gameObjects = new List<GameObject>();
        _uiReferenceController.RemoteReference.onClick.AddListener(RemoteReferenceLoad);
        _uiReferenceController.RemoteInstantiate.onClick.AddListener(() => InstantiateAssetReference());
        _uiReferenceController.RemoteUnload.onClick.AddListener(UnloadReference);
        _uiReferenceController.RemoteDestroy.onClick.AddListener(DestroyReference);
        _uiReferenceController.RemoteInstantiateAsync.onClick.AddListener(InstantiateAsync);
        _uiReferenceController.RemoteReleaseInstance.onClick.AddListener(ReleaseInstance);
        _uiReferenceController.LoadEmptyScene.onClick.AddListener(LoadEmptyScene);
        _uiReferenceController.LoadTheSameScene.onClick.AddListener(LoadTheSameScene);
        _uiReferenceController.ClearCurrentScene.onClick.AddListener(ClearCurrentScene);
    }


    private async void RemoteReferenceLoad()
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            await tileItem.ModelItem.GetObjectFromReference();
            print(Addressables.GetDownloadSizeAsync(tileItem.ModelItem.ModelReference).Result/ (1024*1024) + " " + 
                  Addressables.GetDownloadSizeAsync("Various Cars").Result/ (1024*1024));
           
        }
    }

    private void InstantiateAssetReference()
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            var newGameObject = Instantiate(tileItem.ModelItem.CachedModel,
                new Vector3(-3.5f, 0, 0), Quaternion.identity);
            gameObjects.Add(newGameObject);
        }
    }
    
    private void UnloadReference()
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            print(Addressables.GetDownloadSizeAsync(tileItem.ModelItem.ModelReference).Result/ (1024*1024) + " " + 
                  Addressables.GetDownloadSizeAsync("Various Cars").Result/ (1024*1024));
            tileItem.ModelItem.ReleaseReference();
        }
    }
    private void DestroyReference()
    {
        foreach (var tileItem in gameObjects)
        {
            Destroy(tileItem);
        }
    }
    private async void InstantiateAsync()
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            print(Addressables.GetDownloadSizeAsync(tileItem.ModelItem.ModelReference).Result/ (1024*1024) + " " + 
                  Addressables.GetDownloadSizeAsync("Various Cars").Result/ (1024*1024));
             await tileItem.ModelItem.InstantiateObjectFromReference();
            
        }
    }
    
    private void ReleaseInstance()
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            print(Addressables.GetDownloadSizeAsync(tileItem.ModelItem.ModelReference).Result/ (1024*1024) + " " + 
                  Addressables.GetDownloadSizeAsync("Various Cars").Result/ (1024*1024));
            tileItem.ModelItem.ReleaseInstantiateObjectFromReference();
        }
    }
    
    private void LoadTheSameScene()
    {
       scene = Addressables.LoadSceneAsync("Various Cars");
    }

    private void LoadEmptyScene()
    {
        Addressables.LoadSceneAsync("Empty");
    }









    
    private void ClearCurrentScene()
    {
        print("clear");
        Addressables.UnloadSceneAsync(scene);
    }
    private void UnloadAll()
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            Addressables.ClearDependencyCacheAsync(tileItem.ModelItem.AsyncOperationHandle);
        }
    }
    
    
    
}