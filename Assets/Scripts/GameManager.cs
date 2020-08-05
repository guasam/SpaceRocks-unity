using Codesbiome.U2D;
using System;
using Unity.Mathematics;
using UnityEngine;

namespace Spacerocks
{
    public class GameManager : MonoBehaviour
    {
        private static CameraAspector ca;

        public static GameManager Instance = null;

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
        }

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Update()
        {
        }

        private void singleton()
        {
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(gameObject);
        }
    }
}