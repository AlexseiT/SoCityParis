using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Transform _tr;
    private Animator _animator;
    private Rigidbody2D _rb;
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _jumpForce;
    public static int orderLayerPlayer;
    private void Start()
    {
        _tr = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        orderLayerPlayer = GetComponent<SpriteRenderer>().sortingOrder;
    }

    private void Update()
    {
        _tr.position += new Vector3(InputTracking.moveHorizontal * Time.deltaTime * _walkSpeed, 0, 0);
        if (InputTracking.isJumpButtonPressed && CheckGround.isGround)
            Jump();
        CheckPlayerDirection(InputTracking.moveHorizontal);
    }

    private void Jump()
    {
        _rb.AddForce(new Vector2(0, _jumpForce));
    }

    private void CheckPlayerDirection(float move)
    {
        if (!Mathf.Approximately(move, 0))
        {
            _animator.SetFloat("Speed", Mathf.Abs(Mathf.Round(move)));
            Flip(move);
        }
    }

    private void Flip(float move)
    {
        transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
    }
}