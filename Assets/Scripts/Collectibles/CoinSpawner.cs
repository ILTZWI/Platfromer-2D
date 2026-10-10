using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Coin _prefabMoney;
    [SerializeField] CoinDetector _coinDetector;
    [SerializeField] Transform[] _spawnPositions;

    private int _defaultCapacity = 1;
    private int _maxSize = 1;

    private float _delay = 3f;

    private bool _isSpawned = true;

    private ObjectPool<Coin> _coinPool;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);

        _coinPool = new ObjectPool<Coin>
            (
                createFunc: () => Instantiate(_prefabMoney),
                actionOnGet: (coin) => GetCoin(coin),
                actionOnRelease: (coin) => ReleaseCoin(coin),
                actionOnDestroy: (coin) => Destroy(coin),
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
            );
    }

    private void Start()
    {
        StartDelaySpawnCoin();
    }

    private void OnEnable()
    {
        _coinDetector.DetectCoin += OnDetected;
    }

    private void OnDisable()
    {
        _coinDetector.DetectCoin -= OnDetected;
    }

    private void SpawnCoin()
    {
        Coin coin = _coinPool.Get();
        _isSpawned = false;
    }

    private void OnDetected(Coin coin)
    {
        _coinPool.Release(coin);
        _isSpawned = true;
        StartDelaySpawnCoin();
    }

    private void GetCoin(Coin coin)
    {
        foreach (Transform position in _spawnPositions)
        {
            Vector2 spawnPosition = position.position;
            coin.transform.position = spawnPosition;

            coin.gameObject.SetActive(true);
        }
    }

    private void ReleaseCoin(Coin coin)
    {
        coin.gameObject.SetActive(false);
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
