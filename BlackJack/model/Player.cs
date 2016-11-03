using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack;

namespace BlackJack.model
{
    class Player : Subject
    {
        private List<Card> m_hand = new List<Card>();
        private Card card;
        private model.Game _game;
        private view.IView _view;

        public Player(model.Game game, view.IView view)
        {
            _game = game;
            _view = view;
            addObserver("Player");
        }

        public void DealCard(Card a_card)
        {
            m_hand.Add(a_card);
            notify(_game, _view);
        }

        public void DealShownCardFromDeck(Deck a_deck)
        {
            card = a_deck.GetCard();
            card.Show(true);
            DealCard(card);
        }

        public void DealHiddenCardFromDeck(Deck a_deck)
        {
            card = a_deck.GetCard();
            DealCard(card);
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public int CalcScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }
    }
}
