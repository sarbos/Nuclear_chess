using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace NuclearChess
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		//Texture2D grid;
        //pieces texture to be slip up
		Texture2D pieces;
        //black pixel
        Texture2D bpixel;
        //white pixel
        Texture2D wPixel;
        //radioactive square
        Texture2D radioactive;

        Rectangle WKing = new Rectangle(16, 16, 44, 44);
        Rectangle WQueen = new Rectangle(75, 13, 45, 40);
        Rectangle WRook = new Rectangle(144,15,33,39);
        Rectangle WBishop;
        Rectangle WKnight;
        Rectangle WPawn = new Rectangle(332,12,28,40);

        Rectangle BKing = new Rectangle(16, 74, 44, 44);
        Rectangle BQueen = new Rectangle(75, 74, 45, 40);
        Rectangle BRook = new Rectangle(144, 74, 33, 39);
        Rectangle BBishop;
        Rectangle BKnight;
        Rectangle BPawn = new Rectangle(332, 74, 28, 40);

        piece[] whitepieces = new piece[16];
        piece[] blackpieces = new piece[16];


        piece p = new piece();

		tile[,] grid = new tile[8,8];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           // grid = Content.Load<Texture2D>("chessboard");
            pieces = Content.Load<Texture2D>("Chess_symbols");
            bpixel = Content.Load<Texture2D>("BlackPixel");
            wPixel = Content.Load<Texture2D>("WhitePixel");
            radioactive = Content.Load<Texture2D>("Radioactive");
            // TODO: use this.Content to load your game content here

            int curx = 50;
            int cury = 50;
            bool black = false;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Texture2D col;
                    if (black) { col = bpixel; }
                    else { col = wPixel; }
                    grid [x, y] = new tile(new Rectangle(curx, cury, 100, 100), x, y, black, col);
                    grid [x, y].Fallout = radioactive;
                    black = !black;
                    cury += 100;
                }
                black = !black;
                cury = 50;
                curx += 100;
            }

            //initialize white pawns
            for (int i = 0; i < 8; i++) 
            {
                whitepieces[i] = new piece("Pawn", grid[i,1], pieces, WPawn);
            }
            for (int i = 0; i < 8; i++)
            {
                blackpieces[i] = new piece("Pawn", grid[i, 6], pieces, BPawn);
            }
            //p  = new piece("King", grid[2, 1], pieces, WKing);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) 
            {
                p.move(grid[5, 6]);
            }
			/*Rectangle area = someRectangle;

			// Check if the mouse position is inside the rectangle
			if (area.Contains(mousePosition))
			{
				backgroundTexture = hoverTexture;
			}
			else
			{
				backgroundTexture = defaultTexture;
			}*/
            // TODO: Add your update logic here

            //Random r = new Random();
            //int x = r.Next(8);
            //int y = r.Next(8);
            //grid[x, y].fallout = !grid[x, y].fallout;

            //base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
			this.IsMouseVisible = true;
            // TODO: Add your drawing code here
            spriteBatch.Begin();
			foreach(tile t in grid)
			{
				t.Draw(spriteBatch);
			}
            foreach (piece p in whitepieces) 
            {
                if (p!=null)
                    p.Draw(spriteBatch);
            }
            foreach (piece p in blackpieces)
            {
                if (p != null)
                    p.Draw(spriteBatch);
            }
            //spriteBatch.Draw(grid, new Rectangle(boardXoffset, boardYoffset, 800, 800), Color.White);
           // spriteBatch.Draw(pieces, new Rectangle(400, 80, 44, 44), WKing, Color.White);
          //  spriteBatch.Draw(pieces, new Rectangle(230, 80, WQueen.Width, WQueen.Height), WQueen, Color.White);
          //  spriteBatch.Draw(pieces, new Rectangle(135, 80, WRook.Width, WRook.Height), WRook, Color.White);
          //  spriteBatch.Draw(pieces, new Rectangle(830, 80, WRook.Width, WRook.Height), WRook, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
