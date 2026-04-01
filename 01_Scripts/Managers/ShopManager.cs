using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private ItemSO[] _itemSO;
    [SerializeField] private GameObject _itemPrefab;
    private Transform _contentArea;

    private bool _hasExecuted;

    private void Awake()
    {
        _contentArea = GameObject.Find("Content").transform;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (GameManager.Instance.IsGround.Value && !_hasExecuted)
        {
            SpawnGroundItem();
            _hasExecuted = true;
        }
        else if (!GameManager.Instance.IsGround.Value && _hasExecuted)
        {
            SpawnCaveItem();
            _hasExecuted = false;
        }
    }

    private void SpawnGroundItem()
    {
        foreach (Transform child in _contentArea.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 1; i++)
        {
            GameObject newItemObj = Instantiate(_itemPrefab, _contentArea);

            ItemSpawnerData newItem = newItemObj.GetComponent<ItemSpawnerData>();
            newItem.SetSpawnerData(_itemSO[i]);
        }
    }

    private void SpawnCaveItem()
    {
        foreach (Transform child in _contentArea.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 1; i < _itemSO.Length; i++)
        {
            GameObject newItemObj = Instantiate(_itemPrefab, _contentArea);

            ItemSpawnerData newItem = newItemObj.GetComponent<ItemSpawnerData>();
            newItem.SetSpawnerData(_itemSO[i]);
        }
    }
}
