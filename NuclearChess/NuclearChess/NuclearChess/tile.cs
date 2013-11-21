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
        
        int x;
        int y;
        bool black;
        bool fallout;
        piece piece;
        public Rectangle area;
        public Vector2 center;

        tile(int x, int y, bool isBlack, piece p) 
		{
			this.x = x;
			this.y = y;
			this.black = isBlack;
			this.piece = p;
		}
        public tile() { }

        public tile(Rectangle r, Vector2 c, int xname, char yname, bool isblack) 
        {
            area = r;

        }

        public void Initialize() { }

        public void Update() { }

        public void Draw(SpriteBatch sb) { 
		sb.Draw(
		}

    }
}
