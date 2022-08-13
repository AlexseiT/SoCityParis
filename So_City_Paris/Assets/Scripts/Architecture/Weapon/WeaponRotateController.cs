using UnityEngine;

internal class WeaponRotateController : MonoBehaviour
{
    [SerializeField] protected float rotateGun;

    private bool _checkFlip = true;

    private void Update()
    {
        Vector3 vectorPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(vectorPoint.y, vectorPoint.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + rotateGun);
        Rotate();
    }

    public void Rotate()
    {
        Vector3 vectorPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (_checkFlip && vectorPoint.x < 0 || !_checkFlip && vectorPoint.x > 0)
        {
            _checkFlip = !_checkFlip;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            scaler.y *= -1;
            transform.localScale = scaler;
        }
    }
}