using UnityEngine;
using UnityEngine.TextCore.Text;

public class AIStatManager : CharacterStatManager
{
    AICharacterManager aICharacter;
    protected override void Awake()
    {
        base.Awake();
        aICharacter = GetComponent<AICharacterManager>();
    }

    protected override void OnCurrentHealthChange(float oldFloat, float newFloat)
    {
        if(newFloat <= 0)
        {
            CurrentHealth = 0;
            StartCoroutine(aICharacter.ProcessingDeath());
        }
    }
}
