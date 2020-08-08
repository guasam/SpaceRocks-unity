using Codesbiome.U2D.Helpers;
using UnityEngine;

namespace Spacerocks
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float speed = 10f;

        public AudioClip dieAudioClip;

        private void Awake()
        {
            // Components cache
            rb = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void FixedUpdate()
        {
            // Destroy bullet gameObject if out of room boundaries
            if (MotionHelper.OutOfBounds(transform.position, GameManager.RoomSize, 1f))
                Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Collision with Asteroid
            if (collision.collider.CompareTag("Asteroid"))
            {
                // Play die sound
                GameManager.Instance.audioSource.PlayOneShot(dieAudioClip);

                // Destroy
                Destroy(collision.gameObject);  // Destroy asteroid
                Destroy(gameObject);            // Destroy bullet

                // Score points for asteroid smashing
                var scorePoint = 3;

                // Spawn debris
                Debris.Spawn(collision.transform.position, 10);

                // Collision with large asteroid
                if (collision.collider.name.Contains("Asteroid_large"))
                {
                    scorePoint = 1;

                    // Spawn medium asteroid
                    for (int i = 0; i < 2; i++)
                        Asteroid.Spawn(collision.transform.position, 1);
                }

                // Collision with medium asteroid
                if (collision.collider.name.Contains("Asteroid_medium"))
                {
                    scorePoint = 2;

                    // Spawn small asteroid
                    for (int i = 0; i < 2; i++)
                        Asteroid.Spawn(collision.transform.position);
                }

                // Increase score count
                //GameManager.scoreCount += scorePoint;

                GameManager.IncreaseScore(scorePoint);
            }
        }

        /// <summary>
        /// Spawn Bullet
        /// </summary>
        /// <returns></returns>
        public static GameObject Spawn()
        {
            return Instantiate(GameManager.Instance.bulletPrefab);
        }

        /// <summary>
        /// Spawn bullet and return Script Instance
        /// </summary>
        /// <returns></returns>
        public static Bullet SpawnInstance()
        {
            return Spawn().GetComponent<Bullet>();
        }

        /// <summary>
        /// Shoot bullet from ship's tip
        /// </summary>
        /// <param name="ship">Ship GameObject</param>
        public void ShootFromShip(GameObject ship)
        {
            // Linear velocity of bullet based on Ship's current direction and bullet speed
            var velocity = Quaternion.Euler(ship.transform.eulerAngles) * Vector2.right * speed;

            // Bullet should spawn at ship's tip position
            transform.position = (velocity.normalized * 0.5f) + new Vector3(
                ship.transform.position.x,
                ship.transform.position.y
            );

            // Apply linear velocity on bullet
            rb.velocity = velocity;
        }
    }
}