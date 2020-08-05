using Codesbiome.U2D.Helpers;
using UnityEngine;

namespace Spacerocks
{
    public class Debris : MonoBehaviour
    {
        private Rigidbody2D rb;
        private SpriteRenderer sr;

        private void Awake()
        {
            // Components cache
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            // Random rotation for debris
            transform.rotation = MathHelper.RandomRotation;

            // Linear velocity of debris
            rb.velocity = Quaternion.Euler(transform.eulerAngles) * Vector2.right;
        }

        // Update is called once per frame
        private void Update()
        {
            // Decrease debris sprite color alpha for fadeout effect
            var color = sr.color;               // Cache color of sprite
            color.a -= 0.9f * Time.deltaTime;   // Decrease opacity per tick
            sr.color = color;                   // Assign new color with new alpha

            // Sprite color alpha is below zero, its faded out, remove object
            if (sr.color.a < 0f)
                Destroy(gameObject);
        }

        /// <summary>
        /// Spawn debris
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static void Spawn(Vector2 position, int amount = 1)
        {
            for (var i = 0; i < amount; i++)
                Instantiate(GameManager.Instance.debrisPrefab, position, Quaternion.identity);
        }
    }
}