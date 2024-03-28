using System;

namespace Pokonsole.Source.Pokemons
{
    internal class Capacity
    {
        // Propriétés
        public int Id { get; }
        public string Name { get; set; }
        public POKEMON_TYPE Type { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public POKEMON_STATUS Status { get; set; }
        public int PowerPerRound { get => Power / 3; }
        public bool AttackMissed { get; set; }

        // Constructeurs
        public Capacity(int id, string name, POKEMON_TYPE type, int power, int accuracy, POKEMON_STATUS status = POKEMON_STATUS.NORMAL)
        {
            Id = id;
            Name = name;
            Type = type;
            Power = power;
            Accuracy = accuracy;
            Status = status;
            AttackMissed = false; // Par défaut, l'attaque ne rate pas
        }

        // Méthodes
        public void AttackBuff(Pokemon target)
        {
            target.Attack += Power;
        }

        public void DefenseBuff(Pokemon target)
        {
            target.Defense += Power;
        }

        public void AttackSpeBuff(Pokemon target)
        {
            target.SpecialAttack += Power;
        }

        public void DefenseSpeBuff(Pokemon target)
        {
            target.SpecialDefense += Power;
        }

        public void SpeedBuff(Pokemon target)
        {
            target.Speed += Power;
        }

        public void ApplyStatus(Pokemon target)
        {
            target.Status = Status;
        }

        public void CapacityDamage(Pokemon target)
        {
            if (!AttackMissed)
            {
                target.Hp -= Power;
            }
        }

        public void IsAttackMissed()
        {
            var rand = new Random();
            if (Accuracy == 100)
            {
                AttackMissed = false;
            }
            else if (rand.Next(0, 101) <= Accuracy)
            {
                AttackMissed = false;
            }
            else
            {
                AttackMissed = true;
                Console.WriteLine("Attack missed");
            }
        }
    }
}
