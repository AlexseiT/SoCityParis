using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Transform _tr;
    private Animator _animator;
    [SerializeField] private float _walkSpeed = 3f;
    void Start()
    {
        _tr = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        float move = Input.GetAxis("Horizontal") * Time.deltaTime * _walkSpeed;
        transform.position += new Vector3(move, 0, 0);
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
