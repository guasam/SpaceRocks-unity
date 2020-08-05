using Codesbiome.U2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spacerocks
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;
        public static Vector2 RoomSize;
        private CameraAspector ca;

        /// <summary>
        /// Awake is called when script instance is being loaded
        /// </summary>
        private void Awake()
        {
            // Initialize Singleton
            singleton();

            // Components cache
            ca = Camera.main.GetComponent<CameraAspector>();

            // Assign properties
            RoomSize = ca.roomSize;
        }

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Start()
        {
        }

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Update()
        {
        }

        private void singleton()
        {
            // Initialize singleton
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);
        }
    }
}