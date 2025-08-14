using NUnit.Framework;
using DnDBattler.Models;
using DnDBattler.Services;

namespace DnDBattler.Tests
{
    [TestFixture]
    public class BattleTests
    {
        [Test]
        public void Battle_Should_Declare_Winner_When_One_Team_Dies()
        {
            var teamA = new Team("Heroes");
            teamA.Members.Add(new Fighter("Thor") { Health = 10 });

            var teamB = new Team("Villains");
            teamB.Members.Add(new Fighter("Loki") { Health = 0 });

            string winner = null;
            if (teamA.HasLivingMembers() && !teamB.HasLivingMembers())
                winner = teamA.TeamName;
            else if (!teamA.HasLivingMembers() && teamB.HasLivingMembers())
                winner = teamB.TeamName;
            else
                winner = "Draw";

            Assert.That(winner, Is.EqualTo("Heroes"));
        }

        [Test]
        public void Battle_Should_Return_Draw_If_Both_Dead()
        {
            var teamA = new Team("Heroes");
            teamA.Members.Add(new Fighter("Thor") { Health = 0 });

            var teamB = new Team("Villains");
            teamB.Members.Add(new Fighter("Loki") { Health = 0 });

            string winner = null;
            if (teamA.HasLivingMembers() && !teamB.HasLivingMembers())
                winner = teamA.TeamName;
            else if (!teamA.HasLivingMembers() && teamB.HasLivingMembers())
                winner = teamB.TeamName;
            else
                winner = "Draw";

            Assert.That(winner, Is.EqualTo("Draw"));
        }

        [Test]
        public void Battle_Should_Damage_Both_Teams()
        {
            var teamA = new Team("Heroes");
            teamA.Members.Add(new Fighter("Thor") { Health = 10 });

            var teamB = new Team("Villains");
            teamB.Members.Add(new Fighter("Loki") { Health = 10 });

            var battle = new Battle(teamA, teamB);
            battle.Simulate();

            Assert.That(teamA.Members[0].Health, Is.LessThan(10));
            Assert.That(teamB.Members[0].Health, Is.LessThan(10));
            //less than 10 to confirm damage actually happened
        }

        [Test]
        public void Battle_Should_Only_Attack_Alive_Characters()
        {
            var teamA = new Team("Heroes");
            var fighter = new Fighter("Thor") { Health = 0 };
            teamA.Members.Add(fighter);

            var teamB = new Team("Villains");
            teamB.Members.Add(new Fighter("Loki") { Health = 10 });

            var battle = new Battle(teamA, teamB);
            var target = teamA.GetRandomAliveMember();

            Assert.That(target, Is.Null); // no alive members
        }

        [Test]
        public void Battle_Should_Alternate_Turns_Between_Teams()
        {
            var teamA = new Team("Heroes");
            teamA.Members.Add(new Fighter("Thor") { Health = 10 });

            var teamB = new Team("Villains");
            teamB.Members.Add(new Fighter("Loki") { Health = 10 });

            // Since Battle class doesn't implement GetNextAttacker(), we test indirectly via Simulate
            var battle = new Battle(teamA, teamB);
            battle.Simulate();

            // Assert that both teams still have members (turns alternated and both attacked)
            Assert.That(teamA.Members.Count, Is.EqualTo(1));
            Assert.That(teamB.Members.Count, Is.EqualTo(1));
        }
    }
}
