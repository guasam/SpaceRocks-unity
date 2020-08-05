﻿using UnityEngine;

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
    }
}