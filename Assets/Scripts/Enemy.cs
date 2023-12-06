using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void Update()
    {
        if (_direction != null)
        {
            transform.Translate(_speed * Time.deltaTime * _direction);
        }
    }

    public void SetDirection(Vector3 direction) => _direction = direction;
}