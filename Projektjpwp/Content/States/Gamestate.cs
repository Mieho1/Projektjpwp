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
        int klok=0;
        private List<component> menu;
        SpriteFont font;
        SpriteFont buttonFont;
        SpriteFont pixelFont;
        SpriteFont Mario;
        Scrolling scrolling1;
        Scrolling scrolling2;
        int loop = 1;
        string gowno;
        public Skater skater;
        public List<Obstacle> objects;
        int speed = 5;
        int timer;
        int frametimer = 60;
        float frametimmerfall = 60;
        int hitbox1;
        int hitbox2;
        int hitbox3;
        int hitbox4;
        int skaterY = 625;
        bool colision = false;
        bool flagkey = false;
        bool flagkey1 = false;
        bool level2 = false;
        bool gameover1 = false;
        int helpin = 0;

        KeyboardState _currentkey;
        KeyboardState _previouskey;

        void Jump(int frametimer, Skater skater, bool flag)
        {
            switch (frametimer)
            {
                case 60:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 01");
                    break;
                case 59:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 01");
                    break;
                case 58:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 01");
                    break;


                case 57:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 02");
                    break;
                case 56:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 02");
                    break;
                case 55:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 02");
                    break;


                case 54:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 03");
                    break;
                case 53:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 03");
                    break;
                case 52:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 03");
                    break;


                case 51:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 04");
                    break;
                case 50:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 04");
                    break;
                case 49:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 04");
                    break;


                case 48:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 05");
                    break;
                case 47:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 05");
                    break;
                case 46:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 05");
                    break;
                case 45:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 44:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 43:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 42:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 41:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 40:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 39:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 38:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 37:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 36:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 35:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 34:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 33:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 32:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 31:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 30:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 29:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 28:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 27:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
                case 26:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 06");
                    break;
            
               

                case 25:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 07");
                    break;
                case 24:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 07");
                    break;
                case 23:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 07");
                    break;
                case 22:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 07");
                    break;
                case 21:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 07");
                    break;

                case 20:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 08");
                    break;
                case 19:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 08");
                    break;
                case 18:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 08");
                    break;
                case 17:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 08");
                    break;
                case 16:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 08");
                    break;

                case 15:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 09");
                    break;
                case 14:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 09");
                    break;
                case 13:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 09");
                    break;
                case 12:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 09");
                    break;
                case 11:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 09");
                    break;

                case 10:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 10");
                    break;
                case 9:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 10");
                    break;
                case 8:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 10");
                    break;
                case 7:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 10");
                    break;
                case 6:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 10");
                    break;
                case 5:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 11");
                    break;
                case 4:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 11");
                    break;
                case 3:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 11");
                    break;
                case 2:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 11");
                    break;
                case 1:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 11");
                    break;

                case 0:
                    skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 12");
                    flagkey1 = false;
                    flagkey = false;
                    break;

            }


        }
        void fall(float frametimmer, Skater skater)
        {
            skater.skatersprite = _content.Load<Texture2D>("sprites_skater/Sprite 25");

        }
        void NextObject(int i)
        {
            objects[i].size.X = objects[i].size.X + 4000;




        }
        Keys Rndchar()
        {

            Random rnd = new Random();
            int ascii_index = rnd.Next(65, 91);
            char myRandomUpperCase = Convert.ToChar(ascii_index);
            Keys cAsKey = (Keys)((int)(char.ToUpper(myRandomUpperCase)));
            return cAsKey;



        }





        public Gamestate(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            timer = 60 * 2;
            gowno = loop.ToString();

            font = _content.Load<SpriteFont>("Fonts/Title");
            var buttonTexture = _content.Load<Texture2D>("button/Button");
            buttonFont = _content.Load<SpriteFont>("Fonts/bubblefont");
            Mario= _content.Load<SpriteFont>("Fonts/Pixel");
            pixelFont = _content.Load<SpriteFont>("Fonts/PIPI");
            skater = new Skater(3, new Rectangle(0, skaterY, 300, 300), _content.Load<Texture2D>("sprites_skater/Sprite 12"));

            objects = new List<Obstacle> { new Obstacle(new Rectangle(600, 725, 200, 200), _content.Load<Texture2D>("Objects/Pipes Sprite 33"), speed, Rndchar()),
                new Obstacle(new Rectangle(1600, 725, 200, 200), _content.Load<Texture2D>("Objects/Pipes Sprite 34 Variation"), speed, Rndchar()),
             new Obstacle(new Rectangle(2600, 725, 200, 200), _content.Load<Texture2D>("Objects/Banana Sprite 28"), speed, Rndchar()),
             new Obstacle(new Rectangle(3600, 725, 200, 200), _content.Load<Texture2D>("Objects/Lower Obstacle Sprite 32"), speed, Rndchar())};


            scrolling1 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(0, 0, 1280, 1024), skater, speed);
            scrolling2 = new Scrolling(_content.Load<Texture2D>("Background/alternative"), new Rectangle(1280, 0, 1280, 1024), skater, speed);

            //banana = new Obstacle(new Rectangle(, 725, 200, 200), _content.Load<Texture2D>("Objects/Cone Sprite 30"), speed);
            //pipe = new Pipe( new Rectangle (500,725,200,200),_content.Load<Texture2D>("Objects/Pipes Sprite 33"),speed,500);
            var menubutton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(50, 50),
                Text = "Menu",
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
            spriteBatch.Draw(objects[helpin].sprite, objects[helpin].size, Color.White);
            spriteBatch.Draw(objects[helpin + 1].sprite, objects[helpin + 1].size, Color.White);
            spriteBatch.Draw(objects[helpin + 2].sprite, objects[helpin + 2].size, Color.White);
            spriteBatch.Draw(objects[helpin + 3].sprite, objects[helpin + 3].size, Color.White);
            spriteBatch.DrawString(font,"Lifes:", new Vector2(50,150), Color.Black);
            spriteBatch.DrawString(font, skater.lifes.ToString(), new Vector2(250,150), Color.Red);
            spriteBatch.DrawString(pixelFont, objects[helpin].leather.ToString(), new Vector2(objects[helpin].size.X + 70, 700), Color.White);
            spriteBatch.DrawString(pixelFont, objects[helpin + 1].leather.ToString(), new Vector2(objects[helpin + 1].size.X + 70, 700), Color.White);
            spriteBatch.DrawString(pixelFont, objects[helpin + 2].leather.ToString(), new Vector2(objects[helpin + 2].size.X + 70, 700), Color.White);
            spriteBatch.DrawString(pixelFont, objects[helpin + 3].leather.ToString(), new Vector2(objects[helpin + 3].size.X + 70, 700), Color.White);
            spriteBatch.Draw(skater.skatersprite, skater.size, skater.color);
            if (skater.lifes == 0)
            {
             spriteBatch.DrawString(Mario,"GAME OVER", new Vector2(230, 400), Color.Black);
            }


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
            if (klok <=1)
            {
                frametimer--;
            }
            if (klok>1)
            {
                frametimer = frametimer - 2;
            }
            frametimmerfall--; 
            if (frametimer < 0)
            {
                frametimer = 0;
            }
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
            hitbox1 = 130;
            hitbox2 = 250;
            hitbox3 = 100;
            hitbox4 = 0;
            #region pipe1
            for (int i = 0; i < 4; i++)
            {
                if (_currentkey.IsKeyUp(objects[i].leather) && _previouskey.IsKeyDown(objects[i].leather) && objects[i].size.X >= hitbox1 && objects[i].size.X <= hitbox2 && flagkey1 == false)
                {
                    
                    flagkey = true;
                    frametimer = 60;
                    flagkey1 = true;

                }
                if (flagkey == true && objects[i].size.X >= hitbox1)
                {
                    Jump(frametimer, skater, flagkey);

                }


                else if (objects[i].size.X <= hitbox3 && objects[i].size.X > hitbox4 && skater.lifes > 0 && colision == false && flagkey == false)
                {
                    skater.lifes -= 1;

                    skater.color = Color.Red;
                    timer = 30;
                    colision = true;


                }
                if (objects[i].size.X < -200)
                {
                    NextObject(i);
                    objects[i].leather = Rndchar();
                }


            }
            if (loop == 5 && level2 == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    objects[i].speed += 2;


                }
                scrolling1.speed += 2;
                scrolling2.speed += 2;
                level2 = true;
                klok++;

                loop = 0;
            }
            if (loop == 0)
            {
                level2 = false;
                
            }

            #endregion

            if (timer == 0)
            {
                skater.color = Color.White;
                colision = false;

            }
            if (skater.lifes == 0)
            {
                objects[0].speed = 0;
                objects[1].speed = 0;
                objects[2].speed = 0;
                objects[3].speed = 0;
                scrolling1.speed = 0;
                scrolling2.speed = 0;
                frametimmerfall = 60;
                gameover1 = true;

                if (state.IsKeyDown(Keys.Space))
                    _game.ChangeState(new Gamestate(_game, _graphicsDevice, _content));
            }

            if (gameover1 == true)
            {
                fall(frametimmerfall, skater);
            }



            scrolling1.Update();
            scrolling2.Update();
            objects[0].Update();
            objects[1].Update();
            objects[2].Update();
            objects[3].Update();


            // pobiera co jest wcisniete

            if (state.IsKeyDown(Keys.Escape))
                _game.ChangeState(new Menustate(_game, _graphicsDevice, _content));






        }
    }
}