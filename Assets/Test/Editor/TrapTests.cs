using NUnit.Framework;
using NSubstitute;

public class TrapTests
{
    [Test]
    public void PlayerEnteringPlayerTargetingTrapReducesHealthByOne() 
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        characterMover.IsPlayer.Returns(true);
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);
        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void NpcEnteringNpcTargetingTrapReducesHealthByOne() 
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Npc);
        Assert.AreEqual(-1, characterMover.Health);
    }
}

