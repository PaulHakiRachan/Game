using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIUndeadCombatManager : AICharacterCombatManager

{
    private AICharacterManager aICharacter;

    [Header("Damage Colliders")]
    [SerializeField] UndeadHandDamageCollider rightHandDamageCollider;
    [SerializeField] UndeadHandDamageCollider leftHandDamageCollider;
    
    [Header("Damage")]
    [SerializeField] int baseDamage = 25;
    [SerializeField] float attack01DamageModifier = 1.0f;
    [SerializeField] float attack02DamageModifier = 1.4f;

    protected override void Awake()
    {
        aICharacter = GetComponent<AICharacterManager>();
    }

    private void Update()
    {
        HandleAttackMovement01();
        HandleAttackRunning02();
        HandleAttackMovement02();
    }

    public void SetAttack01Damage()
    {
        rightHandDamageCollider.physicalDamage = baseDamage * attack01DamageModifier;
        leftHandDamageCollider.physicalDamage = baseDamage * attack01DamageModifier;
    }

    public void SetAttack02Damage()
    {
        rightHandDamageCollider.physicalDamage = baseDamage * attack02DamageModifier;
        leftHandDamageCollider.physicalDamage = baseDamage * attack02DamageModifier;
    }

    public void OpenRightHandDamageCollider()
    {
        rightHandDamageCollider.EnableDamageCollider();
    }

    public void DisableRightHandDamageCollider()
    {
        rightHandDamageCollider.DisableDamageCollider();
    }

    public void OpenLeftHandDamageCollider()
    {
        leftHandDamageCollider.EnableDamageCollider();
    }

    public void DisableLeftHandDamageCollider()
    {
        leftHandDamageCollider.DisableDamageCollider();
    }

    [Header("Attack Setting")]

    [Header("Attack01 Settings")]
    [SerializeField] float walkingSpeed = 1f;
    private bool canWalingToAttack = false;

    public void EnableAttack01Walking()
    {
        canWalingToAttack = true;
        aICharacter.animator.SetBool("isWalking", true);
        aICharacter.aIAnimationManager.PlayerTargetActionAnimation("Undead_WalkToAttack", true);
    }

    public void DisableAttack01Walking()
    {
        canWalingToAttack = false;
        aICharacter.animator.CrossFade("EmptyState", 0.3f);
        aICharacter.animator.SetBool("isWalking", false);
        aICharacter.characterSFXManager.PlaySFX(WorldSFXManager.instance.ChooseRandomSFXFromArray(WorldSFXManager.instance.UndeadAttackSFX), 0.1f);
    }

    public void HandleAttackMovement01()
    {
        if (canWalingToAttack)
        {
            if (!aICharacter.navMeshAgent.enabled) //ไม่มีnavmesh กำหนด เปิดnavmeshให้
            {
                aICharacter.navMeshAgent.enabled = true;
            }

            Vector3 direction = aICharacter.transform.forward;
            Vector3 velocity = direction * walkingSpeed;
            aICharacter.characterController.Move(velocity * Time.deltaTime);
        }
    }

    [Header("Attack02 Settings")]
    [SerializeField] float runningSpeed = 3;
    [SerializeField] float dashSpeed02 = 5f;
    [SerializeField] float dashDuration02 = 0.2f; // ระยะเวลาที่จะพุ่ง
    private bool canRunningToAttack = false;
    private float currentDashTime02;
    public bool isDashing02; // เปิด-ปิดจาก Animation Event

    public void EnableAttack02Running()
    {
        canRunningToAttack = true;
        aICharacter.animator.SetBool("isRunning", true);
        aICharacter.aIAnimationManager.PlayerTargetActionAnimation("Undead_RunToAttack", true);
    }
    
    public void DisableAttack02Running()
    {
        canRunningToAttack = false;
        aICharacter.animator.CrossFade("EmptyState", 0.1f);
        aICharacter.animator.SetBool("isRunning", false);
        currentDashTime02 = dashDuration02;
        isDashing02 = true;
        aICharacter.characterSFXManager.PlaySFX(WorldSFXManager.instance.ChooseRandomSFXFromArray(WorldSFXManager.instance.UndeadAttackSFX), 0.1f);
    }

    public void HandleAttackRunning02()
    {
        if (canRunningToAttack)
        {
            if (!aICharacter.navMeshAgent.enabled) //ไม่มีnavmesh กำหนด เปิดnavmeshให้
            {
                aICharacter.navMeshAgent.enabled = true;
            }

            Vector3 direction = aICharacter.transform.forward;
            Vector3 velocity = direction * runningSpeed;
            aICharacter.characterController.Move(velocity * Time.deltaTime);
        }
    }

    public void HandleAttackMovement02()
    {
        if (isDashing02)
        {
            if (currentDashTime02 > 0)
            {
                Debug.Log("Dash!");
                Vector3 direction = aICharacter.transform.forward;
                Vector3 velocity = direction * dashSpeed02;
                aICharacter.characterController.Move(velocity * Time.deltaTime);
                currentDashTime02 -= Time.deltaTime;
            }
            else
            {
                isDashing02 = false;
            }
        }
    }
}
