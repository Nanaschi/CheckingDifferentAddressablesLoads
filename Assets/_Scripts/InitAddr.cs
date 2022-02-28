using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InitAddr : MonoBehaviour
{
public void Start()
{
    Addressables.LoadSceneAsync("Various Cars");
}
}
