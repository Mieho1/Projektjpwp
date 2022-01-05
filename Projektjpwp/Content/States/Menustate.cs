using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Projektjpwp.Content.Controls;

namespace Projektjpwp.Content.States
{
    public class Menustate : state
    {
        private List<component> _components;
        SpriteFont titlefont;
        Texture2D background;

        public Menustate(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("button/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/bubblefont");
            titlefont = _content.Load<SpriteFont>("Fonts/Title");
            background = _content.Load<Texture2D>("Background/skate-skeyt-stil-oboi");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300,270),
            Text = "Nowa Gra",
            
            };

            newGameButton.Click += NewGameButton_Click;
            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 380),
                Text = "Wczytaj Gre",
            };

            loadGameButton.Click += LoadGameButton_Click;
            loadGameButton.Click += LoadGameButton_Click;

            var selectLevelButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 490),
                Text = "Poziom",
            };

         

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300,600),
                Text = "Wyjdz",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<component>()
      {
        newGameButton,
        loadGameButton,
        selectLevelButton,
        quitGameButton,
      };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 1024), Color.White);
            spriteBatch.DrawString(titlefont, "Skate Alphabet", new Vector2(420,150), Color.White);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            
            
          
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Wczytaj Gre");
        }
        private void selectLevelButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Poziom");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new Gamestate(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

    }

    }

