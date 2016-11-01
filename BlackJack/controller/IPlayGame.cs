using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPlayGame
{
    GameAlternative GetAlternative();
}

public enum GameAlternative {
    NewGame,
    Hit,
    Stand,
    Quit,
    None 
}
