using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManagers : MonoBehaviour
{
    [SerializeField] GameObject managersPrefab;

    void Awake()
    {
        var managers = FindObjectOfType<Managers>();
        if (managers == null)
        {
            Instantiate(managersPrefab);
        }
        Destroy(gameObject);
    }
}
