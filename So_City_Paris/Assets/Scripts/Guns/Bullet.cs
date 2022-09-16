using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _directionVelocity;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;
    private float _timePassed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _directionVelocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        SetVelocityBullet();
    }

    private void FixedUpdate()
    {
        Timer();
    }

    private void Timer()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed > _timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void SetVelocityBullet() => _rb.velocity = _directionVelocity * _speed;
}