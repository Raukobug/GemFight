using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Wizard : Player
    {

        private bool _extraTurn;

        public Wizard(Texture2D spriteTexture, Vector2 position, bool hasTurn)
            : base(spriteTexture, position, hasTurn)
        {
        }

        public override void CursorSetup1()
        {
            if (HasTurn)
            {
            Game.Cursor1.SetPosition(TheBoard.Pos[12]);
            Game.Cursor2.SetPosition(TheBoard.Pos[13]);
            Game.Cursor3.SetPosition(TheBoard.Pos[7]);
            Game.Cursor4.SetPosition(TheBoard.Pos[8]);
            Game.Cursor5.SetPosition(TheBoard.Pos[2]);
            Game.Cursor6.SetPosition(TheBoard.Pos[3]);
            SelectCursorSetup = 1;
            }
        }
        public override void CursorSetup2()
        {
            if (HasTurn)
            {
                Game.Cursor1.SetPosition(TheBoard.Pos[0]);
                Game.Cursor2.SetPosition(TheBoard.Pos[7]);
                Game.Cursor3.SetPosition(TheBoard.Pos[14]);
                Game.Cursor4.SetPosition(TheBoard.Pos[20]);
                Game.Cursor5.SetPosition(TheBoard.Pos[25]);
                Game.Cursor6.SetPosition(TheBoard.Pos[30]);
                SelectCursorSetup = 2;
            }
        }
        public override void CursorSetup3()
        {
            if (HasTurn)
            {
                Game.Cursor1.SetPosition(TheBoard.Pos[0]);
                Game.Cursor2.SetPosition(TheBoard.Pos[1]);
                Game.Cursor3.SetPosition(TheBoard.Pos[6]);
                Game.Cursor4.SetPosition(TheBoard.Pos[7]);
                Game.Cursor5.SetPosition(TheBoard.Pos[12]);
                Game.Cursor6.SetPosition(TheBoard.Pos[13]);
                SelectCursorSetup = 3;
            }
        }

        public override void ButtonADown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                if (_extraTurn)
                {
                    _extraTurn = false;
                }
                else
                {
                    Handler.SwitchPlayer(this);
                    Enemy.CursorSetup1();
                }
            } 
        }
        public override void ButtonXDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                Ability1();
            }
        }

        public override void ButtonBDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                Ability3();
            }
        }

        public override void ButtonYDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                Ability2();
            }
        }

        public override void ButtonLeftShoulderDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn)
            {
                if (buttonStates == InputController.ButtonStates.JustPressed)
                {
                    switch (SelectCursorSetup)
                    {
                        case 1:
                            CursorSetup3();
                            break;
                        case 2:
                            CursorSetup1();
                            break;
                        case 3:
                            CursorSetup2();
                            break;
                    }
                }
            }
        }

        public override void ButtonRightShoulderDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn)
            {
                if (buttonStates == InputController.ButtonStates.JustPressed)
                {
                    switch (SelectCursorSetup)
                    {
                        case 1:
                            CursorSetup2();
                            break;
                        case 2:
                            CursorSetup3();
                            break;
                        case 3:
                            CursorSetup1();
                            break;
                    }
                }
            }
        }

        public override void Ability1()
        {
            Animation = new Animation(this) { Delay = 20, Loop = false };
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 7, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 7, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 8, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 8, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 9, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 9, ImageHeight, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 7, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 7, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 8, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 8, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 9, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 9, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 7, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 7, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 8, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 8, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 9, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 9, ImageHeight * 3, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(0, 0, ImageWidth, ImageHeight));
            if (RedGems >= 3 && GreenGems >= 3)
            {
                RedGems = RedGems - 3;
                GreenGems = GreenGems - 3;

                Enemy.DoDmg(6, false);
            }
        }

        public override void Ability2()
        {
            if (YellowGems >= 20)
            {
                YellowGems = YellowGems - 20;
                Enemy.DoDmg(25, true);
            }
        }

        public override void Ability3()
        {
            if (BlueGems >= 10)
            {
                BlueGems = BlueGems - 10;
                _extraTurn = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Animation != null)
            {
                Animation.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Do we have a texture? If not then there is nothing to draw...
            if (SpriteTexture != null)
            {
                // Has a source rectangle been set?
                if (SourceRectangle.IsEmpty)
                {
                    // No, so draw the entire sprite texture
                    spriteBatch.Draw(SpriteTexture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0f);
                }
                else
                {
                    // Yes, so just draw the specified SourceRect
                    spriteBatch.Draw(SpriteTexture, Position, SourceRectangle, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0f);
                }
            }
        }
    }
}
