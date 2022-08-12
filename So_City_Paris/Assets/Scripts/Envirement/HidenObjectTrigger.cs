using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Architecture.Player;


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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            StartCoroutine(SlowlyChangeColor(-1));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            StartCoroutine(SlowlyChangeColor(1));
        }
    }
    private IEnumerator SlowlyChangeColor(int sign)
    {
        _time = 0;
        while (_time < _timeForHiden)
        {
            _time+=Time.deltaTime;
            _color.color = new Color(1, 1, 1,(1-sign)/2 + sign * _time / _timeForHiden);
            yield return null;
        }        
    }
}
