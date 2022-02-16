using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;


[Serializable]
public class ModelItem
{

    [SerializeField] public GameObject ContentModel;
    
    [SerializeField] private AssetReference _modelReference;
    public AsyncOperationHandle<GameObject> AsyncOperationHandle { get; set; }
    public AssetReference ModelReference
    {
        get => _modelReference;
        set => _modelReference = value;
    }
    
    
    public async Task<GameObject> GetObjectFromReference() 
    {
        AsyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(_modelReference);
        var cachedModel = await AsyncOperationHandle.Task;
        return cachedModel;
    }
    
    public async Task<GameObject> InstantiateObjectFromReference()
    {
        var handle = Addressables.InstantiateAsync(_modelReference);
        var _model = await handle.Task;
        return _model;
    }
    
    public void ReleaseInstantiateObjectFromReference()
    {
        var handle = Addressables.ReleaseInstance(InstantiateObjectFromReference().Result);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*
    public async Task<GameObject> GetObjectFromReference()
    {
        if (string.IsNullOrEmpty(_modelReference.AssetGUID)) Debug.LogError("AssetGUID of the referenced GameObject is null");
        var handle = Addressables.LoadAssetAsync<GameObject>(_modelReference);
        var cachedModel = await handle.Task;
        return cachedModel;
    }

    

    */
    
    
    

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    

    public GameObject Model
    {
        get
        {
            Debug.Log("New get");
            return null;
        }

        set
        {
            
        }
    }
    
    
    
    /*
    protected async Task<GameObject> LoadInternal(AssetReference assetReference)
    {
        var handle = Addressables.LoadSceneAsync(assetReference);
        _model = await handle.Task;
        /*if (_model == null)
        {
            throw new NullReferenceException($"{typeof(T)} not loaded");
        }#1#

        return _model;
    }

    public Task<GameObject> Load()
    {
        return LoadInternal(_modelReference);
    }
    */
    
    
    
    
    
    
    


    
    
    
    /*public System.Object ReferenceGameObject
    {
        get => _modelReference.Asset as GameObject;
        set => value = _modelReference.Asset as GameObject;
    }*/


    public int Rotation;
    public float Scale = 1;
    public Vector3 Position;
    
    /*
    public GameObject ModelAlt
    {
        get
        {
           
            var _asyncOperationHandle =Addressables.LoadAssetAsync<GameObject>(_model).WaitForCompletion();
            return _asyncOperationHandle.gameObject;
        }
        set
        { 

        }
        
  
    }   
    */
    
    

}
