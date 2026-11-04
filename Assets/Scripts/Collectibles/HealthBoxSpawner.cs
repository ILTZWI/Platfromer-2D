using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public class HealthBoxSpawner : MonoBehaviour
{
    [SerializeField] private HealthBox _prefabHealthBox;
    [SerializeField] private Transform[] _spawnPositions;

    private int _defaultCapacity = 1;
    private int _maxSize = 1;

    private float _delay = 3f;

    private bool _isSpawned = true;

    private ObjectPool<HealthBox> _healthBoxPool;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);

        _healthBoxPool = new ObjectPool<HealthBox>
            (
                createFunc: () => Instantiate(_prefabHealthBox),
                actionOnGet: (healthBox) => GethealthBox(healthBox),
                actionOnRelease: (healthBox) => ReleaseHealthBox(healthBox),
                actionOnDestroy: (healthBox) => Destroy(healthBox.gameObject),
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
            );
    }

    private void Start()
    {
        StartDelaySpawnHealthBox();
    }

    private void SpawnCoin()
    {
        HealthBox healthBox = _healthBoxPool.Get();
        healthBox.Encountered += OnEncountered;
        _isSpawned = false;
    }

    private void OnEncountered(HealthBox healthBox)
    {
        healthBox.Encountered -= OnEncountered;
        _healthBoxPool.Release(healthBox);
        _isSpawned = true;
        StartDelaySpawnHealthBox();
    }

    private void GethealthBox(HealthBox healthBox)
    {
        foreach (Transform position in _spawnPositions)
        {
            Vector2 spawnPosition = position.position;
            healthBox.transform.position = spawnPosition;

            healthBox.gameObject.SetActive(true);
        }
    }

    private void ReleaseHealthBox(HealthBox healthBox)
    {
        healthBox.gameObject.SetActive(false);
    }

    private void StartDelaySpawnHealthBox()
    {
        _coroutine = StartCoroutine(SpawnDelayedHealthBox());
    }

    private IEnumerator SpawnDelayedHealthBox()
    {
        if (_isSpawned)
        {
            yield return _wait;
            SpawnCoin();
        }
    }
}
