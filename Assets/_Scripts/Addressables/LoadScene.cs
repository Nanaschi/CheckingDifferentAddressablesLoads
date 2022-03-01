using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadScene: MonoBehaviour
{
    public void LoadSceneAsync()
    {
        Addressables.LoadSceneAsync("Various Cars");
    }
}