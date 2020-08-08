using Codesbiome.U2D.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Spacerocks
{
    public class Ship : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float motionSpeed = 10f;
        private float rotationSpeed = 5f;
        private int rotation = 0;
        private Vector2 direction = Vector2.right;

        public AudioClip zapAudioClip;

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

            // Shoot bullet
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Play zap sound
                GameManager.Instance.audioSource.PlayOneShot(zapAudioClip);

                // Spawn bullet
                Bullet.SpawnInstance().ShootFromShip(gameObject);
            }
        }

        private void FixedUpdate()
        {
            // Apply rotation
            if (rotation != 0)
                rb.rotation += rotation * rotationSpeed;

            // Apply motion thrust
            if (Input.GetKey(KeyCode.UpArrow))
                MotionHelper.ThrustMotion(rb, direction, motionSpeed);

            // Apply transform warp
            MotionHelper.WarpTransform(transform, GameManager.RoomSize, 1f);

            // Reset rotation (getting dizzy!!)
            rotation = 0;
        }

        private void OnGUI()
        {
            return;
            GUILayout.BeginHorizontal();
            GUILayout.Label("POS: " + transform.position.ToString(), new GUIStyle("label")
            {
                fontSize = 20,
                margin = new RectOffset(0, 0, 200, 0)
            });
            GUILayout.EndHorizontal();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Collision with Asteroid
            if (collision.collider.CompareTag("Asteroid"))
            {
                Destroy(collision.gameObject);      // Destroy asteroid
                Destroy(gameObject);                // Destroy ship

                // Spawn debris
                Debris.Spawn(collision.transform.position, 10);

                // Decrease ship counts
                GameManager.shipsCount--;

                // Reload scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}