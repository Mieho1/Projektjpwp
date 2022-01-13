using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Projektjpwp.Objects
{
   public class Skater
    {
        private Texture2D _texture;
        public Vector2 Position;

        public Skater(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
          



        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);

        }
    }
}
