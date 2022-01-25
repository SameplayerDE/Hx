using System;
using System.Windows.Forms.VisualStyles;
using Hx;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PrimitiveExpander;

namespace Test
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private HxCircle _mouse;
        
        private HxLine _a;
        private HxLine _b;

        private HxRay _ra;
        private HxRay _rb;

        private HxRectangle _rect;

        public Game1()
        {
            Content.RootDirectory = "Content";
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            PrimitiveRenderer.Initialise(GraphicsDevice);

            const float scale = 10f;

            _rect = new HxRectangle();
            _rect.Position = new Vector2(0, 0);
            _rect.Size = new Vector2(100, 100);

            _a = new HxLine();
            _a.A = new Vector2(0, 0) * scale;
            _a.B = new Vector2(2, 4) * scale;

            _b = new HxLine();
            _b.A = new Vector2(-2, 6) * scale;
            _b.B = new Vector2(3, 2) * scale;

            _ra = new HxRay();
            _ra.Position = new Vector2(0, 0);
            _ra.Direction = new Vector2(10, 0);
            
            _rb = new HxRay();
            _rb.Position = new Vector2(-10, -10);
            _rb.Direction = new Vector2(10, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            HxTime.Update(gameTime);
            HxMouse.Update(gameTime);

            var (width, height) = GraphicsDevice.Viewport.Bounds.Size.ToVector2();
            
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();
            
            if (keyboardState.IsKeyDown(Keys.PageUp))
            {
                PrimitiveRenderer.Scale += 1 * HxTime.DeltaTimeF;
            }

            if (keyboardState.IsKeyDown(Keys.PageDown))
            {
                PrimitiveRenderer.Scale -= 1 * HxTime.DeltaTimeF;
            }
            
            PrimitiveRenderer.UpdateDefaultCamera();

            _rb.Position = HxMouse.Position.ToVector2() - new Vector2(width, height) / 2;
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            
            PrimitiveRenderer.DrawQuadF(
                null,
                Color.Black,
                _rect.Position, _rect.Size
            );
            
            PrimitiveRenderer.DrawCircleF(
                null,
                HxMath.Contains(_rect, _mouse.Center) ? Color.Green : Color.Blue,
                _mouse.Center, 10f
            );
            
            PrimitiveRenderer.DrawLine(
                null,
                Color.Green,
                _a.A, _a.B
            );
            
            PrimitiveRenderer.DrawLine(
                null,
                Color.Green,
                _rb.Position, _rb.Direction * 10f + _rb.Position
            );

            var (intersects, position) = HxMath.Intersects(_rb, _a);
            if (intersects)
            {
                PrimitiveRenderer.DrawCircleF(
                    null,
                    Color.Red,
                    position, 2f
                );
            }
            
            base.Draw(gameTime);
        }
    }
}