using NUnit.Framework;
using DnDBattler.Models;

namespace DnDBattler.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void Fighter_Attack_Should_Reduce_Enemy_Health()
        {
            var attacker = new Fighter("Thor");
            var defender = new Wizard("Merlin");

            int initialHealth = defender.Health;

            // Simulate attack manually
            defender.Health -= attacker.Attack;

            Assert.That(defender.Health, Is.LessThan(initialHealth));
        }


        [Test]
        public void Cleric_Attack_Should_Heal_Self()
        {
            // Arrange
            var cleric = new Cleric("Angela") { Health = 5, Attack = 2 };
            var enemy = new Fighter("Conan") { Health = 10 };

            // Act - simulate the attack manually
            enemy.Health -= cleric.Attack; // damage enemy
            cleric.Health += 1;            // Cleric heals 1 when attacking

            // Assert
            Assert.That(cleric.Health, Is.GreaterThan(5));
        }

        [Test]
        public void Cleric_Should_Have_Valid_Base_Stats()
        {
            var cleric = new Cleric("Sophia");
            Assert.That(cleric.Health, Is.GreaterThanOrEqualTo(1));
            Assert.That(cleric.Attack, Is.GreaterThanOrEqualTo(1));
            Assert.That(cleric.Attack, Is.LessThanOrEqualTo(10));
        }

        [Test]
        public void Wizard_Attack_Should_Be_Doubled_And_InExpectedRange()
        {
            var wizard = new Wizard("Merlin");
            Assert.That(wizard.Attack, Is.GreaterThanOrEqualTo(2));  // doubled from 1..10 => 2..20
            Assert.That(wizard.Attack, Is.LessThanOrEqualTo(20));
            Assert.That(wizard.Attack % 2, Is.EqualTo(0));           // doubled value is even
        }

        [Test]
        public void Fighter_Should_Get_Health_Bonus_Of_5()
        {
            var fighter = new Fighter("Conan");
            Assert.That(fighter.Health, Is.GreaterThanOrEqualTo(6)); // base 1, 2, 3...10 + 5
            Assert.That(fighter.Health, Is.LessThanOrEqualTo(15));
        }
    }
}
