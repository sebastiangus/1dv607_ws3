using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class BasicHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer, model.Player a_player)
        {
            if(a_dealer.CalcScore() > a_player.CalcScore())
            {
                return false;
            }
            return a_dealer.CalcScore() < g_hitLimit || a_dealer.CalcScore() < a_player.CalcScore();
        }
    }
}
