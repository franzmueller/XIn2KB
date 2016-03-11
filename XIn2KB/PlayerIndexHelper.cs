using System;
using XInputDotNetPure;

namespace XIn2KB
{
    class PlayerIndexHelper
    {
        public static PlayerIndex Int32ToPlayerIndex(int playerIndex)
        {
            switch (playerIndex)
            {
                case 1:
                    return PlayerIndex.One;                   
                case 2:
                    return PlayerIndex.Two;                    
                case 3:
                    return PlayerIndex.Three;                    
                case 4:
                    return PlayerIndex.Four;
                default:
                    throw new ArgumentException("The value for the PlayerIndex must be between 1 and 4. You used: " + playerIndex);
            }
        }
    }
}
