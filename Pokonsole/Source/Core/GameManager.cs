
namespace Pokonsole.Source.Core
{
    internal class GameManager
    {
        // CONSTRUCTOR
        public GameManager() { }

        // METHODS
        public void HandleEvent() { }
        public void Update()
        {
        }
        public void Draw() { }
        public void Quit() { }
        public bool Running() { return IsRunning; }

        // VARIABLES MEMBRES
        private bool IsRunning = true;

        // CLASSES
        Player.Player m_Player = new Player.Player();
        Pokemon.PokemonManager m_PokemonManager = new Pokemon.PokemonManager();

}
