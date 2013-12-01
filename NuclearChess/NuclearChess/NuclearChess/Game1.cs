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

        //used for rectangle rendering
        Texture2D pixel;
        //currently selected tile, 8,8 is essentially null
        Point selectedTile = new Point(8,8);
        //location of selected piece, 8,8 is essentially null
        Point selectedPiece = new Point(8,8);

        Rectangle WKing = new Rectangle(16, 16, 44, 44);
        Rectangle WQueen = new Rectangle(75, 13, 45, 40);
        Rectangle WRook = new Rectangle(144,15,33,39);
        Rectangle WBishop = new Rectangle(200,14,40,35);
        Rectangle WKnight = new Rectangle(264,14,38,35);
        Rectangle WPawn = new Rectangle(332,12,28,40);

        Rectangle BKing = new Rectangle(16, 74, 44, 44);
        Rectangle BQueen = new Rectangle(75, 74, 45, 40);
        Rectangle BRook = new Rectangle(144, 74, 33, 39);
        Rectangle BBishop = new Rectangle(200,74,40,35);
        Rectangle BKnight = new Rectangle(264, 74, 38, 35);
        Rectangle BPawn = new Rectangle(332, 74, 28, 40);

        piece[] whitepieces = new piece[16];
        piece[] blackpieces = new piece[16];


        //piece p = new piece();

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
            IsMouseVisible = true;
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

            pixel = new Texture2D(graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White }); 

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
            whitepieces[8] = new piece("Rook", grid[0,0], pieces, WRook);
            whitepieces[9] = new piece("Rook", grid[7, 0], pieces, WRook);
            whitepieces[10] = new piece("Knight", grid[1,0], pieces, WKnight);
            whitepieces[11] = new piece("Knight", grid[6, 0], pieces, WKnight);
            whitepieces[12] = new piece("Bishop", grid[2, 0], pieces, WBishop);
            whitepieces[13] = new piece("Bishop", grid[5, 0], pieces, WBishop);
            whitepieces[14] = new piece("King", grid[3, 0], pieces, WKing);
            whitepieces[15] = new piece("Queen", grid[4, 0], pieces, WQueen);

            //initialize black pawns
            for (int i = 0; i < 8; i++)
            {
                blackpieces[i] = new piece("Pawn", grid[i, 6], pieces, BPawn);
            }
            blackpieces[8] = new piece("Rook", grid[0, 7], pieces, BRook);
            blackpieces[9] = new piece("Rook", grid[7, 7], pieces, BRook);
            blackpieces[10] = new piece("Knight", grid[1, 7], pieces, BKnight);
            blackpieces[11] = new piece("Knight", grid[6, 7], pieces, BKnight);
            blackpieces[12] = new piece("Bishop", grid[2, 7], pieces, BBishop);
            blackpieces[13] = new piece("Bishop", grid[5, 7], pieces, BBishop);
            blackpieces[14] = new piece("King", grid[3, 7], pieces, BKing);
            blackpieces[15] = new piece("Queen", grid[4, 7], pieces, BQueen);


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
                //p.move(grid[5, 6]);
            }
            updateMouse();
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
            if (selectedTile.X < 8 && selectedTile.Y < 8)
            {
                DrawBorder(grid[selectedTile.X,selectedTile.Y].area, 4, Color.YellowGreen);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Will draw a border (hollow rectangle) of the given 'thicknessOfBorder' (in pixels)
        /// of the specified color.
        ///
        /// By Sean Colombo, from http://bluelinegamestudios.com/blog
        /// </summary>
        /// <param name="rectangleToDraw"></param>
        /// <param name="thicknessOfBorder"></param>
        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }

        MouseState prevm;
        //used to select and deselect tiles as well as perform moves.
        private void updateMouse() 
        {
            MouseState m = Mouse.GetState();

            //check mouse location
            int x = m.X;
            int y = m.Y;

            if (m.LeftButton == ButtonState.Pressed && prevm.LeftButton == ButtonState.Released) 
            {
                if (x < grid[0, 0].area.Left || x > grid[7, 0].area.Right || y < grid[0, 0].area.Top || y > grid[0, 7].area.Bottom)
                {
                    selectedTile.X = 8;
                    selectedTile.Y = 8;
                    selectedPiece.X = 8;
                    selectedPiece.Y = 8;
                }
                else
                {
                    selectedTile.X = ((x - grid[0, 0].area.Left) - (x - grid[0, 0].area.Left) % 100) / 100;
                    selectedTile.Y = ((y - grid[0, 0].area.Top) - (y - grid[0, 0].area.Top) % 100) / 100;

                    //piece in selected tile, and selected piece is null
                    if (grid[selectedTile.X, selectedTile.Y].piece != null) 
                    {
                        selectedPiece.X = selectedTile.X;
                        selectedPiece.Y = selectedTile.Y;
                    }

                    //no piece in the tile and selected piece is not null, move piece, deselect piece and tile
                    else if (grid[selectedTile.X, selectedTile.Y].piece == null && selectedPiece.X != 8) 
                    {
                        grid[selectedPiece.X, selectedPiece.Y].piece.move(grid[selectedTile.X,selectedTile.Y]);
                        selectedPiece.X = 8;
                        selectedPiece.Y = 8;
                        selectedTile.X = 8;
                        selectedTile.Y = 8;
                    }
                }
            }
            prevm = m;

        }
    }
}
