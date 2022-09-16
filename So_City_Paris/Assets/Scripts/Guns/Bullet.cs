using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _directionMove;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;
    private float _timePassed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _directionMove = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer();
        MoveBullet();
    }
    void Timer()
    {
        _timePassed += Time.deltaTime;
        Debug.Log(_timePassed);
        if (_timePassed > _timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
    
    void MoveBullet() => _rb.velocity = _directionMove * _speed;
}
