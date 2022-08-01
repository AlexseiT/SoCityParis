using UnityEngine;

public class InputTracking : MonoBehaviour
{
    public static float moveHorizontal { get; private set; }
    public static float moveVertical { get; private set; }
    public static bool isJumpButtonPressed { get; private set; }

    private void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
            isJumpButtonPressed = true;
        else
            isJumpButtonPressed = false;
    }
}