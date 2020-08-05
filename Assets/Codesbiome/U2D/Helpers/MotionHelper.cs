using UnityEngine;

namespace Codesbiome.U2D.Helpers
{
    internal class MotionHelper
    {
        /// <summary>
        /// Applies thrust motion/velocity to Rigidbody2D (per tick)
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public static void ThrustMotion(Rigidbody2D rb, Vector2 direction, float speed)
        {
            // Velocity based on our direction and speed
            var velocity = direction * speed * Time.deltaTime;

            // Apply rotation to velocity so it moves towards the angle
            velocity = Quaternion.Euler(rb.transform.eulerAngles) * velocity;

            // Increase rigidbody velocity
            rb.velocity += velocity;
        }

        /// <summary>
        /// Warp transform position when out of bounds,
        /// It changes position to spawns back inside assigned boundaries with offset
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="bounds"></param>
        /// <param name="offset"></param>
        public static void WarpTransform(Transform transform, Vector2 bounds, float offset = 0f)
        {
            // Offseted boundaries
            bounds.x += offset;
            bounds.y += offset;

            // Position cache
            var posX = transform.position.x;
            var posY = transform.position.y;

            // Position outside horizontal boundaries
            if (posX > bounds.x)
                transform.position = new Vector2(-offset, posY);
            else if (transform.position.x < -offset)
                transform.position = new Vector2(bounds.x, posY);

            // Position outside vertical boundaries
            if (posY > bounds.y)
                transform.position = new Vector2(posX, -offset);
            else if (posY < -offset)
                transform.position = new Vector2(posX, bounds.y);
        }

        /// <summary>
        /// Returns true if position vector exceeds any axis of boundaries vector with offset
        /// </summary>
        /// <param name="position"></param>
        /// <param name="bounds"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static bool OutOfBounds(Vector2 position, Vector2 bounds, float offset = 0f)
        {
            return position.x > bounds.x + offset || position.y > bounds.y + offset;
        }
    }
}