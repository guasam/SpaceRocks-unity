using Codesbiome.U2D.Helpers;
using UnityEngine;

namespace Spacerocks
{
    public class Asteroid : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float motionSpeed = 2f;

        private void Awake()
        {
            // Components cache
            rb = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            // Random rotation for asteroid
            transform.rotation = MathHelper.RandomRotation;

            // Asteroid directional velocity
            rb.velocity = Quaternion.Euler(transform.eulerAngles) * Vector2.right * motionSpeed;
        }

        private void FixedUpdate()
        {
            // Apply transform warp
            MotionHelper.WarpTransform(transform, GameManager.RoomSize, 1f);
        }
    }
}