using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReferenceController : MonoBehaviour
{
    [SerializeField] private Button _remoteReference;
    [SerializeField] private Button _remoteInstantiate;
    [SerializeField] private Button _remoteUnload;
    [SerializeField] private Button _remoteDestroy;
    [SerializeField] private Button _remoteInstantiateAsync;
    [SerializeField] private Button _remoteReleaseInstance;
    [SerializeField] private Button _loadEmptyScene;
    [SerializeField] private Button _loadTheSameScene;

    public Button LoadEmptyScene
    {
        get => _loadEmptyScene;
        set => _loadEmptyScene = value;
    }

    public Button LoadTheSameScene
    {
        get => _loadTheSameScene;
        set => _loadTheSameScene = value;
    }

    public Button RemoteInstantiateAsync
    {
        get => _remoteInstantiateAsync;
        set => _remoteInstantiateAsync = value;
    }

    public Button RemoteReleaseInstance
    {
        get => _remoteReleaseInstance;
        set => _remoteReleaseInstance = value;
    }



    public Button RemoteDestroy
    {
        get => _remoteDestroy;
        set => _remoteDestroy = value;
    }

    public Button RemoteUnload
    {
        get => _remoteUnload;
        set => _remoteUnload = value;
    }

    public Button RemoteInstantiate
    {
        get => _remoteInstantiate;
        set => _remoteInstantiate = value;
    }

    public Button RemoteReference
    {
        get => _remoteReference;
        set => _remoteReference = value;
    }
}
