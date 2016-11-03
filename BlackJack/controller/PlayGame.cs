using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;


namespace BlackJack.controller
{
    class PlayGame : ICardDrawnObserver
    {
        private void Render(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();

            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
        }
        public bool Play(model.Game a_game, view.IView a_view)
        {
            Render(a_game, a_view);

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            GameAlternative input = a_view.GetAlternative();
            PlayAlternative(input, a_game);

            return input != GameAlternative.Quit;
        }

        public void update(model.Game a_game, view.IView a_view)
        {
            //https://msdn.microsoft.com/en-us/library/d00bd51t(v=vs.110).aspx
            System.Threading.Thread.Sleep(1000);
            Render(a_game, a_view);
        }

        private bool PlayAlternative(GameAlternative input, model.Game a_game)
        {
            switch (input)
            {
                case GameAlternative.NewGame:
                    a_game.NewGame();
                    break;
                case GameAlternative.Hit:
                    a_game.Hit();
                    break;
                case GameAlternative.Stand:
                    a_game.Stand();
                    break;
            }

            return input != GameAlternative.Quit;
        }
    }
}
