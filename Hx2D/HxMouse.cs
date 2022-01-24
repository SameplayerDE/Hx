using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hx
{
    public static class HxMouse
    {
        public static Point Position => _curr.Position;
        public static Point MouseDelta => _curr.Position - _prev.Position;
        
        private static MouseState _curr;
        private static MouseState _prev;

        public static ButtonState LeftButton => _curr.LeftButton;
        public static ButtonState RightButton => _curr.RightButton;
        public static ButtonState MiddleButton => _curr.MiddleButton;
        public static ButtonState XButton1 => _curr.XButton1;
        public static ButtonState XButton2 => _curr.XButton2;

        public static void Update(GameTime gameTime)
        {
            _prev = _curr;
            _curr = Mouse.GetState();
        }
    }
}