using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            a_player.DealShownCardFromDeck(a_deck);

            a_dealer.DealShownCardFromDeck(a_deck);

            a_player.DealShownCardFromDeck(a_deck);

            a_dealer.DealHiddenCardFromDeck(a_deck);

            return true;
        }
    }
}
