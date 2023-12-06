using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Enemy _template;
    private Quaternion _direction;

    public void Spawn()
    {
        if (_template != null && _direction != null)
        {
            Instantiate(_template, transform.position, _direction);
        }
    }

    public void SetTemplate(Enemy template) => _template = template;

    public void SetDirection(Quaternion direction) => _direction = direction;
}