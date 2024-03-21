namespace Pokonsole.Source.Pokemons
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
            Status = effet; //? Si le pokémon est déjà POISONED et qu'il prends une attaque Charge de status NORMAL, le pokemon reste POISONED ou deviens NORMAL ? 
        }

        /*public Capacity(string name, POKEMON_TYPE type, int power, int accuracy, POKEMON_STATUS effet) 
        { 
            Name = name;
            Type = type;
            Power = power;
            Accuracy = accuracy;
            Status = effet;
        }*/

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
        public void CapacityDamage(Pokemon target)
        {
            var rand = new Random();
            if (Accuracy == 100)
            {
                Console.WriteLine("Attack 1");
                target.Hp = target.Hp - Power;
                Console.WriteLine(target.Hp);

            }
            else if (rand.Next(0, 101) <= Accuracy)
            {
                Console.WriteLine("Attack 2");
                target.Hp = target.Hp - Power;
                Console.WriteLine(target.Hp);
            }
            else
            {
                Console.WriteLine("Attack missed");
            }
        }

        //METHODES GETTER / SETTER
        public string Name { get => _name; set => _name = value; }
        public POKEMON_TYPE Type { get => _type; set => _type = value; }
        public int Power { get => _power; set => _power = value; }
        public int Accuracy { get => _accuracy; set => _accuracy = value; }
        public POKEMON_STATUS Status {get => _status; set => _status = value; }

        //VARIABLES PRIVEES
        private string _name;
        private POKEMON_TYPE _type;
        private int _power;
        private int _accuracy;
        private POKEMON_STATUS _status;
    }
}


/// Name : Charge   | Danse Lames } Buff l'attaque du lanceur de Power % et avec un taux de réusite de Accuracy %   | Poison } Effectue Power% de dégat sur 3 tours
/// Type : Normal   | Normal                                                                                        | Poison 
/// Power : 40      | -- (20)                                                                                       | 50
/// Accuracy : 100  | -- (100)                                                                                      | 100
///                                                                                                                 | STATUS : POISONED