//using Pokonsole.Source.Core;
//using Pokonsole.Source.Map;
//using Pokonsole.Source.Pokemons;
//using Pokonsole.Source.Systems;
//using System.Xml.Linq;

//public class Program
//{
//    // ENTRY POINT
//    public static void Main(string[] args)
//    {
//        Console.CursorVisible = false;
//        GameManager game = new GameManager();
//        PokemonManager pokemonManager = new PokemonManager();

//        //game._Map.PlaceTile(TileType.PLAYER, game._Player._PosX, game._Player._PosY);

//        //game.Draw();
//        Pokemon pokemon1 = new Pokemon("Pikachu", POKEMON_TYPE.ELECTRIC, 100, 5, 50, 50, 50, 50, 50);
//        Pokemon pokemon2 = new Pokemon("Bulbizarre", POKEMON_TYPE.GRASS, 100, 5, 50, 50, 50, 50, 50);
//        Capacity secondCapa = new Capacity("Charge", POKEMON_TYPE.NORMAL, 10, 100);
//        Capacity firstCapa = new Capacity("Poison", POKEMON_TYPE.POISON, 35, 50, POKEMON_STATUS.POISONED);
//        Capacity thirdCapa = new Capacity("nomDefenseBuff", POKEMON_TYPE.NORMAL, 35, 50);
//        pokemon1.AddCapacity(firstCapa);
//        pokemon1.AddCapacity(secondCapa);
//        pokemon1.AddCapacity(thirdCapa);
//        pokemon2.AddCapacity(firstCapa);
//        pokemon2.AddCapacity(secondCapa);
//        pokemon2.AddCapacity(thirdCapa);
//        pokemon2.AddCapacity(thirdCapa);

//        //Console.WriteLine(firstCapa.Name);
//        //Console.WriteLine(firstCapa.Type);
//        //Console.WriteLine(firstCapa.Power);
//        //Console.WriteLine(firstCapa.Accuracy);

//        CapacityManager capaManager = new CapacityManager();
//        Capacity Capa1 = capaManager.createNewCapacity("Danse Lame", POKEMON_TYPE.NORMAL, 20, 100);
//        capaManager.addDico("Danse Lame", Capa1);
//        //Console.WriteLine(capaManager.Capacitys["Danse Lame"].Name);
//        /*firstCapa.CapacityDamage(pokemon1);*/
//        CombatSystem combatSystem = new CombatSystem();
//        combatSystem.CreateNewCombat(pokemon1, pokemon2);
//        combatSystem.UseAbility(pokemon1, pokemon2, firstCapa);
//        combatSystem.UseAbility(pokemon2, pokemon2, Capa1);
//        combatSystem.UseAbility(pokemon1, pokemon1, firstCapa);

//        while (game._Running)
//        {
//            game.HandleEvent();
//            game.Update();  
//        }
//        //pokemonManager.CreateNewPokemon("Pikachu", POKEMON_TYPE.ELECTRIC, 35, 1, 55, 40, 90, 50, 50);
//        //pokemonManager.SavePokemons();
//        //pokemonManager.LoadPokemons();
//        //Console.WriteLine(pokemonManager.ListAllPokemons[0].Name);
//        game.Quit();
//    }


//    // VARIABLES MEMBRES
//}


using Pokonsole.Source.Core;
using Pokonsole.Source.Core.GameState;
using Pokonsole.Source.Mapping;
using Pokonsole.Source.Pokemons;
using System.Media;

public class Program
{
    // ENTRY POINT
    public static void Main(string[] args)
    {

        Console.CursorVisible = false;
        GameManager game = new GameManager();
        SoundPlayer mainMusic = new SoundPlayer("../../../Source/Utils/main_music.wav");
        GameState gameState = new GameState();
        mainMusic.Play();
        game.Map.LoadMap();
        game.Map.PlaceTile(TileType.PLAYER, game.Player.Position.X, game.Player.Position.Y);
        game.Draw();

        while (gameState._flag != GameState.GAMESTATE.GAME_OVER)
        {
            switch (gameState._flag)
            {
                case GameState.GAMESTATE.MAIN_MENU:
                    gameState.GameStateCheck();
                    break;

                case GameState.GAMESTATE.GAME:

                    do
                    {
                        game.Update();
                        game.HandleEvent();
                    }
                    while (game._Running);
                    game.Quit();
                    break;

                case GameState.GAMESTATE.COMBAT:

                    break;

                case GameState.GAMESTATE.INVENTORY:

                    break;

                case GameState.GAMESTATE.PAUSE:

                    break;

                case GameState.GAMESTATE.GAME_OVER:

                    break;
            }
        }
        
    }
}