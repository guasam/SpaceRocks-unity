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

        /// <summary>
        /// Spawn asteroid
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static GameObject Spawn(int size)
        {
            return Instantiate(GameManager.Instance.asteroidTypes[size]);
        }

        public static GameObject Spawn(Vector2 position, int size = 0)
        {
            return Instantiate(GameManager.Instance.asteroidTypes[size], position, Quaternion.identity);
        }

        /// <summary>
        /// Spawn asteroid and return Script instance
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Asteroid SpawnInstance(int size)
        {
            return Spawn(size).GetComponent<Asteroid>();
        }

        /// <summary>
        /// Changes asteroid position to a random slot
        /// </summary>
        public void RandomPositionSlots()
        {
            // Cache width and height
            var width = GameManager.RoomSize.x;
            var height = GameManager.RoomSize.y;

            // Bottom section spawn slots
            var bottomSlots = new float[]
            {
                Random.Range(0f, width * 0.2f),
                Random.Range(width * 0.8f, width)
            };

            // Top section spawn slots
            var topSlots = new float[]
            {
                Random.Range(0 , height * 0.2f),
                Random.Range(height * 0.8f, height)
            };

            var posX = MathHelper.Choose(bottomSlots);
            var posY = MathHelper.Choose(topSlots);

            // Apply asteroid position to current slot
            transform.position = new Vector2(posX, posY);
        }
    }
}