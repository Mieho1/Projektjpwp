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
using Projektjpwp.Obstacles;


namespace Projektjpwp.Content.States
{
    public class Gamestate : state
    {
        Texture2D background1;
        Texture2D background2;
        private List<component> menu;
        SpriteFont font;
        SpriteFont pixelFont;
        Scrolling scrolling1;
        Scrolling scrolling2;
        int loop =1;
        string gowno;
        public Skater skater;
        public Obstacle pipe;
        public Obstacle cone;
        public Obstacle brick;
        public Obstacle banana;

        int speed=5;
        bool flagp=false;
        bool flagkey = false;
        KeyboardState _currentkey;
        KeyboardState _previouskey;







        public Gamestate(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            
            gowno = loop.ToString();
            
            font = _content.Load<SpriteFont>("Fonts/Title");
            var buttonTexture = _content.Load<Texture2D>("button/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/bubblefont");
            pixelFont = _content.Load<SpriteFont>("Fonts/PIPI");
            skater = new Skater(2, new Rectangle(0, 625, 300, 300), _content.Load<Texture2D>("sprites_skater/Sprite 01"));
            scrolling1 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(0, 0, 1280, 1024),skater,speed);
            scrolling2 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(1280, 0, 1280, 1024),skater,speed);
            pipe = new Obstacle(new Rectangle(300, 725, 200, 200), _content.Load<Texture2D>("Objects/Pipes Sprite 33"), speed);
            cone = new Obstacle(new Rectangle(2500,725, 200, 200), _content.Load<Texture2D>("Objects/Cone Sprite 30"), speed);
            //banana = new Obstacle(new Rectangle(, 725, 200, 200), _content.Load<Texture2D>("Objects/Cone Sprite 30"), speed);
            //pipe = new Pipe(new Rectangle(300,725,200,200), _content.Load<Texture2D>("Objects/Pipes Sprite 33"),speed);
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
            spriteBatch.Draw(skater.skatersprite, skater.size, Color.White);
            spriteBatch.Draw(pipe.sprite, pipe.size, Color.White);
            spriteBatch.Draw(cone.sprite, cone.size, Color.White);
            spriteBatch.DrawString(font,gowno, new Vector2(200, 200), Color.Black);
            spriteBatch.DrawString(font,skater.lifes.ToString(), new Vector2(250, 250), Color.Black);
            // spriteBatch.DrawString(pixelFont, "Press to start", new Vector2(500, 500), Color.Black); narazie kom
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
        {
            
            //ruchome tlo 
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
            KeyboardState state = Keyboard.GetState();
            _previouskey = _currentkey;
            _currentkey = Keyboard.GetState();

            if (_currentkey.IsKeyUp(Keys.P) && _previouskey.IsKeyDown(Keys.P) && pipe.size.X >= 100 && pipe.size.X <= 200)
            {

                skater.lifes += 1;

            }
           

                else if (pipe.size.X <= 100 && skater.lifes > 0 && flagp == false)
            {
                 skater.lifes -= 1;
                flagp = true;


            }
            if (skater.lifes == 0)
            {
                pipe.speed = 0;
                scrolling1.speed = 0;
                scrolling2.speed = 0;
            }


           
            scrolling1.Update();
            scrolling2.Update();
            pipe.Update();
            cone.Update();
           
            // pobiera co jest wcisniete
            
            if (state.IsKeyDown(Keys.Escape))
           _game.ChangeState(new Menustate(_game, _graphicsDevice, _content));




            

        }
    }
}
