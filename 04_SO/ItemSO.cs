using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/Item/ItemSpawnerData")]
public class ItemSO : ScriptableObject
{
    public Sprite itemIcon;
    public Sprite itemObjSp;
    public int price;
    public PoolingType itemType;
}
