using Codesbiome.U2D;
using UnityEngine;

namespace Spacerocks
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float speed = 5f;

        private void Awake()
        {
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
            //if (transform.position.x > GameManager.RoomSize.x || transform.position.y > GameManager.RoomSize.y)
            if (MotionHelper.OutOfBounds(transform.position, GameManager.RoomSize, 1f))
                Destroy(gameObject);
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