using Hx;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrimitiveExpander;

namespace Test
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 _position;


        private HxCircle _a;
        private HxCircle _b;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            PrimitiveRenderer.Initialise(GraphicsDevice);

            _a = new HxCircle();
            _a.Radius = 25f;
            
            _b = new HxCircle();
            _b.Radius = 5f;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            HxMouse.Update(gameTime);
            PrimitiveRenderer.UpdateDefaultCamera();

            var (width, height) = _graphics.GraphicsDevice.Viewport.Bounds.Size.ToVector2();

            _a.Position = HxMouse.Position.ToVector2();
            _a.Position -= new Vector2(width, height) / 2;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);


            PrimitiveRenderer.DrawCircleF(
                null,
                HxCircle.Intersects(_a, _b) ? Color.Red : Color.Black,
                _a.Position,
                _a.Radius,
                10
            );
            
            PrimitiveRenderer.DrawCircleF(
                null,
                HxCircle.Intersects(_b, _a) ? Color.Red : Color.Black,
                _b.Position,
                _b.Radius,
                10
            );

            base.Draw(gameTime);
        }
    }
}