using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

public class TrapTests
{
    [Test]
    public void NpcEnteringTrap_NpcTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        characterMover.Health = 1;
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Npc);

        Assert.AreEqual(0, characterMover.Health);
    }

    [Test]
    public void PlayerEnteringTrap_PlayerTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        characterMover.IsPlayer.Returns(true);
        characterMover.Health = 1;
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);

        Assert.AreEqual(0, characterMover.Health);
    }

    [Test]
    public void PlayerEnteringTrapPlayerTargetedTrapHealthAtOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        characterMover.IsPlayer.Returns(true);
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);
        //characterMover.Health = 3;
        Assert.AreEqual(3, characterMover.Health);
    }

    [Test]
    public void NpcEnteringTrapNpcTargetedTrapHealthAtOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, TrapTargetType.Npc);
        //characterMover.Health = 3;
        Assert.AreEqual(3, characterMover.Health);
    }
}
