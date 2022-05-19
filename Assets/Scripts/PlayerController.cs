using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private Animator _animator;

    [SerializeField] private float _jumpPower;
    [SerializeField] private float _turningPower;
    private const float MAX_ANGLE_OF_ROTATION = 25;
    private const float MIN_ANGLE_OF_ROTATION = -90;
    
    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            Jump();

        RotateBird();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe") || other.CompareTag("Ground"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Jump()
    {
        _rigidBody2D.velocity = new Vector2(0f, _jumpPower);

        ApplyRotation(MAX_ANGLE_OF_ROTATION);

        _animator.SetBool("IsFall", false);

        _animator.SetTrigger("Jump");
    }

    private void RotateBird()
    {
        float angleOfRotationZ = _rigidBody2D.velocity.y * _turningPower;

        //if(_angleOfRotationZ < 25 && _angleOfRotationZ > -90)
        //transform.eulerAngles = new Vector3(0, 0, _angleOfRotationZ);

        if (angleOfRotationZ < MAX_ANGLE_OF_ROTATION && angleOfRotationZ > MIN_ANGLE_OF_ROTATION)
        {
            ApplyRotation(angleOfRotationZ);

            if(_rigidBody2D.velocity.y < 0f)
                _animator.SetBool("IsFall", true);
        }
    }

    private void ApplyRotation(float angleOfRotationZ)
    {
        transform.eulerAngles = new Vector3(0, 0, angleOfRotationZ);
    }
}