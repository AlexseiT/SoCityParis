using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Architecture.Player;

[RequireComponent(typeof(PlatformEffector2D))]
public class PlatformDown : MonoBehaviour
{
    [SerializeField] private float _timeRemovePlatform;

    private PlatformEffector2D _platfoemEffector;

    private void Start()
    {
        _platfoemEffector = GetComponent<PlatformEffector2D>();
    }

    public void RemoveSurfaceArc ()
    {
        StartCoroutine(RemoveSurfaceArcCoroutine());
    }

    private IEnumerator RemoveSurfaceArcCoroutine()
    {
        float time = 0;
        while (time < _timeRemovePlatform)
        {
            time += Time.deltaTime;
            _platfoemEffector.surfaceArc = 0;
            yield return null;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    { 
        if (collision.gameObject.TryGetComponent<Player>(out Player Player))
        {
            _platfoemEffector.surfaceArc = 180;
        }
    }
}
