using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine.Interface
{
    public interface IGame
    {
        bool LoadPlayerCharacter(int id);

        bool LoadNewPlayerCharacter();

        bool StartGame();
    }
}
