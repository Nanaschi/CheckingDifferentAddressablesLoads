using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReferenceController : MonoBehaviour
{
    [SerializeField] private Button _contentToInstantiate;
    [SerializeField] private Button _referenceToInstantiate;
    [SerializeField] private Button _referenceToInstantiateRemotely;

    public Button ReferenceToInstantiateRemotely
    {
        get => _referenceToInstantiateRemotely;
        set => _referenceToInstantiateRemotely = value;
    }

    public Button ReferenceToInstantiate
    {
        get => _referenceToInstantiate;
        set => _referenceToInstantiate = value;
    }

    public Button ContentToInstantiate
    {
        get => _contentToInstantiate;
        set => _contentToInstantiate = value;
    }
}
