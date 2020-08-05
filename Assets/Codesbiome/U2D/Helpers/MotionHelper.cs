using System;
using UnityEngine;

namespace Codesbiome.U2D
{
    internal class MotionHelper
    {
        public static void ThrustMotion(Rigidbody2D rb, Vector2 direction, float speed)
        {
            // Velocity based on our direction and speed
            var velocity = direction * speed * Time.deltaTime;

            // Apply rotation to velocity so it moves towards the angle
            velocity = Quaternion.Euler(rb.transform.eulerAngles) * velocity;

            // Increase rigidbody velocity
            rb.velocity += velocity;
        }

        public static void WarpTransform(Transform transform, Vector2 bounds, float offset = 0f)
        {
            // Apply offset to boundaries
            bounds.x += offset;
            bounds.y += offset;

            // Position outside horizontal boundaries
            if (Math.Abs(transform.position.x) > bounds.x)
                transform.position = new Vector2(-offset, transform.position.y);

            // Position outside vertical boundaries
            if (Math.Abs(transform.position.y) > bounds.y)
                transform.position = new Vector2(transform.position.x, -offset);
        }
    }
}