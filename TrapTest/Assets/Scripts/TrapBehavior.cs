using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{

    [SerializeField] private TrapTargetType trapTargetType; private TrapType trapType;
    private Trap trap;

    private void Awake()
    {
        trap = new Trap();
    }
    private void OnTriggerEnter(Collider other)
    {
        var characterMover = other.GetComponent<ICharacterMovement>();
        trap.HandleCharacterEntered(characterMover, trapTargetType, trapType);

    }
}

public class Trap
{
    public void HandleCharacterEntered(ICharacterMovement characterMover, TrapTargetType trapTargetType, TrapType trapType)
    {


        if(trapType == TrapType.Slow)
        {
            if (characterMover.IsPlayer)
            {
                if (trapTargetType == TrapTargetType.Player)
                    characterMover.Speed--;
            }
            else
            {
                if (trapTargetType == TrapTargetType.Npc)
                    characterMover.Speed--;
            }
        }
        else if(trapType == TrapType.Damage)
        {
            if (characterMover.IsPlayer)
            {
                if (trapTargetType == TrapTargetType.Player)
                    characterMover.Health--;
            }
            else
            {
                if (trapTargetType == TrapTargetType.Npc)
                    characterMover.Health--;
            }
        }
        else if (trapType == TrapType.Water)
        {
            if (characterMover.IsPlayer)
            {
                if (trapTargetType == TrapTargetType.Player)
                    characterMover.IsDrowned = true;
            }
            else
            {
                if (trapTargetType == TrapTargetType.Npc)
                    characterMover.IsDrowned = true;
            }
        }


    }
}

public enum TrapTargetType {Player, Npc}
public enum TrapType {Damage, Slow, Water}