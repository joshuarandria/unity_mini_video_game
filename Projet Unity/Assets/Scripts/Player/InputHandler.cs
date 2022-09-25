using System.Collections;
using System.Collections.Generic;
using SG;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;


    public bool b_Input;
    public bool rb_Input;
    public bool rt_Input;
    public bool space_Input;
    public bool rollFlag;
    public bool sprintFlag;
    public bool comboFlag;
    public float rollInputTimer;
    

    PlayerControls inputActions;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    PlayerManager playerManager;
    Vector2 movementInput;
    Vector2 cameraInput;

    private void Awake()
    {
        playerAttacker = GetComponent<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();
        playerManager = GetComponent<PlayerManager>();
    }

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
        HandleRollInput(delta);
        HandleAttackInput(delta);
    }

    public void MoveInput(float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;

    }

    private void HandleRollInput(float delta)
    {
        b_Input = inputActions.PlayerActions.Roll.phase
            == UnityEngine.InputSystem.InputActionPhase.Started;
        if (b_Input)
        {
            
            rollInputTimer += delta;
            sprintFlag = true;
        }
        else
        {
            if (rollInputTimer > 0 && rollInputTimer < 0.5f)
            {
                
                sprintFlag = false;
                rollFlag = true;
            }
            rollInputTimer = 0;
        }
    }

    private void HandleAttackInput(float delta)
    {
        inputActions.PlayerActions.RB.performed += i => rb_Input=true;
        inputActions.PlayerActions.RT.performed += i => rt_Input = true;
        inputActions.PlayerActions.Space.performed += i => space_Input = true;

        if (rb_Input)
        {
            SpellCooldown action1 = GameObject.Find("leftClickAction").GetComponent<SpellCooldown>();
            if (!(action1.cooldownTimer > 0.0f))
            {
                action1.UseSpell();
                playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
            }
            /*if (playerManager.canDoCombo)
            {
                comboFlag = true;
                playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                comboFlag = false;
            }
            else
            {
                if (playerManager.isInteracting)
                    return;
                if (playerManager.canDoCombo)
                    return;
                playerAttacker.HandleLightAttack(playerInventory.rightWeapon);

            }*/

        }
        if (rt_Input)
        {
            SpellCooldown action2 = GameObject.Find("rightClickAction").GetComponent<SpellCooldown>();
            if (!(action2.cooldownTimer > 0.0f))
            {
                action2.UseSpell();
                comboFlag = true;
                playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                comboFlag = false;
            }
            
        }
        if (space_Input)
        {
            SpellCooldown action3 = GameObject.Find("spaceAction").GetComponent<SpellCooldown>();
            if (!(action3.cooldownTimer > 0.0f))
            {
                action3.UseSpell();
                playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
            }
        }
    }
}


