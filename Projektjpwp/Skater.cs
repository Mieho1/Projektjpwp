using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;


namespace Projektjpwp
{// zycia, wymiary, animacje(ale to w innej klasie)
    public class Skater
    {
        public int lifes;
        public Rectangle size;
        public Texture2D skatersprite;
        public Color color;

        public Skater(int lifes, Rectangle size,Texture2D skatersprite)
        {
            this.lifes = lifes;
            this.size = size;
            this.skatersprite = skatersprite;
            color = Color.White;
        }
        

    }
}
