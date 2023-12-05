using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _spawnsNumber;
    [SerializeField] private float _spawnSpacing;

    private GameObject[] _spawns;

    private void Awake()
    {
        _spawns = new GameObject[_spawnsNumber];

        for (int i = 0; i < _spawns.Length; i++)
        {
            _spawns[i] = new GameObject($"Spawn {i + 1}");
            _spawns[i].transform.SetLocalPositionAndRotation(transform.localPosition, transform.localRotation);
            _spawns[i].transform.transform.Translate(i * _spawnSpacing, 0, 0);
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn(_spawnTime));
    }

    private IEnumerator Spawn(float cooldown)
    {
        WaitForSeconds timer = new(cooldown);

        while (true)
        {
            Instantiate(_template, _spawns[Random.Range(0, _spawns.Length)].transform);

            yield return timer;
        }
    }
}