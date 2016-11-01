﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;
        private const int g_softHitLimit = 18;


        public bool DoHit(model.Player a_dealer)
        {
            if (a_dealer.CalcScore() < g_softHitLimit && softHand(a_dealer)) {
                return true;
            } else {
                return a_dealer.CalcScore() < g_hitLimit;
            }
            
        }

        private bool softHand(model.Player a_dealer)
        {
            bool isASoftHand = false;
            int aceCount = 0;
            IEnumerable<BlackJack.model.Card> cards = a_dealer.GetHand();
            foreach(Card card in cards)
            {
                if (card.GetValue() == Card.Value.Ace) {
                    aceCount += 1;
                    }
            }

            isASoftHand = aceCount == 2;

            return isASoftHand;
        }
    }
}
