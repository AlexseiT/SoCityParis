using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidenObjectTrigger : MonoBehaviour
{
    [SerializeField] GameObject _objectOuter;
    [SerializeField] float _timeForHiden = 1f;
    float _time = 0;
    SpriteRenderer _color;
    private void Start()
    {
        _color = _objectOuter.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MoveController player))
        {
            _time+=Time.deltaTime;
            _color.color = new Color(1, 1, 1, 1 - _time/_timeForHiden);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _time = 0;
        if (collision.TryGetComponent(out MoveController player))
        {
            _color.color = new Color(1, 1, 1, 1);
        }
    }
}
