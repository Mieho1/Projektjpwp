using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projektjpwp.Content.Controls;
using Projektjpwp.Content.States;
using System;

namespace Projektjpwp
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont sfont;
        private SpriteFont bubblefont;
        private Texture2D texture;
        private Button button;
        private state _curentState;
        private state _nextState;
        public void ChangeState(state state)
        {
            _nextState = state;
        }
        /// <summary>
        /// Tutaj state jest to nazwa klasy i zmiennej ponieważ zapomniałem z nazwać klase z dużej litery 
        /// </summary>



        public  Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bubblefont = Content.Load<SpriteFont>("bubblefont");
            texture = Content.Load<Texture2D>("button/Button");
            _curentState = new Menustate(this,_graphics.GraphicsDevice, Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _curentState = _nextState;

                _nextState = null;
            }

            _curentState.Update(gameTime);

            _curentState.PostUpdate(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            _curentState.Draw(gameTime, _spriteBatch);

            

            base.Draw(gameTime);
        }

        internal void ChangeState(Gamestate gamestate)
        {
            throw new NotImplementedException();
        }
    }


}
