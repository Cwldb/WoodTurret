using ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : MonoBehaviour
{
    public int itemPrice;
    public Sprite itemIcon;
    public PoolingType itemType;
    public string itemName;
    public ItemSpawnHandler itemSpawnHandler;
    public Image spawnBlocker;

    public void SetData(Image blocker,ItemSpawnHandler itemSpawn,int price, Sprite icon, PoolingType type, string name)
    {
        spawnBlocker = blocker;
        itemSpawnHandler = itemSpawn;
        itemPrice = price;
        itemType = type;
        itemName = name;
        itemIcon = icon;
    }
}
