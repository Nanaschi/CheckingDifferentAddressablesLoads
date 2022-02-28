using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scripts.Gameplay.Tiles;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

public class ReferenceSpawner : MonoBehaviour, ISpawnableProvider
{
    [SerializeField] private SetOfTileItems _setOfTileItems;
    [SerializeField] private UIReferenceController _uiReferenceController;
    
    private void Awake()
    {
        _uiReferenceController.RemoteReference.onClick.AddListener(() => RemoteReferenceLoad());
        _uiReferenceController.RemoteUnload.onClick.AddListener(UnloadReference);
        _uiReferenceController.RemoteDestroy.onClick.AddListener(DestroyReference);
        _uiReferenceController.RemoteInstantiateAsync.onClick.AddListener(InstantiateAsync);
        _uiReferenceController.RemoteReleaseInstance.onClick.AddListener(ReleaseInstance);
        _uiReferenceController.LoadEmptyScene.onClick.AddListener(LoadEmptyScene);
        _uiReferenceController.LoadTheSameScene.onClick.AddListener(LoadTheSameScene);
        _uiReferenceController.ClearCurrentScene.onClick.AddListener(ClearCurrentScene);
    }



    public async Task RemoteReferenceLoad()
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            print(Addressables.GetDownloadSizeAsync(tileItem.ModelItem.ModelReference).Result/ (1024*1024));
            print(Addressables.GetDownloadSizeAsync("Various Cars").Result/ (1024*1024));
            var _cachedObject = await tileItem.ModelItem.GetObjectFromReference();
            _uiReferenceController.RemoteInstantiate.onClick.AddListener(() => InstantiateAssetReference(_cachedObject));
        }
    }

    private void InstantiateAssetReference(GameObject gameObject)
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            Instantiate(gameObject,
                new Vector3(-3.5f, 0, 0), Quaternion.identity);
        }
    }
    
    private void UnloadReference()
    {
        foreach (var tileItem in _setOfTileItems.Items)
        {
            print(Addressables.GetDownloadSizeAsync(tileItem.ModelItem.ModelReference).Result/ (1024*1024));
            print(Addressables.GetDownloadSizeAsync("Various Cars").Result/ (1024*1024));
            tileItem.ModelItem.ReleaseReference();
        }
    }

    private void LoadTheSameScene()
    {
        throw new NotImplementedException();
    }

    private void LoadEmptyScene()
    {
        throw new NotImplementedException();
    }

    private void ReleaseInstance()
    {
        throw new NotImplementedException();
    }

    private void InstantiateAsync()
    {
        throw new NotImplementedException();
    }

    private void DestroyReference()
    {
        throw new NotImplementedException();
    }



    
    private void ClearCurrentScene()
    {
     
    }
    
}
