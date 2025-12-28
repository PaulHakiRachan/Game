using UnityEngine;

[CreateAssetMenu(menuName = "A.I/States/Death")]

public class AIDeathState : AIState
{
    public void SwitchToDeathState(AICharacterManager aICharacter)
    {
        SwitchState(aICharacter, this);
    }

    protected override AIState SwitchState(AICharacterManager aICharacter, AIState newState)
    {
        Debug.Log("DEATH");
        return this;
    }
}
