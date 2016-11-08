using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;
using BlackJack.controller;

//inspired by http://www.dofactory.com/net/observer-design-pattern
namespace BlackJack.model
{
    abstract class observerSubject
    {
        protected model.Game _game;

        private string _name;
        private List<ICardDrawnObserver> _o = new List<ICardDrawnObserver>();

        public void addObserver(string name, controller.ICardDrawnObserver concreteObserver, model.Game game) {
            _o.Add(concreteObserver);
            _game = game;
            _name = name;
        
        }

        public void notify() {
            foreach(ICardDrawnObserver observer in _o)
            {
                observer.update(_game);
            }
        }
    }
}
