using System;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D11;

namespace Hx
{
    /// <summary>
    /// HxMath Class For All Stuff Related To Math
    /// </summary>
    public static class HxMath
    {
        /// <summary>
        /// Calculates The Direction Of Two Circles
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector2 Direction(HxCircle from, HxCircle to)
        {
            return Direction(from.Position, to.Position);
        }

        /// <summary>
        /// Calculates The Direction Of A Circle And A Vector
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector2 Direction(HxCircle from, Vector2 to)
        {
            return Direction(from.Position, to);
        }

        /// <summary>
        /// Calculates The Direction Of A Vector And A Circle
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector2 Direction(Vector2 from, HxCircle to)
        {
            return Direction(from, to.Position);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Vector2 Direction(HxLine line)
        {
            return Direction(line.A, line.B);
        }

        /// <summary>
        /// Calculates The Direction Of Two Vectors
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector2 Direction(Vector2 from, Vector2 to)
        {
            var (xa, ya) = from;
            var (xb, yb) = to;
            var (x, y) = Direction(xa, ya, xb, yb);
            return new Vector2(x, y);
        }

        /// <summary>
        /// Calculates The Normalised Direction Of Two Circles
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector2 DirectionNormalised(HxCircle from, HxCircle to)
        {
            return DirectionNormalised(from.Position, to.Position);
        }

        /// <summary>
        /// Calculates The Normalised Direction Of A Circles And A Vector
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector2 DirectionNormalised(HxCircle from, Vector2 to)
        {
            return DirectionNormalised(from.Position, to);
        }

        /// <summary>
        /// Calculates The Normalised Direction Of A Vector And A Circle
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector2 DirectionNormalised(Vector2 from, HxCircle to)
        {
            return DirectionNormalised(from, to.Position);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Vector2 DirectionNormalised(HxLine line)
        {
            return DirectionNormalised(line.A, line.B);
        }

        /// <summary>
        /// Calculates The Normalised Direction Of Two Vectors
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static Vector2 DirectionNormalised(Vector2 from, Vector2 to)
        {
            var direction = Direction(from, to);
            var length = direction.Length();
            return direction / (length > 0f ? length : 1f);
        }

        public static float ToRadians(float degree)
        {
            return MathHelper.ToRadians(degree);
        }

        public static float ToDegrees(float degree)
        {
            return MathHelper.ToDegrees(degree);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float M(Vector2 a, Vector2 b)
        {
            var (xa, ya) = a;
            var (xb, yb) = b;
            return M(xa, ya, xb, yb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Alpha(Vector2 a, Vector2 b)
        {
            var (xa, ya) = a;
            var (xb, yb) = b;
            return Alpha(xa, ya, xb, yb);
        }

        public static float Alpha(float xa, float ya, float xb, float yb)
        {
            return (float)Math.Atan(yb - ya / xb - xa);
        }

        public static float Alpha2(float xa, float ya, float xb, float yb)
        {
            return (float)Math.Atan2(yb - ya, xb - xa);
        }

        public static (float, float) Direction(float xa, float ya, float xb, float yb)
        {
            return (xb - xa, yb - ya);
        }

        public static float Length(float xa, float ya, float xb, float yb)
        {
            var (x, y) = Direction(xa, ya, xb, yb);
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public static float T(float m, float xa, float ya)
        {
            return Y(m, 0, xa, ya);
        }
        
        public static float T(HxLine line)
        {
            return Y(M(line), 0, line.A);
        }
        
        public static float Y(float m, float x, float t)
        {
            return m * x + t;
        }
        
        public static float Y(float m, float x, float xa, float ya)
        {
            return m * (x - xa) + ya;
        }
        
        public static float Y(float m, float x, Vector2 a)
        {
            var (xa, ya) = a;
            return Y(m, x, xa, ya);
        }
        
        public static float M(HxLine a)
        {
            var (xa, ya) = a.A;
            var (xb, yb) = a.B;
            return M(xa, ya, xb, yb);
        }
        
        public static float M(float xa, float ya, float xb, float yb)
        {
            var result = (yb - ya) / (xb - xa);
            return result;
        }

        public static bool Contains(HxRectangle a, Vector2 b)
        {
            var bDir = Direction(b, a.Position);
            if (bDir.X > 0 || bDir.Y > 0) return false;
            var rDir = Direction(a.Position, a.Position + a.Size);
            return bDir.Length() <= rDir.Length();
        }
        
        public static (bool, Vector2) Intersects(HxLine a, HxLine b)
        {
            var resultM = M(a) + M(b) * -1;
            if (resultM == 0) return (false, Vector2.Zero);
            var resultT = T(a) * -1 + T(b);
            if (resultT == 0) return (false, Vector2.Zero);
            var resultX = resultT / resultM;
            var resultY = Y(M(a), resultX, T(a));
            var containsA = Contains(a.GetBounds(), new Vector2(resultX, resultY));
            var containsB = Contains(b.GetBounds(), new Vector2(resultX, resultY));
            var result = containsA && containsB;
            return (result, new Vector2(resultX, resultY));
        }
    }
}