using UnityEngine;

public class PipeMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;

    private float _randY;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ResetPipePosition();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + Vector2.left * _speed * Time.fixedDeltaTime);
    }

    private Vector2 GetRandomPosition()
    {
        _randY = Random.Range(-18, -4);
        return new Vector2(12, _randY);
    }

    private void ResetPipePosition()
    {
        if (transform.position.x <= -10.5)
            transform.position = GetRandomPosition();
    }
}
