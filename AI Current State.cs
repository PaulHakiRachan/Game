using UnityEngine;

public class AICurrentState : CharacterCurrentState
{ 
    private AICharacterManager aICharacter;

    public void EnableCanRotate()
    {
        canRotate = true;
    }

    public void DisableCanRotate()
    {
        canRotate = false;
    }

    private bool isTargeting;
    public bool IsTargeting
    {
        get => isTargeting;
        set
        {
            if (isTargeting == value) return;

            bool old = isTargeting;
            isTargeting = value;

            OnTargeting?.Invoke(old, value);
        }
    }

    public event System.Action<bool, bool> OnTargeting;

    private void Awake()
    {
        aICharacter = GetComponent<AICharacterManager>();
        OnTargeting += OnTargetingBoolChanage;
    }

    private void OnTargetingBoolChanage(bool oldBool, bool newBool)
    {
        aICharacter.animator.SetBool("isTargeting", newBool);
    }
}
