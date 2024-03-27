using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokonsole.Source.Pokemons
{
    //ENUMS
    enum POKEMON_TYPE
    {
        NORMAL = 0,
        FIRE,
        WATER,
        POISON,
        GRASS,
        TOTAL_POKEMON_TYPE
    }

    enum POKEMON_STATUS
    {
        NORMAL = 0,
        PARALYSED,
        //BURNED,
        POISONED,
        TOTAL_POKEMON_STATUS
    }
    //CONSTRUCTEUR 
    internal class Pokemon
    {
        public Pokemon(string name, POKEMON_TYPE type, int hp, int level, int attack, int defense, int speed, int specialAttack, int specialDefense, bool isWild = false)
        {
            Name = name;
            Type = POKEMON_TYPE.NORMAL;
            Status = POKEMON_STATUS.NORMAL;
            Hp = hp;
            Level = level;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Accuracy = 100;
            CapacityList = new List<Capacity>();
            IsWild = isWild;
            IsKnockOut = false;
        }


        //METHODES 
        public void AddCapacity(Capacity capacityName)
        {
            _CapacityList.Add(capacityName);
        }
        public void RemoveCapacity(Capacity capacityName)
        {
            _CapacityList.Remove(capacityName);
        }
        public void onCombatEnter()
        {
            if (_IsWild == true)
            {
                Console.WriteLine("A wild " + Name + " appeared !");
            }
            else
            {
                Console.WriteLine(Name + " is ready to fight !");
            }
        }
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
        public void attack(Capacity capacity, Pokemon target) 
        {

        }

        public void onCombatVictory() 
        {
            if (_IsWild == true)
            {
                Console.WriteLine("The wild " + Name + " won the combat !");
            }
            else
            {
                Console.WriteLine(Name + " won the combat !");
            }
        }

        public void onCapture() { }

        /// ???? isMyCombatTurn()
        /// onUseItem()

        public void KnockOut(Pokemon target)
        {
            if (target == null)
            {
                return;
            }
            else if (target.IsKnockOut == true)
            {
                return;
            }
            else if (target._isKnockOut == false)
            {
                if (target.Hp > 0)
                {
                    target._isKnockOut = false;
                }
                if (target.Hp == 0)
                {
                    target._isKnockOut = true;
                }
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
                Console.WriteLine("Index out of range.");
                return null;
            }
        }

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
        public bool IsKnockOut { get => _isKnockOut; set => _isKnockOut = value; }
        public bool IsInCombat { get => _isInCombat; set => _isInCombat = value; }
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
        private bool _isKnockOut;
        private bool _isInCombat = false;
    }
}