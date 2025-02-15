using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private const float SpeedCoefficient = 50f;

    private float _speed = 5f;

    private Rigidbody _rigidbody;
    private Vector3 _direction = new Vector3();

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        if (_rigidbody == null)
            return;

        SetRotationToDirection();

        _direction = _direction.normalized;

        _rigidbody.velocity = new Vector3(
            _speed * _direction.x * SpeedCoefficient * Time.fixedDeltaTime, 
            _rigidbody.velocity.y, 
            _speed * _direction.z * SpeedCoefficient * Time.fixedDeltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void SetRotationToDirection()
    {
        transform.rotation = Quaternion.Euler(_direction);
    }
}
