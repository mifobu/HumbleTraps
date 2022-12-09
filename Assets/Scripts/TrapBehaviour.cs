using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField]
    private TrapTargetType trapType;

    private Trap trap;

    void Awake()
    {
        trap = new Trap();
    }

    void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, trapType);
    }
}

public class Trap
{
    public void HandleCharacterEntered(ICharacterMover characterMover, TrapTargetType trapTargetType)
    {
        if (characterMover.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
            {
                if (characterMover.Health == 0)
                {
                    characterMover.Health = 3;
                }
                else if (characterMover.Health > 0)
                {
                    characterMover.Health--;
                }
                
            }
        } 
        else
        {
            if (trapTargetType == TrapTargetType.Npc)
            {
                if (characterMover.Health == 0)
                {
                    characterMover.Health = 3;
                }
                else if (characterMover.Health > 0)
                {
                    characterMover.Health--;
                }
            }
        }
    }
}

public enum TrapTargetType { Player, Npc}