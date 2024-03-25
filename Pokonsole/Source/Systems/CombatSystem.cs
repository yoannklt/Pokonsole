using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokonsole.Source.Pokemons;

namespace Pokonsole.Source.Systems
{
    internal class CombatSystem
    {
        public CombatSystem() { }
        public void CreateNewCombat(Pokemon pokemon1, Pokemon pokemon2) 
        {
            bool isPlayerTurn = true;
            if (pokemon1 == null || pokemon2 == null) {  return; }

            if (pokemon1 != null && pokemon2 != null)
            {
                SetInCombat(pokemon1, pokemon2);
                //Gestion de la boucle principale du combat
                while (pokemon1.IsKnockOut == false && pokemon2.IsKnockOut == false)
                {
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
                            case "1":
                                // Si le joueur choisit d'attaquer, exécutez l'attaque
                                break;
                            case "2":
                                // Si le joueur choisit d'utiliser un objet, exécutez l'utilisation de l'objet
                                // Ajoutez la logique pour utiliser un objet selon vos besoins
                                break;
                            // Ajoutez d'autres cas pour gérer d'autres options...
                            default:
                                Console.WriteLine("Option invalide. Veuillez entrer un numéro valide.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Player 2's turn :");
                    }
                    isPlayerTurn = !isPlayerTurn;
                }

                //Gestion de fin de combat : 
                if (pokemon1.IsKnockOut == true || pokemon2.IsKnockOut == true)
                {
                    UnsetInCombat(pokemon1, pokemon2);
                    if (pokemon1.IsKnockOut == false && pokemon2.IsKnockOut == true)
                    {
                        pokemon1.onCombatDefeate();
                        pokemon2.onCombatVictory();
                    }
                    else if (pokemon1.IsKnockOut == true && pokemon2.IsKnockOut == false) 
                    {
                        pokemon2.onCombatDefeate();
                        pokemon1.onCombatVictory();
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
                Console.WriteLine(attacker._Name + " is not in combat.");
                return;
            }

            // Vérifiez si le Pokémon attaquant a la capacité spécifiée
            /*if (!attacker.CapacityList.Contains(capacity.Name))
            {
                Console.WriteLine(attacker._Name + " does not have the " + capacity.Name + " ability.");
                return;
            }*/

            // Affichez un message pour indiquer que la capacité a été utilisée
            Console.WriteLine(attacker._Name + " used " + capacity.Name + " on " + target._Name + ".");

            // Utilisez la capacité sur la cible

            capacity.IsAttackMissed();
            if (capacity.AttackMissed == true)
            {
                Console.WriteLine(attacker._Name + " has missed his attack on " + target._Name);
                Console.WriteLine(target._Name + " has " + target.Hp + " pv left ! ");
                Console.WriteLine(target._Name + " is " + target._Status);
                return;
            }
            else if (capacity.AttackMissed != true)
            {
                if (target == attacker)
                {
                    if (capacity.Name == "Danse Lame")
                    {
                        capacity.AttackBuff(target);
                        Console.WriteLine( attacker._Name + " has increased his attack up to " + target.Attack);
                    }
                    if (capacity.Name == "nomDefenseBuff")
                    {
                        capacity.DefenseBuff(target);
                        Console.WriteLine(attacker._Name + " has increased his defense up to " + target.Defense);
                    }
                    if (capacity.Name == "nomAttackSpeBuff")
                    {
                        capacity.AttackSpeBuff(target);
                        Console.WriteLine(attacker._Name + " has increased his special attack up to " + target.SpecialAttack);
                    }
                    if (capacity.Name == "nomDefenseSpeBuff")
                    {
                        capacity.DefenseSpeBuff(target);
                        Console.WriteLine(attacker._Name + " has increased his special defense up to " + target.SpecialDefense);
                    }
                }
                else
                {
                    capacity.CapacityDamage(target);
                    Console.WriteLine(attacker._Name + " has damaged " + target._Name + " up to " + capacity.Power + " damage !");
                    Console.WriteLine(target._Name + " has " + target.Hp + " pv left ! ");
                }
            }
            if (capacity.Status != POKEMON_STATUS.NORMAL)
            {
                target._Status = capacity.Status;
                Console.WriteLine(target._Name + " is " + target._Status);
            }

        }
    }
}
