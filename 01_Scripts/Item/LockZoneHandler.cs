using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockZoneHandler : MonoBehaviour
{
    private ItemSpawnHandler _item;

    private void Awake()
    {
        _item = GetComponent<ItemSpawnHandler>();
    }

}
