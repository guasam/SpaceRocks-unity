using Codesbiome.U2D;
using System;
using Unity.Mathematics;
using UnityEngine;

namespace Spacerocks
{
    public class GameManager : MonoBehaviour
    {
        private CameraAspector ca;

        public static GameManager Instance = null;
        public static Vector2 RoomSize;
        public static int PPU;

        public static Vector2 ScreenCenterPosition
        {
            get { return new Vector2(RoomSize.x / PPU * 0.5f, RoomSize.y / PPU * 0.5f); }
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

            // Assign properties
            RoomSize = ca.roomSize;
            PPU = ca.ppu;
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