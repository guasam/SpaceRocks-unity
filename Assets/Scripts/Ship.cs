using Codesbiome.U2D;
using Spacerocks;
using UnityEngine;

namespace Spacerocks
{
    public class Ship : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float motionSpeed = 10f;
        private float rotationSpeed = 5f;
        private int rotation = 0;
        private Vector2 direction = Vector2.right;

        /// <summary>
        /// Awake is called when script instance is being loaded
        /// </summary>
        private void Awake()
        {
            // Components cache
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Start()
        {
            // Set position to center of screen
            transform.position = GameManager.ScreenCenterPosition;
        }

        private void Update()
        {
            // Rotate left
            if (Input.GetKey(KeyCode.LeftArrow))
                rotation = 1;

            // Rotate right
            if (Input.GetKey(KeyCode.RightArrow))
                rotation = -1;
        }

        private void FixedUpdate()
        {
            // Apply rotation
            if (rotation != 0)
                rb.rotation += rotation * rotationSpeed;

            // Apply motion thrust
            if (Input.GetKey(KeyCode.UpArrow))
                MotionHelper.ApplyThrustMotion(rb, direction, motionSpeed);

            // Reset rotation (getting dizzy!!)
            rotation = 0;
        }
    }
}