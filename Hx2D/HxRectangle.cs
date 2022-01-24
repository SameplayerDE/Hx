using Microsoft.Xna.Framework;

namespace Hx
{
    /// <summary>
    /// 
    /// </summary>
    public struct HxRectangle
    {
        /// <summary>
        /// 
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Size;

        /// <summary>
        /// 
        /// </summary>
        public float Rotation;
        

        public static bool Intersects(HxRectangle a, HxRectangle b)
        {
            return false;
        }
        
    }
}