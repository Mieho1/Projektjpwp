using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Projektjpwp.Backgrounds;
using Projektjpwp.Content.Controls;
using Microsoft.Xna.Framework.Input;

namespace Projektjpwp.Content.States
{
    public class Gamestate : state
    {
        Texture2D background1;
        Texture2D background2;
        private List<component> menu;
        SpriteFont font;
        Scrolling scrolling1;
        Scrolling scrolling2;
        int loop =1;
        string gowno;
        




        public Gamestate(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            gowno = loop.ToString();
            font = _content.Load<SpriteFont>("Fonts/Title");
            var buttonTexture = _content.Load<Texture2D>("button/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/bubblefont");
            var texture = _content.Load<Texture2D>("Objects1/skater");
            scrolling1 = new Scrolling(_content.Load<Texture2D>("Background/alternative"),new Rectangle(0,0,1280,1024));
            scrolling2 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(1280, 0,1280,1024));
            var menubutton = new Button(buttonTexture, buttonFont)
            { 
                Position= new Vector2(50,50),
                Text="Menu",
            };
            menu = new List<component>()
      {
        menubutton
      };
            menubutton.Click += menuButton_Click;
            
            

        }

       
       



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            scrolling1.Draw(spriteBatch);
            scrolling2.Draw(spriteBatch);
            spriteBatch.DrawString(font,gowno, new Vector2(200, 200), Color.Black);
            foreach (var component in menu)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();


        }
        private void menuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new Menustate(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {   //ruchome tlo 
            foreach (var component in menu)
                component.Update(gameTime);
            if (scrolling1.rectangle.X + scrolling1.texture.Width <= 0)
            {
                scrolling1.rectangle.X = scrolling2.rectangle.X + scrolling2.texture.Width;
                loop++;
                gowno = loop.ToString();
            }
            if (scrolling2.rectangle.X + scrolling2.texture.Width <= 0)
            {
                scrolling2.rectangle.X = scrolling1.rectangle.X + scrolling2.texture.Width;
                 loop++;
                gowno = loop.ToString();
            }
            scrolling1.Update();
            scrolling2.Update();
            // pobiera co jest wcisniete
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
           _game.ChangeState(new Menustate(_game, _graphicsDevice, _content));




            

        }
    }
}
