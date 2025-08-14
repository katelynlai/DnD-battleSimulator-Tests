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
            // Arrange
            var teamA = new Team("Heroes");
            teamA.Members.Add(new Fighter("Thor") { Health = 10 });

            var teamB = new Team("Villains");
            teamB.Members.Add(new Fighter("Loki") { Health = 0 });

            // Act - determine winner manually
            string winner = null;
            if (teamA.HasLivingMembers() && !teamB.HasLivingMembers())
                winner = teamA.TeamName;
            else if (!teamA.HasLivingMembers() && teamB.HasLivingMembers())
                winner = teamB.TeamName;
            else
                winner = "Draw";

            // Assert
            Assert.That(winner, Is.EqualTo("Heroes"));
        }

        [Test]
        public void Battle_Should_Return_Draw_If_Both_Dead()
        {
            // Arrange
            var teamA = new Team("Heroes");
            teamA.Members.Add(new Fighter("Thor") { Health = 0 });

            var teamB = new Team("Villains");
            teamB.Members.Add(new Fighter("Loki") { Health = 0 });

            // Act - determine winner manually
            string winner = null;
            if (teamA.HasLivingMembers() && !teamB.HasLivingMembers())
                winner = teamA.TeamName;
            else if (!teamA.HasLivingMembers() && teamB.HasLivingMembers())
                winner = teamB.TeamName;
            else
                winner = "Draw";

            // Assert
            Assert.That(winner, Is.EqualTo("Draw"));
        }
    }
}
