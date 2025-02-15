using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Enemy : MonoBehaviour 
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }

    public void Init(Vector3 direction)
    {
        SetDirection(direction);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetDirection(Vector3 direction)
    {
        _mover.SetDirection(direction);
    }
}