using Microsoft.Xna.Framework;

namespace Hx
{
    public struct HxRay
    {
        public Vector2 Position;
        public Vector2 Direction;

        public static bool Intersects(HxRay a, HxRay b)
        {
            return false;
        }
        
        public static bool Intersects(HxRay a, HxCircle b)
        {
            return false;
        }
        
        public static bool Intersects(HxRay a, HxRectangle b)
        {
            return false;
        }
        
    }
}