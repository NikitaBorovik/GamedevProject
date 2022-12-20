using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressableResolver : MonoBehaviour
{
    [SerializeField]
    private AssetReference christmasTreeAssetReference;
    
    private GameObject christmasTree;

    private void Awake()
    {
        Addressables.InitializeAsync().Completed += (handle) =>
        {
            christmasTreeAssetReference.InstantiateAsync().Completed += (go) =>
            {
                christmasTree = go.Result;
                christmasTree.transform.position = new Vector3(0, 25, 0);
            };

        };
    }
    private void OnDestroy()
    {
        Addressables.ReleaseInstance(christmasTree);
    }
}
