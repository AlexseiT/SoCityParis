using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public static int orderLayerPlayer;

    private void Start()
    {
        orderLayerPlayer = GetComponent<SpriteRenderer>().sortingOrder;
    }
}