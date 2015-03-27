using System.Web.UI.WebControls;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Monk : Player
    {
        private int _powerUp = 1;
        private bool _move;
        private int _moveSpeed = 20;
        public Monk(Texture2D spriteTexture, Vector2 position, bool hasTurn, int playerNumber)
            : base(spriteTexture, position, hasTurn, playerNumber)
        {
            WaitAnimation();
            state = State.Wait;
        }

        public override void CursorSetup1()
        {
            if (HasTurn)
            {
                Game.Cursor1.SetPosition(TheBoard.Pos[0]);
                Game.Cursor2.SetPosition(TheBoard.Pos[7]);
                Game.Cursor3.SetPosition(TheBoard.Pos[12]);
                Game.Cursor4.SetPosition(TheBoard.Pos[14]);
                Game.Cursor5.SetPosition(TheBoard.Pos[19]);
                Game.Cursor6.SetPosition(TheBoard.Pos[26]);
                SelectCursorSetup = 1;
            }
        }
        public override void CursorSetup2()
        {
            if (HasTurn)
            {
                Game.Cursor1.SetPosition(TheBoard.Pos[0]);
                Game.Cursor2.SetPosition(TheBoard.Pos[6]);
                Game.Cursor3.SetPosition(TheBoard.Pos[12]);
                Game.Cursor4.SetPosition(TheBoard.Pos[18]);
                Game.Cursor5.SetPosition(TheBoard.Pos[24]);
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
                Game.Cursor3.SetPosition(TheBoard.Pos[2]);
                Game.Cursor4.SetPosition(TheBoard.Pos[6]);
                Game.Cursor5.SetPosition(TheBoard.Pos[7]);
                Game.Cursor6.SetPosition(TheBoard.Pos[8]);
                SelectCursorSetup = 3;
            }
        }

        public override void ButtonADown(InputController.ButtonStates buttonStates)
        {

            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                Handler.SwitchPlayer(this);
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
            state = State.Ability1;
            Walk();
            if (YellowGems >= 5)
            {
                YellowGems = YellowGems - 5;
                Enemy.DoDmg(5 * _powerUp, false);
                _powerUp = 1;
            }
        }
        public override void Ability2()
        {
            Game.Sound = Game.Content.Load<SoundEffect>("EarthShatter");
            Animation = new Animation(this) { Delay = 40, Loop = false };
            Animation.Frames.Add(new Rectangle(0, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 7, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 8, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 9, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 8, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 7, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 1, ImageHeight * 2, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(0, ImageHeight * 2, ImageWidth, ImageHeight));
            state = State.Ability2;
            SpawnSpriteOnFrame = 8;
            if (GreenGems >= 20)
            {
                GreenGems = GreenGems - 20;
                Enemy.DoDmg(25, false);
            }
        }
        public override void Ability3()
        {
            if (RedGems >= 5 && BlueGems >= 5)
            {
                RedGems = RedGems - 5;
                BlueGems = BlueGems - 5;
                foreach (var gem in Game.ListOfGems)
                {
                    if (gem.GemColor == GemColor.Black)
                    {
                        gem.ConvertGemColor(GemColor.Yellow);
                    }
                }
                _powerUp++;
            }
        }
        public override void Update(GameTime gameTime)
        {
            DoAbility1();
            if (Animation != null)
            {
                Animation.Update(gameTime);
                if (Animation.LastFrame && state != State.Wait)
                {
                    if (!_move)
                    {
                        WaitAnimation();
                        state = State.Wait;
                        AbilityCrated = false;
                    }
                }
                else
                {
                    if (Animation.CurrentFrame == SpawnSpriteOnFrame && SpawnSpriteOnFrame != 0 && !AbilityCrated)
                    {
                        Ability ability = null;
                        switch (state)
                        {
                            //    case State.Ability1:
                            //        ability = new Ability(Game.Content.Load<Texture2D>("MonkLightning.png"), new Vector2(TheBoard.StartPointx + 650, TheBoard.StartPointy - 100), -5, Enemy, 50, 50, 60, 33, 5, Ability.AnimationDirection.Horhorizontal);
                            //        break;
                            case State.Ability2:
                                ability = new Ability(Game.Content.Load<Texture2D>("EarthShatter.png"), new Vector2(200, 0), -5, Enemy, -50, 10, 250, 300, 5, Ability.AnimationDirection.Horhorizontal);
                                ability = new Ability(Game.Content.Load<Texture2D>("EarthShatter.png"), new Vector2(Enemy.PositionX+80,TheBoard.StartPointy-235),20,Enemy,500,10,250,300,5, Ability.AnimationDirection.Horhorizontal);
                                break;
                            //    default:
                            //        ability = new Ability(Game.Content.Load<Texture2D>("ice.png"), new Vector2(TheBoard.StartPointx + 650, TheBoard.StartPointy - 40), -15, Enemy, 50, 50, 120, 100, 5, Ability.AnimationDirection.Horhorizontal);
                            //break;
                        }
                        if (ability != null)
                        {
                            Game.ListofAbilities.Add(ability);
                        }

                        AbilityCrated = true;
                    }
                }
            }
        }
        private void WaitAnimation()
        {
            Animation = new Animation(this) { Delay = 120, Loop = false };
            Animation.Frames.Add(new Rectangle(0, 0, ImageWidth, ImageHeight));
        }

        private void Walk()
        {
            Animation = new Animation(this) { Delay = 80, Loop = true };
            Animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 2, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 5, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 4, 0, ImageWidth, ImageHeight));
            Animation.Frames.Add(new Rectangle(ImageWidth * 3, 0, ImageWidth, ImageHeight));
            _move = true;
        }

        private void DoAbility1()
        {
            if (_move)
            {
                PositionX = PositionX + _moveSpeed;
                if (PositionX >= Enemy.PositionX)
                {
                    if (!AbilityCrated)
                    {
                        _moveSpeed = 0;
                        Animation = null;
                        Animation = new Animation(this) { Delay = 80, Loop = false };
                        Animation.Frames.Add(new Rectangle(0, ImageHeight, ImageWidth, ImageHeight));
                        Animation.Frames.Add(new Rectangle(ImageWidth, ImageHeight, ImageWidth, ImageHeight));
                        Animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight, ImageWidth, ImageHeight));
                        Animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight, ImageWidth, ImageHeight));
                        Animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight, ImageWidth, ImageHeight));
                        Animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight, ImageWidth, ImageHeight));
                        Animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight, ImageWidth, ImageHeight));
                        Animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight, ImageWidth, ImageHeight));
                        AbilityCrated = true;
                    }
                    if (Animation.LastFrame)
                    {
                        _moveSpeed = -20;
                        Walk();
                        AbilityCrated = false;
                    }
                    if (Animation.CurrentFrame == 5)
                    {
                        Game.Sound = Game.Content.Load<SoundEffect>("monkLightning");
                        Game.Sound.Play();
                        Game.Camera.ShakeX = true;
                    }
                }
                if (PositionX <= TheBoard.StartPointx - 65)
                {
                    _move = false;
                    _moveSpeed = 20;
                    state = State.Wait;
                    PositionX = TheBoard.StartPointx - 65;
                    WaitAnimation();
                }
            }
        }
    }
}
