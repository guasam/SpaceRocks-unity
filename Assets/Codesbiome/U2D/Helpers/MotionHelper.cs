using UnityEngine;

namespace Codesbiome.U2D
{
    internal class MotionHelper
    {
        public static void ApplyMotion(Rigidbody2D rb, Vector2 direction, float speed)
        {
            // Velocity based on our direction and speed
            var velocity = direction * speed * Time.deltaTime;

            // Apply rotation to velocity so it moves towards the angle
            velocity = Quaternion.Euler(rb.transform.eulerAngles) * velocity;

            // Increase rigidbody velocity
            rb.velocity += velocity;
        }
    }
}