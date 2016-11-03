using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;

//inspired by http://www.dofactory.com/net/observer-design-pattern
namespace BlackJack.model
{
    abstract class Subject
    {
        private string _name;
        private List<ICardDrawnObserver> _o = new List<ICardDrawnObserver>();

        public void addObserver(string name) {
            _o.Add(new controller.PlayGame());
            _name = name;
        }

        public void notify(model.Game game, view.IView view) {
            foreach(ICardDrawnObserver observer in _o)
            {
                observer.update(game, view);
            }
        }
    }
}
