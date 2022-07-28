using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _mainCharacter;
    [SerializeField] private float _dy = 0;
    [SerializeField] private float _dx = 0;
    [SerializeField] private float _smooth = 0;
    private void Awake()
    {
        this.transform.position = new Vector3()
        {
            x = _mainCharacter.position.x - _dx,
            y = _mainCharacter.position.y - _dy,
            z = this.transform.position.z,
        };
    }
    void Update()
    {
        Vector3 target = new Vector3()
        {
            x = _mainCharacter.position.x - _dx,
            y = _mainCharacter.position.y - _dy,
            z = this.transform.position.z,
        };
        Vector3 pos  = Vector3.Lerp(this.transform.position, target, _smooth*Time.deltaTime);
        this.transform.position = pos;
    }
}
