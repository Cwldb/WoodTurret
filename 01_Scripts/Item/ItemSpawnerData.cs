using ObjectPooling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawnerData : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemPriceText;
    public Image shopItemIcon;
    public Image shopItemBg;
    public Sprite itemObj;
    public int price;
    public PoolingType itemType;

    private string objName;

    private void Awake()
    {
        shopItemIcon.GetComponentInChildren<Image>();
        shopItemBg = GetComponent<Image>();
    }

    private void Start()
    {
        shopItemIcon.preserveAspect = true;
    }

    public void SetSpawnerData(ItemSO itemSO)
    {
        _itemPriceText.text = $"{itemSO.price}";
        price = itemSO.price;
        objName = $"{itemSO.name}Spawner";
        itemType = itemSO.itemType;
        shopItemIcon.sprite = itemSO.itemIcon;
        itemObj = itemSO.itemObjSp;

        gameObject.name = objName;
    }
}
