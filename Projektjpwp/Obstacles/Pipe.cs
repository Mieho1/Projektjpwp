using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Projektjpwp.Backgrounds;

namespace Projektjpwp.Obstacles
{
    public class Pipe
    {
        public bool space = false;
        public Rectangle size;
        public Texture2D sprite;
        public int speed;
        string leather;
        int X;
        
        

        public Pipe(Rectangle size, Texture2D sprite,int speed)
        {
            this.size = new Rectangle (600, 725, 200, 200);
            this.sprite = sprite;
            this.speed = speed;
           

        }
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
                space = true;
            if (space == true )
                size.X -= speed;


        }



    }
}
