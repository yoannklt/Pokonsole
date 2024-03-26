using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokonsole.Source.Pokemon
{
    //ENUMS
    enum POKEMON_TYPE
    {
        NORMAL = 0,
        FIRE,
        WATER,
        GRASS,
        POISON,
        FLYING,
        TOTAL_POKEMON_TYPE
    }

    enum POKEMON_STATUS
    {
        NORMAL = 0,
        PARALYSED,
        //BURNED,
        // POISONED,
        TOTAL_POKEMON_STATUS
    }
    //CONSTRUCTEUR 
    internal class Pokemon
    {
        public Pokemon(string name, POKEMON_TYPE type, int hp, int level, int attack, int defense, int speed, int specialAttack, int specialDefense, int accuracy)
        {
            Name = name;
            Type = type;
            Hp = hp;
            Level = level;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Accuracy = accuracy;
            Status = POKEMON_STATUS.NORMAL;
            _IsWild = true;
            _IsKnockOut = false;
            _IsInCombat = false;
            _IsMyTurn = false;
            _CapacityList = new List<string>();
        }
        //METHODES 
        public void AddCapacity(string capacityName)
        {
            if (_CapacityList.Count < 4)
            {
                _CapacityList.Add(capacityName);
            }
            else
            {
                Console.WriteLine("You can't add more than 4 capacities to a pokemon !");
               /// RemoveCapacity(capacityName);

            }
        }

        public void RemoveCapacity(string capacityName)
        {
            Console.WriteLine("Do you want to remove this capacity ? (Y/N)", capacityName);
            if (Console.ReadLine() == "Y")
            {
                _CapacityList.Remove(capacityName);
            }
        }
        public void onCombatEnter() { 
            if (_IsWild == true)
            {
                Console.WriteLine("A wild " + Name + " appeared !");
            }
            else
            {
                Console.WriteLine(Name + " is ready to fight !");
            }
        }
        /// onCombatDefeate()
        public void onCombatDefeate()
        {
            if (_IsWild == true)
            {
                Console.WriteLine("The wild " + Name + " fainted !");
            }
            else
            {
                Console.WriteLine(Name + " fainted !");
            }
        }
        /// onCombatExit()
        public void onCombatExit()
        {
            if (_IsWild == true)
            {
                Console.WriteLine("The wild " + Name + " ran away !");
            }
            else
            {
                onCombatDefeate();
            }
        }
        public void attack(Pokemon target, Capacity capacity) { 
            var rand = new Random();
            if (capacity.Accuracy == 100)
            {
                Console.WriteLine("Attack 1");
                target.Hp = target.Hp - capacity.Power;
                if (capacity.Status != POKEMON_STATUS.NORMAL)
                {
                    target.Status = capacity.Status;
                }
                Console.WriteLine(target.Hp);

            }
            else if (rand.Next(0, 100) <= capacity.Accuracy)
            {
                Console.WriteLine("Attack 2");
                target.Hp = target.Hp - capacity.Power;
                if (capacity.Status != POKEMON_STATUS.NORMAL)
                {
                    target.Status = capacity.Status;
                }
                Console.WriteLine(target.Hp);
            }
            else
            {
                Console.WriteLine("Attack missed ");
            }
        }
        /// onCombatVictory()
        /// ???? isMyCombatTurn()
        /// onCapture()
        /// onUseItem()

        //METHODES GETTERS / SETTERS
        public string Name { get; set; }
        public POKEMON_TYPE Type { get; set; }
        public POKEMON_STATUS Status { get; set; }

        public int Hp { get => _Hp; set => _Hp = value; }
        public int Level { get => _Level; set => _Level = value; }
        public int Attack { get => _Attack; set => _Attack = value; }
        public int Defense { get => _Defense; set => _Defense = value; }
        public int Speed { get => _Speed; set => _Speed = value; }
        public int SpecialAttack { get => _SpecialAttack; set => _SpecialAttack = value; }
        public int SpecialDefense { get => _SpecialDefense; set => _SpecialDefense = value; }
        public int Accuracy { get => _Accuracy; set => _Accuracy = value; }
        public bool IsWild { get => _IsWild; set => _IsWild = value; }
        public bool IsKnockOut { get => _IsKnockOut; set => _IsKnockOut = value; }
        public bool IsInCombat { get => _IsInCombat; set => _IsInCombat = value; }
        public bool IsMyTurn { get => _IsMyTurn; set => _IsMyTurn = value; }


        //VARIABLE PRIVEES
        private List<string> _CapacityList;
        private int _Hp;
        private int _Level;
        private int _Attack;
        private int _Defense;
        private int _Speed;
        private int _SpecialAttack;
        private int _SpecialDefense;
        private int _Accuracy;
        private bool _IsWild;
        private bool _IsKnockOut;
        private bool _IsInCombat;
        private bool _IsMyTurn;
    }
}
