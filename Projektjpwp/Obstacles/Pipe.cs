using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Projektjpwp.Obstacles
{
    public class Pipe
    {
        public bool space = false;
        public Rectangle size;
        public Texture2D sprite;

        public Pipe(Rectangle size, Texture2D sprite)
        {
            this.size = size;
            this.sprite = sprite;

        }
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Space))
                space = true;
            if (space == true)
                size.X -= 5;


        }



    }
}
