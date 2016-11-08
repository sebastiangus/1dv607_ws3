using System;
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


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerStrategy = a_rulesFactory.GetWinnerStrategy();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver(a_player))
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
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver(a_player))
            {
                a_player.DealShownCardFromDeck(m_deck);
                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerStrategy.isDealerWinner(a_player, this);
        }

        public bool IsGameOver(model.Player a_player)
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this, a_player) != true || a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            return false;
        }

        public void Stand(model.Player a_player)
        {
            if(m_deck != null)
            {
                ShowHand();
            }

            while (m_hitRule.DoHit(this, a_player) && this.CalcScore() <= a_player.CalcScore())
            {
                DealShownCardFromDeck(m_deck);
            }
        }

        public int getMaxScore()
        {
            return g_maxScore;
        }
    }
}
