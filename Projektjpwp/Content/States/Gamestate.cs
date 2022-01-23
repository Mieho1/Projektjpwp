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
        int timer;
        int frametimer=60;
        int frametimmerfall = 60;
        int skaterY = 625;
        bool flagp=false;
        bool flagkey = false;
        bool flagp1 = false;
        bool flagkey1 = false;
        bool flagp2 = false;
        bool flagkey2 = false;
        bool flagp3 = false;
        bool flagkey3 = false;
        bool level2 = false;
        bool gameover1=false;
        KeyboardState _currentkey;
        KeyboardState _previouskey;

        void Jump(int frametimer, Skater skater,bool flag)
        { 
                switch (frametimer / 5)
                {
                    case 12:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 01");
                        break;
                    case 11:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 02");
                        break;
                    case 10:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 03");
                        break;
                    case 9:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 04");
                        break;
                    case 8:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 05");
                        break;
                    case 7:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                        break;
                    case 6:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 07");
                        break;
                    case 5:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 08");
                        break;
                    case 4:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 09");
                        break;
                    case 3:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 10");
                        break;
                    case 2:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 11");
                        break;
                    case 1:
                        skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 12");
                        break;
                
            }


        }
        void fall(int frametimmer, Skater skater)
        {
            switch (frametimer / 10)
            {
                case 6:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 25");
                    break;
                case 5:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 21");
                    break;
                case 4:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 22");
                    break;
                case 3:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 23");
                    break;
                case 2:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 24");
                    break;
                case 1:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 25");
                    break;
            }

        }





        public Gamestate(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            timer = 60 * 2;
            gowno = loop.ToString();
            
            font = _content.Load<SpriteFont>("Fonts/Title");
            var buttonTexture = _content.Load<Texture2D>("button/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/bubblefont");

            pixelFont = _content.Load<SpriteFont>("Fonts/PIPI");
            skater = new Skater(2, new Rectangle(0, skaterY, 300, 300), _content.Load<Texture2D>("sprites_skater/Sprite 12"));
            scrolling1 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(0, 0, 1280, 1024),skater,speed);
            scrolling2 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(1280, 0, 1280, 1024),skater,speed);
            pipe = new Obstacle(new Rectangle(600, 725, 200, 200), _content.Load<Texture2D>("Objects/Pipes Sprite 33"), speed,"P");
            cone = new Obstacle(new Rectangle(1600,725, 200, 200), _content.Load<Texture2D>("Objects/Cone Sprite 30"), speed,"C");
            banana= new Obstacle(new Rectangle(2600, 725, 200, 200), _content.Load<Texture2D>("Objects/Banana Sprite 28"), speed,"B");
            brick= new Obstacle(new Rectangle(3600, 725, 200, 200), _content.Load<Texture2D>("Objects/Lower Obstacle Sprite 32"), speed,"L");
            //banana = new Obstacle(new Rectangle(, 725, 200, 200), _content.Load<Texture2D>("Objects/Cone Sprite 30"), speed);
            //pipe = new Pipe( new Rectangle (500,725,200,200),_content.Load<Texture2D>("Objects/Pipes Sprite 33"),speed,500);
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
            spriteBatch.Draw(skater.skatersprite, skater.size, skater.color);
            spriteBatch.Draw(pipe.sprite, pipe.size, Color.White);
            spriteBatch.Draw(cone.sprite, cone.size, Color.White);
            spriteBatch.Draw(banana.sprite, banana.size, Color.White);
            spriteBatch.Draw(brick.sprite, brick.size, Color.White);
            spriteBatch.DrawString(font,gowno, new Vector2(200, 200), Color.Black);
            spriteBatch.DrawString(font,skater.lifes.ToString(), new Vector2(250, 250), Color.White);
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
            timer--;
            frametimer--;
            frametimmerfall--;
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
            #region pipe1
            if (_currentkey.IsKeyUp(Keys.P) && _previouskey.IsKeyDown(Keys.P) && pipe.size.X >= 120 && pipe.size.X <= 250)
            {
                skater.lifes += 1;
                flagkey = true;
                frametimer = 60;
            }
            if (flagkey == true)
            {
             Jump(frametimer, skater, flagkey);

            }
            
            
                else if (pipe.size.X <= 100 && skater.lifes > 0 && flagp == false && flagkey== false)
            {
                 skater.lifes -= 1;
                flagp = true;
                skater.color = Color.Red;
                timer = 30;

            }
           
            

            
            #endregion
            #region banana 
            if (_currentkey.IsKeyUp(Keys.B) && _previouskey.IsKeyDown(Keys.B) && banana.size.X >= 100 && banana.size.X <= 250)
            {
                skater.lifes += 1;
                flagkey1 = true;
                frametimer = 60;


            }
            if (flagkey1 == true)
            {
                Jump(frametimer, skater, flagkey);

            }

            else if (banana.size.X <= 90 && skater.lifes > 0 && flagp1 == false && flagkey1 == false)
            {
                skater.lifes -= 1;
                flagp1 = true;
                skater.color = Color.Red;
                timer = 30;
            }
            #endregion
            #region cone
            if (_currentkey.IsKeyUp(Keys.C) && _previouskey.IsKeyDown(Keys.C) && cone.size.X >= 90 && cone.size.X <= 250)
            {
                skater.lifes += 1;
                flagkey2 = true;
                frametimer = 60;

            }
            if (flagkey2 == true)
            {
                Jump(frametimer, skater, flagkey);

            }

            else if (cone.size.X <= 90 && skater.lifes > 0 && flagp2 == false && flagkey2 == false)
            {
                skater.lifes -= 1;
                flagp2 = true;
                skater.color = Color.Red;
                timer = 30;
            }
            #endregion
            #region brick
            if (_currentkey.IsKeyUp(Keys.L) && _previouskey.IsKeyDown(Keys.L) && brick.size.X >= 90 && brick.size.X <= 250)
            {
                skater.lifes += 1;
                flagkey3 = true;
                frametimer = 60;
            }
            if (flagkey3 == true)
            {
                Jump(frametimer, skater, flagkey);

            }

            else if (brick.size.X <= 90 && skater.lifes > 0 && flagp3 == false && flagkey3 == false)
            {
                skater.lifes -= 1;
                flagp3 = true;
                skater.color = Color.Red;
                timer = 30;

            }
         
            #endregion
            if (timer == 0)
            {
                skater.color = Color.White;
            }
            if (skater.lifes == 0)
            {
                pipe.speed = 0;
                brick.speed =0;
                banana.speed = 0;
                cone.speed = 0;
                scrolling1.speed = 0;
                scrolling2.speed = 0;
                frametimer = 60;
                gameover1 = true;
                
            }
            if (gameover1 == true)
            {
                fall(frametimer, skater);
            }
            if (loop == 4 && level2==false)
            {
                scrolling1.speed += 3;
                scrolling2.speed += 3;
                level2 = true;
            }
           

            scrolling1.Update();
            scrolling2.Update();
            pipe.Update();
            cone.Update();
            banana.Update();
            brick.Update();
           
           
            // pobiera co jest wcisniete
            
            if (state.IsKeyDown(Keys.Escape))
           _game.ChangeState(new Menustate(_game, _graphicsDevice, _content));




            

        }
    }
}
