using NUnit.Framework;
using DnDBattler.Models;

namespace DnDBattler.Tests
{
    [TestFixture]
    public class TeamTests
    {
        [Test]
        public void Team_Should_Have_3_Members_When_Added()
        {
            var team = new Team("Dragons");
            team.Members.Add(new Fighter("Thor"));
            team.Members.Add(new Wizard("Merlin"));
            team.Members.Add(new Cleric("Angela"));

            Assert.That(team.Members.Count, Is.EqualTo(3));
        }

        [Test]
        public void IsAlive_Should_ReturnFalse_When_AllMembersDead()
        {
            var team = new Team("Knights");
            var fighter = new Fighter("Conan") { Health = 0 };
            team.Members.Add(fighter);

            Assert.That(team.HasLivingMembers(), Is.False);
        }
    }
}
