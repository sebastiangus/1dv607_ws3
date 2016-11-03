﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerStrategy;


        public Dealer(model.Game game, view.IView view, rules.RulesFactory a_rulesFactory) : base(game, view)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerStrategy = a_rulesFactory.GetWinnerStrategy();
            addObserver("Dealer");
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerStrategy.isDealerWinner(a_player, this);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void Stand()
        {
            if(m_deck != null)
            {
                ShowHand();
            }

            while (m_hitRule.DoHit(this))
            {
                Card c = m_deck.GetCard();
                c.Show(true);
                DealCard(c);
            }
        }

        public int getMaxScore()
        {
            return g_maxScore;
        }
    }
}
