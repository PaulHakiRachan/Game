using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    //public static CharacterManager instance;
    [HideInInspector] public PlayerAnimatorManger playerAnimatorManager;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public PlayerDodge playerDodge;
    [HideInInspector] public PlayerInput playerInput;
    [HideInInspector] public PlayerStatManager playerStatManager;
    [HideInInspector] public PlayerCurrentState playerCurrentState;
    [HideInInspector] public PlayerEffectsManager playerEffectManager;
    [HideInInspector] public PlayerUIPopUpManager playerUIPopUpManager;
    [HideInInspector] public PlayerInventoryManager playerInventoryManager;
    [HideInInspector] public PlayerEquipmentManager playerEquipmentManager;
    [HideInInspector] public PlayerCombatManager playerCombatManager;

    [HideInInspector] public AICharacterManager aICharacterManager;
    [HideInInspector] public Player player;

    [HideInInspector] public CharacterCurrentState characterCurrentState;
    [HideInInspector] public CharacterStatManager characterStatManager;
    [HideInInspector] public CharacterSFXManager characterSFXManager;

    [Header("Character Group")]
    public CharacterGroup characterGroup;
    
    protected virtual void Awake()
    {
        
        playerAnimatorManager = GetComponent<PlayerAnimatorManger>();
        playerMovement = GetComponent<PlayerMovement>();
        playerDodge = GetComponent<PlayerDodge>();
        playerInput = GetComponent<PlayerInput>();
        playerStatManager = GetComponent<PlayerStatManager>();
        playerCurrentState = GetComponent<PlayerCurrentState>();
        playerEffectManager = GetComponent<PlayerEffectsManager>();
        playerInventoryManager = GetComponent<PlayerInventoryManager>();
        playerEquipmentManager = GetComponent<PlayerEquipmentManager>();
        playerCombatManager = GetComponent<PlayerCombatManager>();

        aICharacterManager = GetComponent<AICharacterManager>();
        player = GetComponent<Player>();

        characterCurrentState = GetComponent<CharacterCurrentState>();
        characterStatManager = GetComponent<CharacterStatManager>();
        characterSFXManager = GetComponent<CharacterSFXManager>();

    }

    protected virtual void FixedUpdate()
    {
        
    }
}
