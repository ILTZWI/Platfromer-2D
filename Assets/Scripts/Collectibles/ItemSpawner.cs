using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]private Item _prefabItem;
    [SerializeField] private Transform[] _spawnPositions;

    private int _defaultCapacity = 1;
    private int _maxSize = 1;

    private float _delay = 3f;

    private bool _isSpawned = true;

    private ObjectPool<Item> _itemPool;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);

        _itemPool = new ObjectPool<Item>
            (
                createFunc: () => Instantiate(_prefabItem),
                actionOnGet: (item) => GetItem(item),
                actionOnRelease: (item) => ReleaseCoin(item),
                actionOnDestroy: (item) => Destroy(item.gameObject),
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
            );
    }

    private void Start()
    {
        StartDelaySpawnCoin();
    }

    private void SpawnCoin()
    {
        Item item = _itemPool.Get();
        item.Encountered += OnEncountered;
        _isSpawned = false;
    }

    private void OnEncountered(Item item)
    {
        item.Encountered -= OnEncountered;
        _itemPool.Release(item);
        _isSpawned = true;
        StartDelaySpawnCoin();
    }

    private void GetItem(Item item)
    {
        foreach (Transform position in _spawnPositions)
        {
            Vector2 spawnPosition = position.position;
            item.transform.position = spawnPosition;

            item.gameObject.SetActive(true);
        }
    }

    private void ReleaseCoin(Item item)
    {
        item.gameObject.SetActive(false);
    }

    private void StartDelaySpawnCoin()
    {
        _coroutine = StartCoroutine(SpawnDelayedCoin());
    }

    private IEnumerator SpawnDelayedCoin()
    {
        if (_isSpawned)
        {
            yield return _wait;
            SpawnCoin();
        }
    }
}
