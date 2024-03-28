using Pokonsole.Source.Pokemons;
using Pokonsole.Source.Actors.Player;
using System.Media;

namespace Pokonsole.Source.Systems
{
    internal class CombatSystem
    {
        public CombatSystem() { }

        public void ClearBuffer(ref Player player)
        {
            int line = 1;
            Console.SetCursorPosition(player.Map.Size.X + 4, line);
            Console.Write("                                            ");
            Console.SetCursorPosition(player.Map.Size.X + 4, line + 1);
            Console.Write("                                            ");
            Console.SetCursorPosition(player.Map.Size.X + 4, line + 2);
            Console.Write("                                            ");
            Console.SetCursorPosition(player.Map.Size.X + 4, line + 3);
            Console.Write("                                            ");
            Console.SetCursorPosition(player.Map.Size.X + 4, line + 4);
            Console.Write("                                            ");
            Console.SetCursorPosition(player.Map.Size.X + 4, line + 5);
            Console.Write("                                            ");
            Console.SetCursorPosition(player.Map.Size.X + 4, line);
        }
        public void CreateNewCombat(Player player,Pokemon pokemon1, Pokemon pokemon2)
        {
            SoundPlayer combatMusic = new SoundPlayer("C:/Users/coelh/source/repos/Pokonsole/Pokonsole/Source/Utils/combat_music.wav");
            combatMusic.Play();
            bool ranAway = false;
            bool isPlayerTurn = true;
            int line = 1;
            if (pokemon1 == null || pokemon2 == null) { return; }

            if (pokemon1 != null && pokemon2 != null)
            {
                SetInCombat(pokemon1, pokemon2);
                bool flee = false;
                //Gestion de la boucle principale du combat
                Console.SetCursorPosition(player.Map.Size.X + 4, line);

                Console.Write(pokemon1.Name + " entre en combat contre " + pokemon2.Name);
                while (pokemon1.IsKnockOut == false && pokemon2.IsKnockOut == false)
                {
                    if (pokemon1.Hp <= 0 || pokemon2.Hp <= 0) 
                    { 
                        if (pokemon1.Hp <= 0) { pokemon1.IsKnockOut = true; }
                        if (pokemon2.Hp <= 0) { pokemon2.IsKnockOut = true; }
                    }

                    if (isPlayerTurn)
                    {
                        ClearBuffer(ref player);
                        Console.Write("Player 1's turn :");
                        Console.SetCursorPosition(player.Map.Size.X + 4, line+1);
                        Console.Write("Options de jeu :");
                        Console.SetCursorPosition(player.Map.Size.X + 4, line+2);
                        Console.Write("1. Attaquer");
                        Console.SetCursorPosition(player.Map.Size.X + 4, line+3);

                        Console.Write("2. Utiliser un objet");
                        Console.SetCursorPosition(player.Map.Size.X + 4, line+4);

                        Console.Write("3. Prendre la fuite");
                        Console.SetCursorPosition(player.Map.Size.X + 4, line+5);


                        Console.Write("Choisissez une action : ");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1": //attaquer
                                      // Si le joueur choisit d'attaquer, exécutez l'attaque
                                      //ClearBuffer(ref player);
                                ClearBuffer(ref player);

                                Console.Write("Choisissez une attaque : ");
                                /*for (int i = 0; i < pokemon1.CapacityList.Count; i++) //pokemon1.CapacityList.Size ??
                                {
                                    Console.SetCursorPosition(player.Map.Size.X + 4, line + i + 1); 
                                    Console.Write(i + 1 + " : " + pokemon1.GetCapacity(i).Name);
                                }*/ 

                                //pokemon1.GetAllCapacities
                                string inputAttack = Console.ReadLine();
                                switch (inputAttack)
                                {
                                    case "1":
                                        Console.SetCursorPosition(player.Map.Size.X + 4, line + 2);
                                        Console.Write(pokemon1.Name + " attaque " + pokemon1.GetCapacity(0).Name);
                                        UseAbility(pokemon1, pokemon2, pokemon1.GetCapacity(0));
                                        Console.Write(pokemon2.Hp);
                                        break;
                                    case "2":
                                        Console.SetCursorPosition(player.Map.Size.X + 4, line + 2);
                                        Console.Write(pokemon1.Name + " attaque " + pokemon1.GetCapacity(1).Name);
                                        UseAbility(pokemon1, pokemon2, pokemon1.GetCapacity(1));
                                        Console.Write(pokemon2.Hp);
                                        break;
                                    case "3":
                                        //Console.Write("                                   ");
                                        //Console.SetCursorPosition(player.Map.Size.X + 4, 1);
                                        Console.SetCursorPosition(player.Map.Size.X + 4, line + 2);
                                        Console.Write(pokemon1.Name + " attaque " + pokemon1.GetCapacity(2).Name);
                                        UseAbility(pokemon1, pokemon2, pokemon1.GetCapacity(2));
                                        Console.Write(pokemon2.Hp);
                                        break;
                                    case "4":
                                        Console.SetCursorPosition(player.Map.Size.X + 4, line + 2);
                                        Console.Write(pokemon1.Name + " attaque " + pokemon1.GetCapacity(3).Name);
                                        UseAbility(pokemon1, pokemon2, pokemon1.GetCapacity(3));
                                        Console.Write(pokemon2.Hp);
                                        break;
                                    default:
                                        Console.SetCursorPosition(player.Map.Size.X + 4, line + 2);
                                        // Console.Write("                                   ");
                                        // Console.SetCursorPosition(player.Map.Size.X + 4, 1);
                                        Console.Write("Option invalide. Veuillez entrer un numéro valide");
                                        break;
                                }
                                break;
                            case "2":
                                ClearBuffer(ref player);
                                Console.Write("Choisissez un objet à utiliser : ");
                                for (int i = 0; i < player.Inventory.Items.Count; i++)
                                {
                                    Console.Write(i+1 + " : " + player.Inventory.Items[i].ItemData.Name);
                                }
                                string inputAction = Console.ReadLine();
                                switch (inputAction)
                                {
                                    case "1":
                                        pokemon1.Hp = pokemon1.Hp +30;
                                        Console.Write(pokemon1.Hp);
                                        break;
                                    case "2":
                                        if (pokemon2.IsWild == true)
                                        {
                                            Random randomCatch = new Random();
                                            if(randomCatch.Next(0,100) >= 50)
                                            {
                                                Console.Write("catched");
                                                pokemon2.IsWild = false;
                                                //ajouter à mon équipe
                                                pokemon2.IsKnockOut = true;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    default:
                                        Console.Write("Option invalide. Veuillez entrer un numéro valide");
                                        break;
                                }
                                break;
                            // Ajoutez d'autres cas pour gérer d'autres options...
                            case "3":
                                ClearBuffer(ref player);
                                //pokemon1.IsKnockOut = true;
                                flee = true;
                                Console.Write("                                   ");
                                Console.SetCursorPosition(player.Map.Size.X + 4, 1);
                                Console.Write("Vous avez fuit le combat");
                                break;
                            default:
                                Console.Write("                                   ");
                                Console.SetCursorPosition(player.Map.Size.X + 4, 1);
                                Console.Write("Option invalide. Veuillez entrer un numéro valide.");
                                break;
                        }
                    }
                    else //IA Turn
                    {
                        Console.Write(pokemon2.Name + "turn :");
                        if (pokemon2.IsWild == false)
                        {
                            var randomIAMove = new Random();
                            UseAbility(pokemon2, pokemon1, pokemon2.GetCapacity(randomIAMove.Next(1, 4)));
                            //Console.Write(pokemon2.Name + " a utilisé" + pokemon2.GetCapacity(randomIAMove.Next(1, 4)).Name + " sur " + pokemon1.Name);
                        }
                        else
                        {
                            var randomIAMove = new Random();
                            if (randomIAMove.Next(0, 100) >= 90)
                            {
                                //random attack entre capa 1 à 4
                                UseAbility(pokemon2, pokemon1, pokemon2.GetCapacity(randomIAMove.Next(1, 4)));
                                //Console.Write(pokemon2.Name + " a utilisé" + pokemon2.GetCapacity(randomIAMove.Next(1, 4)).Name + " sur " + pokemon1.Name);
                            }
                            else
                            {
                                //Fuite du pokémon
                                pokemon2.onCombatExit();
                                ranAway = true;
                                pokemon2.IsKnockOut = true;
                            }
                        }
                    }

                    if (flee) break;

                    isPlayerTurn = !isPlayerTurn;
                }

                //Gestion de fin de combat : 
                if (pokemon1.IsKnockOut == true || pokemon2.IsKnockOut == true)
                {
                    UnsetInCombat(pokemon1, pokemon2);
                    //victoire joueur
                    if (pokemon1.IsKnockOut == false && pokemon2.IsKnockOut == true)
                    {
                        pokemon1.onCombatVictory();
                        if (ranAway == false)
                        {
                            pokemon2.onCombatDefeate();
                        }
                    }
                    //victoire IA
                    else if (pokemon1.IsKnockOut == true && pokemon2.IsKnockOut == false)
                    {
                        pokemon2.onCombatVictory();
                        pokemon1.onCombatDefeate();
                    }
                }

            }
            combatMusic.Stop();
        }

        public void SetInCombat(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1 == null || pokemon2 == null) { return; }
            else if (pokemon1 != null && pokemon2 != null)
            {
                if (pokemon1.IsInCombat == false && pokemon2.IsInCombat == true) { return; }
                if (pokemon1.IsInCombat == true && pokemon2.IsInCombat == false) { return; }

                //setting in combat
                else if (pokemon1.IsInCombat == false && pokemon2.IsInCombat == false)
                {
                    pokemon1.IsInCombat = true;
                    pokemon2.IsInCombat = true;
                }
            }
        }

        public void UnsetInCombat(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1 == null || pokemon2 == null) { return; }
            else if (pokemon1 != null && pokemon2 != null)
            {
                if (pokemon1.IsInCombat == false && pokemon2.IsInCombat == true) { return; }
                if (pokemon1.IsInCombat == true && pokemon2.IsInCombat == false) { return; }

                //unsetting in combat
                else if (pokemon1.IsInCombat == true && pokemon2.IsInCombat == true)
                {
                    pokemon1.IsInCombat = false;
                    pokemon2.IsInCombat = false;
                }
            }
        }

        public void UseAbility(Pokemon attacker, Pokemon target, Capacity capacity)
        {
            if (attacker == null || target == null || capacity == null) { return; }

            // Vérifiez si l'attaquant est en combat
            if (!attacker.IsInCombat)
            {
                Console.Write(attacker.Name + " is not in combat.");
                return;
            }

            // Vérifiez si le Pokémon attaquant a la capacité spécifiée
            /*if (!attacker.CapacityList.Contains(capacity.Name))
            {
                Console.Write(attacker._Name + " does not have the " + capacity.Name + " ability.");
                return;
            }*/

            // Affichez un message pour indiquer que la capacité a été utilisée
            Console.Write(attacker.Name + " used " + capacity.Name + " on " + target.Name + ".");

            // Utilisez la capacité sur la cible

            capacity.IsAttackMissed();
            if (capacity.AttackMissed == true)
            {
                Console.Write(attacker.Name + " has missed his attack on " + target.Name);
                Console.Write(target.Name + " has " + target.Hp + " pv left ! ");
                Console.Write(target.Name + " is " + target.Status);
                return;
            }
            else if (capacity.AttackMissed != true)
            {
                capacity.CapacityDamage(target);
                Console.Write(attacker.Name + " has damaged " + target.Name + " up to " + capacity.Power + " damage !");
                Console.Write(target.Name + " has " + target.Hp + " pv left ! ");

            }
            if (capacity.Status != POKEMON_STATUS.NORMAL)
            {
                target.Status = capacity.Status;
                Console.Write(target.Name + " is " + target.Status);
            }

        }
    }
}
