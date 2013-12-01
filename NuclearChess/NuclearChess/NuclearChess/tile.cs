using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace NuclearChess
{

    class tile
    {
        
        public int x;
        public int y;
        bool black;
        public bool fallout;
        public piece piece;
        public Rectangle area;
        public Vector2 center;
		Texture2D color;
        public Texture2D Fallout;
       
		//tile(int x, int y, bool isBlack, piece p) 
		//{
		//    this.x = x;
		//    this.y = y;
		//    this.black = isBlack;
		//    this.piece = p;
		//}
        public tile() { }

        public tile(Rectangle r, int xname, int yname, bool isblack, Texture2D t) 
        {
            area = r;
			this.x = xname;
			this.y = yname;
			black = isblack;
			this.color = t;
            fallout = false;
            center = new Vector2(area.X + (area.Width / 2), area.Y + (area.Height / 2));

        }

        public void Initialize() { }

        public void Update() { }

        public void Draw(SpriteBatch sb) { 
			//Color c = (black == false) ? Color.White : Color.Black;
            if (fallout)
            {
                sb.Draw(Fallout, area, Color.White);
            }
            else 
            {
                sb.Draw(color, area, Color.White);
            }
			
		}


    }
}
