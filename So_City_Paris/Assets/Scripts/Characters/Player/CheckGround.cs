using UnityEngine;

namespace Architecture.Player
{
    public class CheckGround : MonoBehaviour
    {
        private readonly int GROUND_LAYER = 3;
        public bool IsGround { get; private set; }
        public PlatformDown pl { get; private set; }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlatformDown>(out PlatformDown platform))
                pl = platform;

            if (collision.gameObject.layer == GROUND_LAYER)
                IsGround = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlatformDown>(out PlatformDown platform))
                pl = null;

            if (collision.gameObject.layer == GROUND_LAYER)
                IsGround = false;
        }
    }
}