using System;
using System.Collections;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Transform _tr;
    private Animator _animator;
    private Rigidbody2D _rb;
    private bool _isJump;
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private int _jumpHeight;

    void Start()
    {
        _tr = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal") * Time.deltaTime * _walkSpeed;
        transform.position += new Vector3(move, 0, 0);
        CheckPlayerDirection(move);
        if (_isJump && CheckGround.isGround)
        {
            Jump();
            _isJump = false;
        }
    }
    void Jump()
    {
        StartCoroutine(JumpPositionCalculate());
    }
    private IEnumerator JumpPositionCalculate() // My super jump which not working :(
    {
        float expiredSeconds = 0f;
        float progress = 0f;
        Vector3 startPosition = _tr.position;
        do
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / _jumpDuration;
            _tr.position = new Vector3(_tr.position.x, startPosition.y + _yAnimation.Evaluate(progress) * _jumpHeight);
            yield return new WaitForFixedUpdate(); 
        } while (!CheckGround.isGround && progress<0.42f);
    }
    void CheckPlayerDirection(float move)
    {
        if (!Mathf.Approximately(move, 0))
        {
            _animator.SetFloat("Speed", Mathf.Abs(Mathf.Round(move * 1000)));
            Flip(move);
        }
    }
    void Flip(float move)
    {
        transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
    }
}
