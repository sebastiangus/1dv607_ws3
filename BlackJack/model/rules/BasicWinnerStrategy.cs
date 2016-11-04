using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model.rules
{
    class BasicWinnerStrategy : IWinnerStrategy
    {
        
        bool IWinnerStrategy.isDealerWinner(Player a_player, Dealer a_dealer)
        {
            int maxScore = a_dealer.getMaxScore();
            int dealerScore = a_dealer.CalcScore();
            int playerScore = a_player.CalcScore();

            if (playerScore > maxScore ) {
                return true;
            }

            else if (dealerScore > maxScore)
            {
                return false;
            }

            return dealerScore >= playerScore;
        }
    }
}
