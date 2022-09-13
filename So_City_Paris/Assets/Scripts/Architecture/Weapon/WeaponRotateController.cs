using UnityEngine;
using UnityEngine.UIElements;

internal class WeaponRotateController : MonoBehaviour
{
    [SerializeField] private Transform _shouldTr;
    private bool _checkFlip = true;

    private void Update()
    {

        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _shouldTr.position;
        float length = (transform.position - _shouldTr.position).magnitude;
        Vector3 newHandCoordinate = new Vector3(GetAxis(length, dir.x,dir.y), GetAxis(length, dir.y,dir.x), 0)+_shouldTr.position;
        transform.position = newHandCoordinate;
        Vector3 vectorPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        Rotate();
    }
    
    private float GetAxis(float length, float val1, float val2)
    {
        return (float)length * val1 / (Mathf.Sqrt(val1 * val1 + val2 * val2));
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