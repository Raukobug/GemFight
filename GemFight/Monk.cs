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
        public Monk(Texture2D spriteTexture, Vector2 position, bool hasTurn, int playerNumber)
            : base(spriteTexture, position, hasTurn, playerNumber)
        {
            
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
                Game.sound = Game.Content.Load<SoundEffect>("crystalShatter");
                Game.sound.Play();
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
            if (YellowGems >= 5)
            {
                YellowGems = YellowGems - 5;
                Enemy.DoDmg(5 * _powerUp, false);
                _powerUp = 1;
            }
        }
        public override void Ability2()
        {
            if (GreenGems >= 20)
            {
                GreenGems = GreenGems - 20;
                Enemy.DoDmg(25, false);
            }
        }
        public override void Ability3()
        {
            if (RedGems >= 7 && BlueGems >= 7)
            {
                RedGems = RedGems - 7;
                BlueGems = BlueGems - 7;
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
    }
}
