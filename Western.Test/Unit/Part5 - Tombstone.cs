
using System;
using System.Linq;

using Xunit;
using FluentAssertions;

namespace Western.Tests
{
    public class Part5
    {
        // Niveau pied-tendre
        #region I - Boucle incorrecte

        /*
         * PB : Bug
         * Info supplémentaire : retourner l'index de 2 dans le tableau (ne pas gérer l'absence de valeur)
         * Résultat attendu : test vert
        */
        [Fact]
        public void Program_does_not_leave_loop()
        {
            IndexOfNumberOfCarsInBlackjack(new[] { 1, 2, 3 }).Should().Be(1);
            IndexOfNumberOfCarsInBlackjack(new[] { 1, 7, 20, 9, 11, 2 }).Should().Be(5);
            IndexOfNumberOfCarsInBlackjack(new[] { 2, 1, 3 }).Should().Be(0);
        }

        public int IndexOfNumberOfCarsInBlackjack(int[] values)
        {
            int index = 0;
            while (index < values.Length && values[index] != 2)
                index++;

            return index;
        }

        #endregion

        #region II - Boucle illisible

        /*
         * PB : Lisibilité
         * Info supplémentaire : seul le deuxième Johnny nous intéresse, ne demandez pas pourquoi...
         * Résultat attendu : code fonctionnel en une ou deux lignes
        */
        [Fact]
        public void Method_works_but_is_not_readable()
        {
            GetJohnny(new string[] { }).Should().BeNull();
            GetJohnny(new string[] { "Wyatt Earp", "Virgil Earp" }).Should().BeNull();
            GetJohnny(new string[] { "Wyatt Earp", "Johnny Cash", "Virgil Earp" }).Should().BeNull();
            GetJohnny(new string[] { "Wyatt Earp", "Johnny Cash", "Virgil Earp", "Johnny Ringo" }).Should().Be("Johnny Ringo");
        }

        public string GetJohnny(string[] values)
        {
            return values.Where(v => v.StartsWith("Johnny")).DefaultIfEmpty().Skip(1).Take(1).FirstOrDefault();
        }

        #endregion

        #region III - Valeur ou Référence

        /*
         * PB : Bug
         * Résultat attendu : expliquer le problème et proposer deux solutions
        */
        [Fact]
        public void Number_does_not_decrease()
        {
            var nbBulletsInColtArmy = 6;
            Shoot1(ref nbBulletsInColtArmy);
            nbBulletsInColtArmy.Should().Be(5);

            nbBulletsInColtArmy = Shoot2(nbBulletsInColtArmy);
            nbBulletsInColtArmy.Should().Be(4);
        }
        /// <summary>
        ///  the problem is int is passed by value, decreasing a working copy 
        /// </summary>
        /// <param name="nbBullets"></param>

        // Solution 1
        public int Shoot1(ref int nbBullets)
        {
            --nbBullets;

            return nbBullets;
        }

        // Solution 2 : use the returned value
        public int Shoot2(int nbBullets)
        {
            // problem is int is passed by value, decreasing a working copy 
            --nbBullets;

            return nbBullets;
        }

        #endregion

        #region IV - Gestion d'erreur

        /*
         * PB : Gestion d'erreurs à l'ancienne
         * Résultat attendu : solution plus moderne
        */
        [Fact]
        public void Method_works_but_is_old_school()
        {
            TravelWithHorseOrFail(true).Should().Be(0);

            Action act = () => TravelWithHorseOrFail(false);
            act.Should().Throw<Exception>();
        }

        public int TravelWithHorseOrFail(bool hasHorse)
        {
            return hasHorse ? 0 : throw new Exception("Voyager sans bourrin ? Tu rêves !");
        }

        #endregion


        // Niveau cowboy
        #region V - Singleton

        /*
         * PB : le Singleton est-il correctement implémenté ?
         * Résultat attendu : analyse explicative sur les éventuels problèmes
        */
        [Fact]
        public void Is_Singleton_correct()
        {
            JesseJames.Instance.Name.Should().Be("Jesse James");
            JesseJames.Instance.Should().Equals(JesseJames.Instance);
        }

        public sealed class JesseJames
        {
            private static readonly Lazy<JesseJames>
                lazy =
                new Lazy<JesseJames>
                    (() => new JesseJames());

            public static JesseJames Instance { get { return lazy.Value; } }

            public string Name => "Jesse James";

            private JesseJames()
            {
            }
        }

        #endregion

        #region VI - Test

        /*
         * PB : le TestInitialize n'est jamais appelé
         * Résultat attendu : à votre avis ?
        */
        [Fact]
        public void Check_if_Initialized_was_called()
        {
            _testInitialize.Should().NotBeNullOrEmpty();
        }

        private string _testInitialize = null;

        public Part5()
        {
            _testInitialize = "Yay!";
        }

        #endregion

        #region VII - Objet & dynamic

        /*
         * PB: dynamic
         * Info supplémentaire : deux tests dans cette partie !
         * Résultat attendu : expliquer les dynamic et proposer une solution plus propre
        */
        [Fact]
        public void Oh_my_God_it_is_awful()
        {
            var colt = DrawYourGun(GunType.Colt);
            var remington = DrawYourGun(GunType.Remington);
            var lemat = DrawYourGun(GunType.LeMat);

            ShootWithYourGun(colt).Should().Be("Colt Army goes bang!");
            ShootWithYourGun(remington).Should().Be("Remington New Model Army goes bang!");
            ShootWithYourGun(lemat).Should().Be("LeMat goes bang!");
            ShootWithYourGun(lemat, true).Should().Be("LeMat goes BANG!");
        }

        [Fact]
        public void Oh_my_God_it_is_awful_part2()
        {
            Action act = () => { var useless = ShootWithYourGun(DrawYourGun(GunType.Colt), true); };
            act.Should().Throw<Exception>();
        }

        public class Gun
        {
            public string Name { get; } = "Colt";
            public GunType Type { get; } = GunType.Colt;

            public Gun()
            {

            }

            public Gun(string name, GunType type)
            {
                Name = name;
                Type = type;
            }
            public string Shoot()
            {
                return "Bang!";
            }
        }

        private Gun DrawYourGun(GunType gunType)
        {
            switch (gunType)
            {
                case GunType.Colt: return new Gun("Colt Army", GunType.Colt);
                case GunType.Remington: return new Gun("Remington New Model Army", GunType.Remington);
                case GunType.LeMat: return new Gun("LeMat", GunType.LeMat);
            }

            return null;
        }

        private string ShootWithYourGun(Gun gun, bool alternativeShot = false)
        {
            if (gun == null) return "";
            string sound = gun.Name + " goes ";

            if (!alternativeShot)
            {
                sound += "bang!";
            }
            else
            {
                if (gun.Type != GunType.LeMat)
                {
                    throw new Exception("No alternative shot available");
                }

                sound += "BANG!";
            }
            return sound;
        }

        public enum GunType
        {
            Colt,
            Remington,
            LeMat
        }

        #endregion


        // Niveau desperado
        #region VIII - Algèbre de Bool

        /*
         * PB : Bug
         * Résultat attendu : test au vert sans changer les types utilisés
        */
        [Fact]
        public void Check_if_Wild_Bill_was_Fast_and_Dangerous()
        {
            IsWildBillFastAndDangerous(new WildBillHickok()).Should().BeTrue();
        }

        public bool IsWildBillFastAndDangerous(WildBillHickok wildBill)
        {
            var fastAndDangerous = Skills.Fast & Skills.Dangerous;

            return wildBill.Skills == fastAndDangerous;
        }

        [Flags]
        public enum Skills
        {
            Fast = 1,
            Smart = 2,
            Dangerous = 4,
            Strong = 8
        }

        public class WildBillHickok
        {
            public Skills Skills => Skills.Fast & Skills.Dangerous; //(Fast(1) + Dangerous(4)) = 5
        }

        #endregion

        #region IX - Précision

        /*
         * PB : Bug
         * Info supplémentaire : les nombes utilisés sont corrects, ce n'est pas un exercice de calcul mental !
         * Résultat attendu : un test au vert qui corrige le problème sans le contourner
        */
        [Fact]
        public void Operation_on_floating_number_is_not_so_good()
        {
            GetBankSafeValue().Should().Be(101.27m);
        }

        private decimal GetBankSafeValue()
        {
            // Le coffre contient 100.12 dollars et le caissier en a 1.15 dans sa poche...
            return 100.12m + 1.15m;
        }

        #endregion

        #region X - C# 6

        /*
         * PB : Lisibilité 
         * Résultat attendu : utiliser le plus possible de fonctionnalités de C#6 dans l'objet Desperado
        */
        [Fact]
        public void Using_C_Sharp_5_Code()
        {
            var desperado = new Desperado("Bob Dalton", 21);

            desperado.Age++;
            desperado.Name.Should().Be("Bob Dalton");
            desperado.Age.Should().Be(22);
            desperado.Shout.Should().Be("It's high noon!");
            desperado.Shoot().Should().BeNull();
            desperado.ToString().Should().Be("My name is Bob Dalton and I am 22 years old. It's high noon!");

            desperado.Gun = new Gun();
            desperado.Shoot().Should().Be("Bang!");
        }

        public class Desperado
        {

            public string Name { get; }

            public int Age { get; set; }

            public string Shout  => "It's high noon!"; 

            public Gun Gun { get; set; }

            public Desperado(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public override string ToString() => "My name is " + Name + " and I am " + Age + " years old. " + Shout;

            public string WhatDoYouUseWhenItIsHighNoon() => "Shout";

            public string Shoot() => Gun?.Shoot();
        }

        #endregion
    }
}
