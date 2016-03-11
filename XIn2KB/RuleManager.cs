using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XInputDotNetPure;

namespace XIn2KB
{
    class RuleManager
    {
        protected HashSet<Rule> rules_1;
        protected HashSet<Rule> rules_2;
        protected HashSet<Rule> rules_3;
        protected HashSet<Rule> rules_4;
        public RuleManager()
        {
            rules_1 = new HashSet<Rule>();
            rules_2 = new HashSet<Rule>();
            rules_3 = new HashSet<Rule>();
            rules_4 = new HashSet<Rule>();
        }

        public void addRule(Rule rule, PlayerIndex playerIndex)
        {
            switch (playerIndex)
            {
                case PlayerIndex.One:
                    rules_1.Add(rule);
                    break;
                case PlayerIndex.Two:
                    rules_2.Add(rule);
                    break;
                case PlayerIndex.Three:
                    rules_3.Add(rule);
                    break;
                case PlayerIndex.Four:
                    rules_4.Add(rule);
                    break;
            }            
        }

        public void runRules()
        {
            for(int i=1; i<5; i++)
            {
                HashSet<Rule> currentSet = rules_1;
                PlayerIndex currentPlayer = PlayerIndexHelper.Int32ToPlayerIndex(i);
                switch (i)
                {
                    case 1:
                        currentSet = rules_1;                        
                        break;
                    case 2:
                        currentSet = rules_2;                        
                        break;
                    case 3:
                        currentSet = rules_3;                        
                        break;
                    case 4:
                        currentSet = rules_4;                        
                        break;
                }
                GamePadState state = GamePad.GetState(currentPlayer);
                if(state.IsConnected)
                {
                    bool[] used = new bool[25];
                    if(state.Triggers.Left != 0)
                    {
                        used[0] = true;
                    }
                    if (state.Triggers.Right != 0)
                    {
                        used[1] = true;
                    }
                    if(state.DPad.Up.Equals(ButtonState.Pressed))
                    {
                        used[2] = true;
                    }
                    if (state.DPad.Right.Equals(ButtonState.Pressed))
                    {
                        used[3] = true;
                    }
                    if (state.DPad.Down.Equals(ButtonState.Pressed))
                    {
                        used[4] = true;
                    }
                    if (state.DPad.Left.Equals(ButtonState.Pressed))
                    {
                        used[5] = true;
                    }
                    if (state.Buttons.Start.Equals(ButtonState.Pressed))
                    {
                        used[6] = true;
                    }
                    if (state.Buttons.Back.Equals(ButtonState.Pressed))
                    {
                        used[7] = true;
                    }
                    if (state.Buttons.LeftStick.Equals(ButtonState.Pressed))
                    {
                        used[8] = true;
                    }
                    if (state.Buttons.RightStick.Equals(ButtonState.Pressed))
                    {
                        used[9] = true;
                    }
                    if (state.Buttons.LeftShoulder.Equals(ButtonState.Pressed))
                    {
                        used[10] = true;
                    }
                    if (state.Buttons.RightShoulder.Equals(ButtonState.Pressed))
                    {
                        used[11] = true;
                    }
                    if (state.Buttons.Guide.Equals(ButtonState.Pressed))
                    {
                        used[12] = true;
                    }
                    if (state.Buttons.A.Equals(ButtonState.Pressed))
                    {
                        used[13] = true;
                    }
                    if (state.Buttons.B.Equals(ButtonState.Pressed))
                    {
                        used[14] = true;
                    }
                    if (state.Buttons.X.Equals(ButtonState.Pressed))
                    {
                        used[15] = true;
                    }
                    if (state.Buttons.Y.Equals(ButtonState.Pressed))
                    {
                        used[16] = true;
                    }
                    if (state.ThumbSticks.Left.X < 0)
                    {
                        used[17] = true;
                    }
                    if (state.ThumbSticks.Left.X > 0)
                    {
                        used[18] = true;
                    }
                    if (state.ThumbSticks.Left.Y < 0)
                    {
                        used[19] = true;
                    }
                    if (state.ThumbSticks.Left.Y > 0)
                    {
                        used[20] = true;
                    }
                    if (state.ThumbSticks.Right.X < 0)
                    {
                        used[21] = true;
                    }
                    if (state.ThumbSticks.Right.X > 0)
                    {
                        used[22] = true;
                    }
                    if (state.ThumbSticks.Right.Y < 0)
                    {
                        used[23] = true;
                    }
                    if (state.ThumbSticks.Right.Y > 0)
                    {
                        used[24] = true;
                    }

                    foreach(Rule rule in currentSet)
                    {
                        if (used[rule.input] && !rule.invoked)
                            rule.invoke();
                        else if (!used[rule.input] && rule.invoked)
                            rule.devoke();
                    }
                }
            }
        }

        public bool hasRules()
        {
            return rules_1.Count + rules_2.Count + rules_3.Count + rules_4.Count > 0 ?  true : false;
        }
    }
}
