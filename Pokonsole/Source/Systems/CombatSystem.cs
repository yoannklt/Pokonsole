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
            if (pokemon1 == null || pokemon2 == null) {  return; }

            if (pokemon1 != null && pokemon2 != null)
            {
                Console.WriteLine(pokemon1.IsInCombat + "" + pokemon2.IsInCombat);
                SetUnsetInCombat(pokemon1, pokemon2);
                Console.WriteLine(pokemon1.IsInCombat + ""  + pokemon2.IsInCombat);
                //lancement du mode "combat"
                SetUnsetInCombat(pokemon1, pokemon2);
                Console.WriteLine(pokemon1.IsInCombat + "" + pokemon2.IsInCombat);
            }

        }


        public void SetUnsetInCombat(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1 == null || pokemon2 == null) { return; }
            else if (pokemon1!= null && pokemon2 != null) 
            {
                if(pokemon1.IsInCombat == false && pokemon2.IsInCombat == true) { return ; }
                if(pokemon1.IsInCombat == true && pokemon2.IsInCombat == false) { return ; }

                //setting in combat
                else if (pokemon1.IsInCombat == false && pokemon2.IsInCombat == false)
                {
                    pokemon1.IsInCombat = true;
                    pokemon2.IsInCombat = true;
                }
                //unsetting in combat
                else if (pokemon1.IsInCombat == true && pokemon2.IsInCombat == true)
                {
                    pokemon1.IsInCombat = false;
                    pokemon2.IsInCombat = false;
                }

            }
        }
    }
}
