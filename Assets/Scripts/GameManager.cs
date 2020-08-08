using Codesbiome.U2D;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Spacerocks
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;
        private static CameraAspector ca;
        public Font font;
        public static int scoreCount = 999;
        public static int shipsCount = 1;
        public static int winScore = 1000;

        public AudioSource audioSource;

        public GameObject bulletPrefab;
        public GameObject debrisPrefab;
        public GameObject[] asteroidTypes;

        private int defaultAsteroidCount = 12;

        /// <summary>
        /// Game room size in pixels
        /// </summary>
        public static Vector2 RoomSizePixels
        {
            get { return ca.roomSize; }
        }

        /// <summary>
        /// Pixels per unit
        /// </summary>
        public static int PPU
        {
            get { return ca.ppu; }
        }

        /// <summary>
        /// Game room size in units
        /// </summary>
        public static Vector2 RoomSize
        {
            get { return RoomSizePixels / PPU; }
        }

        /// <summary>
        /// Position vector of center point on screen
        /// </summary>
        public static Vector2 ScreenCenterPosition
        {
            get { return new Vector2(RoomSizePixels.x / PPU * 0.5f, RoomSizePixels.y / PPU * 0.5f); }
        }

        /// <summary>
        /// Awake is called when script instance is being loaded
        /// </summary>
        private void Awake()
        {
            // Initialize Singleton
            singleton();

            // Components cache
            ca = Camera.main.GetComponent<CameraAspector>();
        }

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Start()
        {
            // Spawn asteroid on random position slots
            for (int i = 0; i < defaultAsteroidCount; i++)
                Asteroid.SpawnInstance(Random.Range(0, 3)).RandomPositionSlots();
        }

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Update()
        {
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("SCORE: " + scoreCount, new GUIStyle("label")
            {
                fontSize = 20,
                font = font,
                margin = new RectOffset(0, 0, 10, 0)
            });

            GUILayout.Label("SHIPS: " + shipsCount, new GUIStyle("label")
            {
                fontSize = 20,
                font = font,
                margin = new RectOffset(40, 0, 10, 0)
            });
            GUILayout.EndHorizontal();
        }

        private void singleton()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);
        }

        private IEnumerator destroyShipAndReloadScene(GameObject ship)
        {
            // Destroy ship object
            Destroy(ship);

            // Ship counts now
            var shipsAvailable = shipsCount - 1;

            // Wait and reload scene
            yield return new WaitForSeconds(2f);

            // No ships in stock, game over! Load OverScene
            if (shipsAvailable < 0)
                SceneManager.LoadScene("OverScene", LoadSceneMode.Single);
            else
            {
                // Decrease total ship counts
                shipsCount--;

                // Load GameScene Again
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public void DestroyShipAndReload(GameObject ship)
        {
            StartCoroutine(destroyShipAndReloadScene(ship));
        }

        public static void IncreaseScore(int scorePoint = 1)
        {
            // Increase score count by points
            scoreCount += scorePoint;

            // Score has reached win limit, Load WinScene
            if (scoreCount >= winScore)
                SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }

        public static void ResetCounters()
        {
            scoreCount = 0;
            shipsCount = 3;
        }
    }
}