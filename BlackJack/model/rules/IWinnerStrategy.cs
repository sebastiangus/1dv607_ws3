using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.model.rules
{
    interface IWinnerStrategy
    {
        bool isDealerWinner(model.Player a_player, model.Dealer a_dealer);
    }
}


