using UnityEngine;

namespace Codesbiome.U2D.Helpers
{
    internal class MathHelper
    {
        /// <summary>
        /// Provides random rotation
        /// </summary>
        public static Quaternion RandomRotation
        {
            get
            {
                return Quaternion.Euler(0, 0, Random.Range(0, 360));
            }
        }

        /// <summary>
        /// Choose random from list of items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static T Choose<T>(T[] items)
        {
            return items[Random.Range(0, items.Length)];
        }
    }
}