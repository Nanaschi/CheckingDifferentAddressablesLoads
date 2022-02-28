using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ReferenceSpawner : MonoBehaviour, ISpawnableProvider
{
    [SerializeField] private SetOfTileItems _setOfTileItems;
    [SerializeField] private UIReferenceController _uiReferenceController;
    private void Awake()
    {
        _uiReferenceController.RemoteReference.onClick.AddListener(InstantiateContent);
        _uiReferenceController.RemoteInstantiate.onClick.AddListener(InstantiateAssetReference);
        _uiReferenceController.RemoteUnload.onClick.AddListener(InstantiateAssetReferenceRemotely);
    }

    public void InstantiateContent()
    {
        Instantiate(_setOfTileItems.Items[0].ModelItem.ContentModel,  Vector3.zero, Quaternion.identity);
    }

    public async void InstantiateAssetReference()
    {
        Instantiate(await _setOfTileItems.Items[0].ModelItem.GetObjectFromReference(),
            new Vector3(-3.5f, 0, 0), Quaternion.identity);
    }    
    
    public async void InstantiateAssetReferenceRemotely()
    {
        Instantiate(await _setOfTileItems.Items[1].ModelItem.GetObjectFromReference(),
            new Vector3(-11, 0, 0), Quaternion.identity);
    }
}
