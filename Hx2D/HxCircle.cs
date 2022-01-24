using System;
using Microsoft.Xna.Framework;

namespace Hx
{
    /// <summary>
    /// 
    /// </summary>
    public struct HxCircle
    {
        /// <summary>
        /// Position Of The Circle
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Radius Of The Circle
        /// </summary>
        public float Radius;

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Center
        {
            get => Position;
            set => Position = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Penetration(HxCircle a, HxCircle b)
        {
            var distance = Vector2.Distance(a.Position, b.Position);
            var thresholdDistance = a.Radius + b.Radius;
            var penetration = thresholdDistance - distance;
            return Math.Max(penetration, 0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Penetration(HxCircle a, Vector2 b)
        {
            var distance = Vector2.Distance(a.Position, b);
            var thresholdDistance = a.Radius;
            var penetration = thresholdDistance - distance;
            return Math.Max(penetration, 0f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Intersects(HxCircle a, HxCircle b)
        {
            var penetration = Penetration(a, b);
            return penetration > 0f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool Contains(HxCircle a, Vector2 b)
        {
            var penetration = Penetration(a, b);
            return penetration > 0f;
        }
    }
}