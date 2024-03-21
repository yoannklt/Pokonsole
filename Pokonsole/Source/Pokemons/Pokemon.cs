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
        public Pokemon()
        {
            _Name = "";
            _Type = POKEMON_TYPE.NORMAL;
            _Status = POKEMON_STATUS.NORMAL;
            _Hp = 0;
            _Level = 0;
            _Attack = 0;
            _Defense = 0;
            _Speed = 0;
            _SpecialAttack = 0;
            _SpecialDefense = 0;
            _Accuracy = 100;
            _CapacityList = new List<string>();
            _IsWild = false;
            _isKnockOut = false;
        }

        //METHODES 
        public void AddCapacity(string capacityName)
        {
            _CapacityList.Add(capacityName);
        }
        public void RemoveCapacity(string capacityName)
        {
            _CapacityList.Remove(capacityName);
        }
        public void onCombatEnter()
        {
            if (_IsWild == true)
            {
                Console.WriteLine("A wild " + _Name + " appeared !");
            }
            else
            {
                Console.WriteLine(_Name + " is ready to fight !");
            }
        }
        public void onCombatDefeate()
        {
            if (_IsWild == true)
            {
                Console.WriteLine("The wild " + _Name + " fainted !");
            }
            else
            {
                Console.WriteLine(_Name + " fainted !");
            }
        }

        public void onCombatExit()
        {
            if (_IsWild == true)
            {
                Console.WriteLine("The wild " + _Name + " ran away !");
            }
            else
            {
                onCombatDefeate();
            }
        }
        public void attack(Capacity capacity, Pokemon target) 
        {

        }

        public void onCombatVictory() { }

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

        //METHODES GETTERS / SETTERS
        public string _Name { get; set; }
        public POKEMON_TYPE _Type { get; set; }
        public POKEMON_STATUS _Status { get; set; }

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
        private bool _isKnockOut;
    }
}