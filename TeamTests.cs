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
        public void HasLivingMembers_Should_Return_True_If_Any_Alive()
        {
            var team = new Team("Wolves");
            team.Members.Add(new Fighter("Conan") { Health = 0 });
            team.Members.Add(new Wizard("Gandalf") { Health = 5 });
            team.Members.Add(new Cleric("Sophia") { Health = 0 });

            Assert.That(team.HasLivingMembers(), Is.True);
        }

        [Test]
        public void IsAlive_Should_ReturnFalse_When_AllMembersDead()
        {
            var team = new Team("Knights");
            var fighter = new Fighter("Conan") { Health = 0 };
            team.Members.Add(fighter);

            Assert.That(team.HasLivingMembers(), Is.False);
        }
        
        [Test]
        public void GetRandomAliveMember_Should_Return_Only_Alive()
        {
            var team = new Team("Dragons");
            team.Members.Add(new Fighter("Thor") { Health = 0 });
            var wizard = new Wizard("Merlin") { Health = 5 };
            team.Members.Add(wizard);
            team.Members.Add(new Cleric("Angela") { Health = 0 });

            var member = team.GetRandomAliveMember();
            Assert.That(member, Is.EqualTo(wizard));
        }

        [Test]
        public void GetRandomAliveMember_Should_Return_Null_When_No_Living()
        {
            var team = new Team("Dragons");
            team.Members.Add(new Fighter("Thor") { Health = 0 });
            team.Members.Add(new Wizard("Merlin") { Health = 0 });
            team.Members.Add(new Cleric("Angela") { Health = 0 });

            var member = team.GetRandomAliveMember();
            Assert.That(member, Is.Null);
        }
    }
}
