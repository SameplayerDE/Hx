using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Point = System.Drawing.Point;

namespace Hx
{
    public struct HxLine
    {
        private float _xa, _ya;
        private float _xb, _yb;
        private float _m;
        private float _alpha;
        private float _alpha2;
        private float _length;

        public Vector2 A
        {
            get => GetA();
            set => SetA(value.X, value.Y);
        }

        public Vector2 B
        {
            get => GetB();
            set => SetB(value.X, value.Y);
        }

        public float M => _m;
        public float Length => _length;
        public HxRotation Alpha => HxRotation.FromRadians(_alpha);
        public HxRotation Alpha2 => HxRotation.FromRadians(_alpha2);

        public HxLine(float xa, float ya, float xb, float yb)
        {
            _xa = xa;
            _ya = ya;
            _xb = xb;
            _yb = yb;

            _m = HxMath.M(_xa, _ya, _xb, _yb);
            _alpha = HxMath.Alpha(_xa, _ya, _xb, _yb);
            _alpha2 = HxMath.Alpha2(_xa, _ya, _xb, _yb);
            _length = HxMath.Length(_xa, _ya, _xb, _yb);
        }

        public void SetA(float xa, float ya)
        {
            _xa = xa;
            _ya = ya;

            _m = HxMath.M(_xa, _ya, _xb, _yb);
            _alpha = HxMath.Alpha(_xa, _ya, _xb, _yb);
            _alpha2 = HxMath.Alpha2(_xa, _ya, _xb, _yb);
            _length = HxMath.Length(_xa, _ya, _xb, _yb);
        }

        public void SetB(float xb, float yb)
        {
            _xb = xb;
            _yb = yb;

            _m = HxMath.M(_xa, _ya, _xb, _yb);
            _alpha = HxMath.Alpha(_xa, _ya, _xb, _yb);
            _alpha2 = HxMath.Alpha2(_xa, _ya, _xb, _yb);
            _length = HxMath.Length(_xa, _ya, _xb, _yb);
        }

        public Vector2 GetA()
        {
            return new Vector2(_xa, _ya);
        }

        public Vector2 GetB()
        {
            return new Vector2(_xb, _yb);
        }

        public HxRectangle GetBounds()
        {
            var rectangle = new HxRectangle();

            rectangle.Position = new Vector2(
                Math.Min(_xa, _xb),
                Math.Min(_ya, _yb)
            );

            rectangle.Size = new Vector2(
                Math.Max(_xa, _xb),
                Math.Max(_ya, _yb)
            );

            rectangle.Size -= rectangle.Position;
            return rectangle;
        }
    }
}