using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDown : MonoBehaviour
{
    private PlatformEffector2D _platfoemEffector;
    private void Start()
    {
        _platfoemEffector = GetComponent<PlatformEffector2D>();
    }
    private void Update()
    {
        if (InputTracking.moveVertical<0)
        {
            _platfoemEffector.surfaceArc = 0;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<MoveController>(out MoveController Player))
        {
            _platfoemEffector.surfaceArc = 180;
        }

    }
}
