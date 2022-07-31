using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Transform _tr;
    private Animator _animator;
    private Rigidbody2D _rb;
    private bool _isJump;
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _jumpForce;
    private float _move;
    

    void Start()
    {
        _tr = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _move = Input.GetAxis("Horizontal");
        _tr.position += new Vector3(_move * Time.deltaTime * _walkSpeed, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround.isGround)
            Jump();
        CheckPlayerDirection(_move);
    }
    void Jump()
    {
        _rb.AddForce(new Vector2(0, _jumpForce));
    }
    #region
    //private IEnumerator JumpPositionCalculate() // My super jump which not working :(
    //{
    //    float expiredSeconds = 0f;
    //    float progress = 0f;
    //    Vector3 startPosition = _tr.position;
    //    do
    //    {
    //        expiredSeconds += Time.deltaTime;
    //        progress = expiredSeconds / _jumpDuration;
    //        _tr.position = new Vector3(_tr.position.x, startPosition.y + JumpCalculateY(expiredSeconds) * _jumpHeight);
    //        yield return null; 
    //    } while (!CheckGround.isGround);
    //}
    //float JumpCalculateY(float x)
    //{
    //    return (-1 * Mathf.Pow((x - 2), 2) + 4);
    //}
    #endregion
    void CheckPlayerDirection(float move)
    {
        if (!Mathf.Approximately(move, 0))
        {
            _animator.SetFloat("Speed", Mathf.Abs(Mathf.Round(move)));
            Flip(move);
        }
    }
    void Flip(float move)
    {
        transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
    }
}
