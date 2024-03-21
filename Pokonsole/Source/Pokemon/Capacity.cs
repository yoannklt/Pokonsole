using Pokonsole.Source.Pokemon;

namespace Pokonsole.Source.Pokemon
{
    internal class Capacity
    {
        //CONSTRUTEUR
        public Capacity(string name, POKEMON_TYPE type, int power, int accuracy, POKEMON_STATUS effet = POKEMON_STATUS.NORMAL)
        {
            Name = name;
            Type = type;
            Power = power;
            Accuracy = accuracy;
            Status = effet; 
        }
         
        //METHODES
        public void AttackBuff(Pokemon target)
        {
            target.Attack = target.Attack + Power;
        }
        public void DefenseBuff(Pokemon target)
        {
            target.Defense = target.Defense + Power;
        }
        public void AttackSpeBuff(Pokemon target)
        {
            target.SpecialAttack = target.SpecialAttack + Power;
        }
        public void DefenseSpeBuff(Pokemon target)
        {
            target.SpecialDefense = target.SpecialDefense + Power;
        }
        public void SpeedBuff(Pokemon target)
        {
            target.Speed = target.Speed + Power;
        }
        public void ApplyStatus(Pokemon target)
        {
            target._Status = Status;
        }
        //METHODES GETTER / SETTER
        public string Name { get => _name; set => _name = value; }
        public POKEMON_TYPE Type { get => _type; set => _type = value; }
        public int Power { get => _power; set => _power = value; }
        public int Accuracy { get => _accuracy; set => _accuracy = value; }
        public POKEMON_STATUS Status { get => _status; set => _status = value; }
        public int PowerPerRound { get => _powerPerRound; set => _powerPerRound = Power / 3; }

        //VARIABLES PRIVEES
        private string _name;
        private POKEMON_TYPE _type;
        private int _power;
        private int _accuracy;
        private POKEMON_STATUS _status;
        private int _powerPerRound;

    }
}


/// Name : Charge   | Danse Lames } Buff l'attaque du lanceur de Power % et avec un taux de réusite de Accuracy %   | Poison } Effectue Power% de dégat sur 3 tours
/// Type : Normal   | Normal                                                                                        | Poison 
/// Power : 40      | -- (20)                                                                                       | 50
/// Accuracy : 100  | -- (100)                                                                                      | 100
///                                                                                                                 | STATUS : POISONED
///                                                                                                                 