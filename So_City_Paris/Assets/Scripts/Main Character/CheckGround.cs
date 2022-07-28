using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGround { get; private set; }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGround = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround =false;    
    }
}
