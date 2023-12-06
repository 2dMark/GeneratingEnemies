using System.Collections;
using UnityEngine;

public class SpawnersController : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _spawnTime;

    private Spawner[] _spawners;

    private void Awake()
    {
        _spawners = gameObject.GetComponentsInChildren<Spawner>();

        for (int i = 0; i < _spawners.Length; i++)
        {
            _spawners[i].SetTemplate(_template);
            _spawners[i].SetDirection(RandomRotation());
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds time = new(_spawnTime);

        while (true)
        {
            _spawners[Random.Range(0, _spawners.Length)].Spawn();

            yield return time;
        }
    }

    private Quaternion RandomRotation()
    {
        float _minRotation = -180;
        float _maxRotation = 180;

        return new Quaternion(Random.Range(_minRotation, _maxRotation), Random.Range(_minRotation, _maxRotation), Random.Range(_minRotation, _maxRotation), 0);
    }
}