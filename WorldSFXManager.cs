using Unity.VisualScripting;
using UnityEngine;

public class WorldSFXManager : MonoBehaviour
{
    public static WorldSFXManager instance;

    [Header("Damage Sounds")]
    public AudioClip[] physicalDamageSFX;
    
    [Header("Action Sounds")]
    public AudioClip rollSFX;

    [Header("Undead Attack Alert")]
    public AudioClip[] UndeadAttackAlertSFX;

    [Header("Undead Idle")]
    public AudioClip UndeadIdleSFX;

    [Header("Undead Attack")]
    public AudioClip[] UndeadAttackSFX;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public AudioClip ChooseRandomSFXFromArray(AudioClip[] array)
    {
        int index = Random.Range(0, array.Length);

        return array[index];
    }
}
