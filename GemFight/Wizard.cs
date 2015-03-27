using System.Web.UI.WebControls;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Wizard : Player
    {

        public Wizard(Texture2D spriteTexture, Vector2 position, bool hasTurn, int playerNumber)
            : base(spriteTexture, position, hasTurn, playerNumber)
        {
            WaitAnimation();
            state = State.Wait;
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
                Game.Cursor3.SetPosition(TheBoard.Pos[13]);
                Game.Cursor4.SetPosition(TheBoard.Pos[19]);
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
                if (ExtraTurn)
                {
                    ExtraTurn = false;
                }
                else
                {
                    Handler.SwitchPlayer(this);
                }
                Game.Sound = Game.Content.Load<SoundEffect>("crystalShatter");
                Game.Sound.Play();
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
                    foreach (var curser in Game.ListofCursers)
                    {
                        curser.SelectedSprite = null;
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
                    foreach (var curser in Game.ListofCursers)
                    {
                        curser.SelectedSprite = null;
                    }
                }
            }
        }

        public override void Ability1()
        {
            SpawnSpriteOnFrame = 3;
            state = State.Ability1;
            if (RedGems >= 3 && GreenGems >= 3)
            {
                Game.Sound = Game.Content.Load<SoundEffect>("fireball");
                Animation = new Animation(this) { Delay = 100, Loop = false };
                Animation.Frames.Add(new Rectangle(0, ImageHeight, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(0, 0, ImageWidth, ImageHeight));
                RedGems = RedGems - 3;
                GreenGems = GreenGems - 3;

                Enemy.DoDmg(6, false);
            }
        }

        public override void Ability2()
        {
            state = State.Ability2;
            SpawnSpriteOnFrame = 5;
            if (YellowGems >= 20)
            {
                Game.Sound = Game.Content.Load<SoundEffect>("lightning");
                Animation = new Animation(this) { Delay = 80, Loop = false };
                Animation.Frames.Add(new Rectangle(0, ImageHeight * 2, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 3, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 3, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 3, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 3, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 3, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 3, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 3, ImageWidth, ImageHeight));
                Animation.Frames.Add(new Rectangle(0, 0, ImageWidth, ImageHeight));
                YellowGems = YellowGems - 20;
                Enemy.DoDmg(20, true);
            }
        }

        public override void Ability3()
        {
            Game.Sound = Game.Content.Load<SoundEffect>("ice");
            Animation = new Animation(this) { Delay = 80, Loop = false };
            Animation.Frames.Add(new Rectangle(0, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(0, 0, ImageWidth, ImageHeight));
            SpawnSpriteOnFrame = 5;
            state = State.Ability3;
            if (BlueGems >= 10)
            {

                BlueGems = BlueGems - 10;
                ExtraTurn = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Animation != null)
            {
                Animation.Update(gameTime);
                if (Animation.LastFrame && state != State.Wait)
                {
                    WaitAnimation();
                    state = State.Wait;
                    AbilityCrated = false;
                }
                else
                {
                    if (Animation.CurrentFrame == SpawnSpriteOnFrame && SpawnSpriteOnFrame != 0 && !AbilityCrated)
                    {
                        Ability ability;
                        switch (state)
                        {
                            case State.Ability1:
                                ability = new Ability(Game.Content.Load<Texture2D>("fireball.png"), new Vector2(TheBoard.StartPointx + 650, TheBoard.StartPointy - 100), -5, Enemy, 50,50,60,33,5,Ability.AnimationDirection.Horhorizontal);
                                break;
                            case State.Ability2:
                                ability = new Ability(Game.Content.Load<Texture2D>("Lightning.png"), new Vector2(Enemy.PositionX+50, 0), 5, Enemy, -50,5, 33, 60, 2, Ability.AnimationDirection.Vertical);
                                break;
                            default:
                                ability = new Ability(Game.Content.Load<Texture2D>("ice.png"), new Vector2(TheBoard.StartPointx + 650, TheBoard.StartPointy-40), -15, Enemy, 50,50, 120, 100, 5, Ability.AnimationDirection.Horhorizontal);
                                break;
                        }
                        Game.ListofAbilities.Add(ability);
                        AbilityCrated = true;
                    }
                }
            }
        }

        private void WaitAnimation()
        {
            Animation = new Animation(this) { Delay = 120, Loop = true };
            Animation.Frames.Add(new Rectangle(0, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, 0, ImageWidth, ImageHeight));
        }
    }
}
