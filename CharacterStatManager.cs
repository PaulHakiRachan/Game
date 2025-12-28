using UnityEngine;

public class CharacterStatManager : MonoBehaviour
{
    protected CharacterManager character;

    [Header("Health Stats")]
    public float vitality = 1;
    public float currentHealth = 100;
    public float baseHealth = 100;
    

    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (currentHealth == value) return;

            float old = currentHealth;
            currentHealth = value;

            OnCurrentHealth?.Invoke(old, value);
        }
    }

    public event System.Action<float, float> OnCurrentHealth;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
        OnCurrentHealth += OnCurrentHealthChange;
    }

    protected virtual void OnCurrentHealthChange(float oldFloat, float newFloat)
    {
        
    }
}
