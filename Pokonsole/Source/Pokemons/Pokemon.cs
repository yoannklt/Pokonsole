using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokonsole.Source.Pokemons;

namespace Pokonsole.Source.Pokemons
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
        BUG,
        ELECTRIC,
        GROUND,
        ROCK,
        FIGHTING,
        PSYCHIC,
        GHOST,
        ICE,
        DRAGON,
        TOTAL_POKEMON_TYPE
    }

    enum POKEMON_STATUS
    {
        NORMAL = 0,
        PARALYSED,
        BURNED,
        POISONED,
        TOTAL_POKEMON_STATUS
    }
    //CONSTRUCTEUR 
    internal class Pokemon
    {
        public Pokemon(string name, POKEMON_TYPE type, int hp, int level, int attack, int defense, int speed, int specialAttack, int specialDefense, bool isWild = false)
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
            Accuracy = 100;
            Status = POKEMON_STATUS.NORMAL;
            _IsWild = isWild;
            _IsKnockOut = false;
            _IsInCombat = false;
            _IsMyTurn = false;
            _CapacityList = new List<Capacity>();
        }
        //METHODES 
        public void AddCapacity(Capacity capacity)
        {
            if (_CapacityList.Count < 4)
            {
                _CapacityList.Add(capacity);
            }
            else
            {
                Console.Write("You can't add more than 4 capacities to a pokemon !");
                /// RemoveCapacity(capacityName);

            }
        }

        public void RemoveCapacity(Capacity capacityName)
        {
            Console.Write("Do you want to remove this capacity ? (Y/N)", capacityName);
            if (Console.ReadLine() == "Y")
            {
                _CapacityList.Remove(capacityName);
            }
        }
        public void onCombatEnter()
        {
            if (_IsWild == true)
            {
                Console.Write("A wild " + Name + " appeared !");
            }
            else
            {
                Console.Write(Name + " is ready to fight !");
            }
        }
        /// onCombatDefeate()
        public void onCombatDefeate()
        {
            if (_IsWild == true)
        {
                Console.Write("The wild " + Name + " fainted !");
            }
            else
            {
                Console.Write(Name + " fainted !");
            }
            }
        /// onCombatExit()
        public void onCombatExit()
        {
            if (_IsWild == true)
            {
                Console.Write("The wild " + Name + " ran away !");
        }
            else
        {
                onCombatDefeate();
            }
        }

        public void onCombatVictory()
        {
            if (_IsWild == true)
            {
                Console.Write("You caught the wild " + Name + " !");
            }
            else
            {
                Console.Write(Name + " won the fight !");
            }
        }
        public void attack(Pokemon target, Capacity capacity)
        {
            var rand = new Random();
            if (capacity.Accuracy == 100)
            {
                Console.Write("Attack 1");
                target.Hp = target.Hp - capacity.Power;
                if (capacity.Status != POKEMON_STATUS.NORMAL)
                {
                    target.Status = capacity.Status;
                }
                Console.Write(target.Hp);

            }
            else if (rand.Next(0, 100) <= capacity.Accuracy)
            {
                Console.Write("Attack 2");
                target.Hp = target.Hp - capacity.Power;
                if (capacity.Status != POKEMON_STATUS.NORMAL)
                {
                    target.Status = capacity.Status;
                }
                Console.Write(target.Hp);
            }
            else
            {
                Console.Write("Attack missed ");
            }
        }
        public Capacity GetCapacity(int index)
        {
            if (index >= 0 && index < _CapacityList.Count)
            {
                return _CapacityList[index];
            }
            else
            {
                Console.Write("This capacity doesn't exist !");
                return null;
            }
        }
        public void onDamageTaken(int damage)
        {
            Hp = Hp - damage;
            if (Hp <= 0)
            {
                _IsKnockOut = true;
            } 
        }
        public void onUseItem() { }



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
        public List<Capacity> CapacityList { get => _CapacityList; set => _CapacityList = value; }


        //VARIABLE PRIVEES
        private List<Capacity> _CapacityList;
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
