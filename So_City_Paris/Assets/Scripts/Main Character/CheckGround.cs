using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private readonly int GROUND_LAYER=3;
    public static bool isGround { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GROUND_LAYER)
            isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GROUND_LAYER)
            isGround = false;
    }
}