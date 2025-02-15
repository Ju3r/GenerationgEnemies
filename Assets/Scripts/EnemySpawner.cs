using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Vector3 _startAreaPosition;
    [SerializeField] private Vector3 _endAreaPosition;

    private float _delay = 2f;
    private bool _isSpawning = true;
    private float _zeroValueY = 0f;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private Enemy Spawn()
    {
        Enemy enemy = Instantiate(_prefab, GetRandomPosition(), Quaternion.identity);
        enemy.Init(GetRandomDirection());

        return enemy;
    }

    private IEnumerator Spawning()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_isSpawning)
        {
            Spawn();

            yield return wait;
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3();

        randomPosition.x = Random.Range(_startAreaPosition.x, _endAreaPosition.x);
        randomPosition.y = Random.Range(_startAreaPosition.y, _endAreaPosition.y);
        randomPosition.z = Random.Range(_startAreaPosition.z, _endAreaPosition.z);

        return randomPosition;
    }

    private Vector3 GetRandomDirection()
    {
        Vector3 randomDirection = new Vector3();

        randomDirection.x = Random.Range(_startAreaPosition.x, _endAreaPosition.x);
        randomDirection.y = _zeroValueY;
        randomDirection.z = Random.Range(_startAreaPosition.z, _endAreaPosition.z);

        return randomDirection;
    }
}