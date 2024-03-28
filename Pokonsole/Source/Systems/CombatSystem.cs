using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokonsole.Source.Pokemons;
using Pokonsole.Source.Accessories;
using Pokonsole.Source.Items;
using Pokonsole.Source.Items.Balls;
using Pokonsole.Source.Items.Potions;
using Pokonsole.Source.Actors;
using Pokonsole.Source.Actors.Player;
using System.Media;

namespace Pokonsole.Source.Systems
{
    internal class CombatSystem
    {
        public CombatSystem() { }
        public void CreateNewCombat(Player player,Pokemon pokemon1, Pokemon pokemon2)
        {
            SoundPlayer combatMusic = new SoundPlayer("C:/Users/coelh/source/repos/Pokonsole/Pokonsole/Source/Utils/combat_music.wav");
            combatMusic.Play();
            bool ranAway = false;
            bool isPlayerTurn = true;
            if (pokemon1 == null || pokemon2 == null) { return; }

            if (pokemon1 != null && pokemon2 != null)
            {
                SetInCombat(pokemon1, pokemon2);
                //Gestion de la boucle principale du combat
                while (pokemon1.IsKnockOut == false && pokemon2.IsKnockOut == false)
                {
                    if (pokemon1.Hp <= 0 || pokemon2.Hp <= 0) 
                    { 
                        if (pokemon1.Hp <= 0) { pokemon1.IsKnockOut = true; }
                        if (pokemon2.Hp <= 0) { pokemon2.IsKnockOut = true; }
                    }

                    if (isPlayerTurn)
                    {

                        Console.WriteLine("Player 1's turn :");
                        Console.WriteLine("Options de jeu :");
                        Console.WriteLine("1. Attaquer");
                        Console.WriteLine("2. Utiliser un objet");

                        Console.Write("Choisissez une action : ");
                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1": //attaquer
                                // Si le joueur choisit d'attaquer, exécutez l'attaque
                                Console.WriteLine("Choisissez une attaque : ");
                                for (int i = 0; i < pokemon1.CapacityList.Count; i++) //pokemon1.CapacityList.Size ??
                                {

                                    Console.WriteLine(i + 1 + " : " + pokemon1.GetCapacity(i).Name);

                                }

                                //pokemon1.GetAllCapacities
                                string inputAttack = Console.ReadLine();
                                switch (inputAttack)
                                {
                                    case "1":
                                        Console.WriteLine(pokemon1.Name + " attaque " + pokemon1.GetCapacity(0).Name);
                                        UseAbility(pokemon1, pokemon2, pokemon1.GetCapacity(0));
                                        Console.WriteLine(pokemon2.Hp);
                                        break;
                                    case "2":
                                        //UseAbility(pokemon1, pokemon2 , NomCapacitée)
                                        break;
                                    case "3":
                                        //UseAbility(pokemon1, pokemon2 , NomCapacitée)
                                        break;
                                    case "4":
                                        //UseAbility(pokemon1, pokemon2 , NomCapacitée)
                                        break;
                                    default:
                                        Console.WriteLine("Option invalide. Veuillez entrer un numéro valide");
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Choisissez un objet à utiliser : ");
                                for (int i = 0; i < player.Inventory.Items.Count; i++)
                                {
                                    Console.WriteLine(i+1 + " : " + player.Inventory.Items[i].ItemData.Name);
                                }
                                string inputAction = Console.ReadLine();
                                switch (inputAction)
                                {
                                    case "1":
                                        pokemon1.Hp = pokemon1.Hp +30;
                                        Console.WriteLine(pokemon1.Hp);
                                        break;
                                    case "2":
                                        if (pokemon2.IsWild == true)
                                        {
                                            Random randomCatch = new Random();
                                            if(randomCatch.Next(0,100) >= 50)
                                            {
                                                Console.WriteLine("catched");
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
                                        Console.WriteLine("Option invalide. Veuillez entrer un numéro valide");
                                        break;
                                }


                                break;
                            // Ajoutez d'autres cas pour gérer d'autres options...
                            default:
                                Console.WriteLine("Option invalide. Veuillez entrer un numéro valide.");
                                break;
                        }
                    }
                    else //IA Turn
                    {
                        Console.WriteLine("IA turn :");
                        if (pokemon2.IsWild == false)
                        {
                            var randomIAMove = new Random();
                            UseAbility(pokemon2, pokemon1, pokemon2.GetCapacity(randomIAMove.Next(1, 4)));
                            //Console.WriteLine(pokemon2.Name + " a utilisé" + pokemon2.GetCapacity(randomIAMove.Next(1, 4)).Name + " sur " + pokemon1.Name);
                        }
                        else
                        {
                            var randomIAMove = new Random();
                            if (randomIAMove.Next(0, 100) >= 90)
                            {
                                //random attack entre capa 1 à 4
                                UseAbility(pokemon2, pokemon1, pokemon2.GetCapacity(randomIAMove.Next(1, 4)));
                                //Console.WriteLine(pokemon2.Name + " a utilisé" + pokemon2.GetCapacity(randomIAMove.Next(1, 4)).Name + " sur " + pokemon1.Name);
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
                Console.WriteLine(attacker.Name + " is not in combat.");
                return;
            }

            // Vérifiez si le Pokémon attaquant a la capacité spécifiée
            /*if (!attacker.CapacityList.Contains(capacity.Name))
            {
                Console.WriteLine(attacker._Name + " does not have the " + capacity.Name + " ability.");
                return;
            }*/

            // Affichez un message pour indiquer que la capacité a été utilisée
            Console.WriteLine(attacker.Name + " used " + capacity.Name + " on " + target.Name + ".");

            // Utilisez la capacité sur la cible

            capacity.IsAttackMissed();
            if (capacity.AttackMissed == true)
            {
                Console.WriteLine(attacker.Name + " has missed his attack on " + target.Name);
                Console.WriteLine(target.Name + " has " + target.Hp + " pv left ! ");
                Console.WriteLine(target.Name + " is " + target.Status);
                return;
            }
            else if (capacity.AttackMissed != true)
            {
                capacity.CapacityDamage(target);
                Console.WriteLine(attacker.Name + " has damaged " + target.Name + " up to " + capacity.Power + " damage !");
                Console.WriteLine(target.Name + " has " + target.Hp + " pv left ! ");

            }
            if (capacity.Status != POKEMON_STATUS.NORMAL)
            {
                target.Status = capacity.Status;
                Console.WriteLine(target.Name + " is " + target.Status);
            }

        }
    }
}
