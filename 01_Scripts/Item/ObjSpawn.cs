using ObjectPooling;
using Unity.VisualScripting;
using UnityEngine;

public class ObjSpawn : MonoBehaviour
{
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _blockSpawnMask;

    private bool _canSpawn;
    private ItemData _itemData;
    private SpriteRenderer _spriteRenderer;
    private SettingUI _setting;

    private Transform _parent;

    private RectTransform _content;

    private bool _deleteItem;

    private void Awake()
    {
        _parent = GameObject.Find("ItemsParent").transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _itemData = GetComponent<ItemData>();
        _setting = GameObject.Find("Setting").GetComponent<SettingUI>();
    }



    private void RemoveObj(bool prev, bool next)
    {
        DestroyItem();
    }

    private void Start()
    {
        GameManager.Instance.IsGround.OnValueChanged += RemoveObj;

        _spriteRenderer.sprite = _itemData.itemIcon;
        switch (_itemData.itemType)
        {
            case PoolingType.AerialTurrets:
                _spriteRenderer.transform.localScale = new Vector2(1.1f, 1.1f);
                break;
            case PoolingType.TowerNpc:
                _spriteRenderer.transform.localScale = new Vector2(0.8f, 0.8f);
                break;
            case PoolingType.TreeNpc:
                _spriteRenderer.transform.localScale = new Vector2(0.8f, 0.8f);
                break;
        }
        MoveItem();
    }

    private void Update()
    {
        print($"{GameManager.Instance.IsGround.Value}");
        if (!GameManager.Instance.IsActingCamera)
        {
            MoveItem();
            CheckItem();
            if (Input.GetMouseButtonDown(0) && GameManager.Instance.woodCurrency.Value >= _itemData.itemPrice)
                SpawnObj();
            else if (Input.GetMouseButtonDown(1))
                DestroyItem();
        }

    }

    private void DestroyItem()
    {
        if (_parent.childCount > 0)
        {
            _itemData.spawnBlocker.enabled = false;
            _itemData.itemSpawnHandler._isClick = false;
            GameManager.Instance.IsGround.OnValueChanged -= RemoveObj;
            Destroy(gameObject);
        }
    }

    private void MoveItem()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        if (_itemData.itemType == PoolingType.TreeNpc)
            transform.position = new Vector3(mousePos.x, -9, 0);
        else if (_itemData.itemType == PoolingType.RepairNpc || _itemData.itemType == PoolingType.TowerNpc)
            transform.position = new Vector3(mousePos.x, -35f, 0);
        else
            transform.position = new Vector3(mousePos.x, -32f, 0);
    }

    private void CheckItem()
    {
        bool isMouseOnLeft = Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0;

        transform.localRotation = isMouseOnLeft ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        Collider2D collider = Physics2D.OverlapBox(transform.position, _boxSize, 0, _blockSpawnMask);
        if (collider != null && !(_itemData.itemType == PoolingType.TreeNpc || _itemData.itemType == PoolingType.TowerNpc || _itemData.itemType == PoolingType.RepairNpc))
        {
            _canSpawn = true;
            _spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        }
        else
        {
            _canSpawn = false;
            _spriteRenderer.color = new Color(1, 1, 1, 0.8f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _boxSize);
    }

    private void SpawnObj()
    {
        if (!_canSpawn)
        {
            bool isMouseOnLeft = Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0;

            switch (_itemData.itemType)
            {
                case PoolingType.Tree:
                    GameObject tree = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    tree.transform.position = transform.position;
                    tree.transform.SetParent(null);
                    break;

                case PoolingType.AerialTurrets:
                    GameObject aerialTurret = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    aerialTurret.transform.position = transform.position;
                    aerialTurret.transform.SetParent(null);
                    aerialTurret.transform.localRotation = isMouseOnLeft ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
                    break;

                case PoolingType.GroundTurret:
                    GameObject groundTurret = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    groundTurret.transform.position = transform.position;
                    groundTurret.transform.SetParent(null);
                    groundTurret.transform.localRotation = isMouseOnLeft ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
                    break;
                
                case PoolingType.FlameThrower:
                    GameObject flameThrower = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    flameThrower.transform.position = transform.position;
                    flameThrower.transform.SetParent(null);
                    flameThrower.transform.localRotation = isMouseOnLeft ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
                    break;

                case PoolingType.Barricade:
                    GameObject barricade = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    barricade.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
                    barricade.transform.SetParent(null);
                    break;

                case PoolingType.Mortar:
                    GameObject mortar = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    mortar.transform.position = new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z);
                    mortar.transform.SetParent(null);
                    mortar.transform.localRotation = isMouseOnLeft ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
                    break;

                case PoolingType.LandMine:
                    GameObject landMine = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    landMine.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                    landMine.transform.SetParent(null);
                    break;

                case PoolingType.TreeNpc:
                    GameObject treeNpc = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    treeNpc.transform.position = transform.position;
                    treeNpc.transform.SetParent(null);
                    break;

                case PoolingType.TowerNpc:
                    GameObject towerNpc = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    towerNpc.transform.position = transform.position;
                    towerNpc.transform.SetParent(null);
                    break;

                case PoolingType.RepairNpc:
                    GameObject repairNpc = PoolManager.Instance.Pop(_itemData.itemType).gameObject;
                    repairNpc.transform.position = transform.position;
                    repairNpc.transform.SetParent(null);
                    break;
            }

            _itemData.spawnBlocker.enabled = false;
            _itemData.itemSpawnHandler._isClick = false;
            GameManager.Instance.AddWoodCurrency(-_itemData.itemPrice);
            Destroy(gameObject);
        }
    }

}
