using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _spawnsNumber;
    [SerializeField] private float _spawnSpacing;

    private GameObject[] _spawns;
    private float _timer;

    private void Awake()
    {
        _timer = _spawnTime;
        _spawns = new GameObject[_spawnsNumber];

        for (int i = 0; i < _spawns.Length; i++)
        {
            _spawns[i] = new GameObject($"Spawn {i + 1}");
            _spawns[i].transform.Translate(i * _spawnSpacing, 0, 0);
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = _spawnTime;

            Instantiate(_template, _spawns[Random.Range(0, _spawns.Length)].transform);
        }
    }
}