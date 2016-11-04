using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//inspired by http://www.dofactory.com/net/observer-design-pattern
namespace BlackJack.controller
{
    interface ICardDrawnObserver
    {
        void update(model.Game a_game);
    }
}
