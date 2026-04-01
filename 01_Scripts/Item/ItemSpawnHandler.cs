using DG.Tweening;
using ObjectPooling;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSpawnHandler : MonoBehaviour, IPointerClickHandler
{
    public bool _isClick = false;

    [SerializeField] private GameObject _itemPrefab;
    private Transform _itemParent;
    private GameObject _itemObj;
    private Image _spawnBlocker;

    private RectTransform _content;
    private RectTransform _rect;

    private ItemSpawnerData _itemData;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _itemParent = GameObject.Find("ItemsParent").transform;
        _itemData = GetComponent<ItemSpawnerData>();
        _spawnBlocker = GameObject.Find("ShopBlocker").GetComponent<Image>();

        if (_spawnBlocker != null)
        {
            _spawnBlocker.enabled = false;
            Debug.Log("Ã£À½");
        }
    }

    private void Start()
    {
        _content = GameObject.Find("Content").GetComponent<RectTransform>();
        _content.offsetMin = new Vector2(0, _content.offsetMin.y);
        _content.offsetMax = new Vector2(337f,_content.offsetMax.y);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left || _isClick)
            return;

        if (GameManager.Instance.woodCurrency.Value >= _itemData.price)
        {
            _isClick = true;
            _spawnBlocker.enabled = true;
            _itemObj = Instantiate(_itemPrefab,_itemParent);
            ItemData newItem = _itemObj.GetComponent<ItemData>();
            newItem.SetData(_spawnBlocker, this, _itemData.price, _itemData.itemObj, _itemData.itemType, _itemData.name);
            EffectClick();
        }
    }

    private void EffectClick()
    {
        _rect.localScale = Vector3.one;
        _rect.DOPunchScale(Vector3.one * 0.1f, 0.1f);
    }
}
