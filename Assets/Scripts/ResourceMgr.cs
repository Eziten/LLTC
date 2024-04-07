using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMgr : SingleTon<ResourceMgr>
{

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/{path}");

        return Instantiate(prefab, parent);
    }
}
