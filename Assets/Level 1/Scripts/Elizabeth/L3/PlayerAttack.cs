using UnityEngine;
using UnityEngine.UI;  // Import to work with UI Image

public class PlayerAttack : MonoBehaviour
{
    public Attack currentAttack;
    private PlayerAnimationControllerLvl3 playerAnimationControllerLvl3;

    // Reference to the UI Image that will show the attack icon
    public Image AttackIcon;

    // References to the sprites for each attack type (these should be assigned in the Inspector)
    public Sprite StickAttack;
    public Sprite SwordAttack;
    public Sprite FistAttack;

    private void Start()
    {
        // Default weapon is FistAttack
        currentAttack = new Attack();
        playerAnimationControllerLvl3 = GetComponent<PlayerAnimationControllerLvl3>();
        UpdateAttackIcon(); // Set the initial image for the attack

    }

    private void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        // Trigger attack based on key press (or joystick input)
        if (Input.GetKeyDown(KeyCode.X)) // Example key for basic attack
        {
            currentAttack.ExecuteAttack(transform); // Execute the current attack
            playerAnimationControllerLvl3.PlayAttackAnimation(currentAttack.AnimationTrigger);
        }

        // Change weapon input (Example keys: R for Fist, C for Sword, F for Stick)
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeWeapon(new Attack());
            Debug.Log("Equipped Fist Attack");
            AttackIcon.sprite = FistAttack;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeWeapon(new SwordAttack());
            Debug.Log("Equipped Sword Attack");
            AttackIcon.sprite = SwordAttack;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeWeapon(new StickAttack());
            Debug.Log("Equipped Stick Attack");
            AttackIcon.sprite = StickAttack;
        }
    }

    // Switch to a new weapon and update the attack icon accordingly
    public void ChangeWeapon(Attack newWeapon)
    {
        currentAttack = newWeapon;

    }

    // Update the attack icon based on the current weapon (Fist, Sword, Stick)
    private void UpdateAttackIcon()
    {
        if (currentAttack is Attack)
        {
            AttackIcon.sprite = FistAttack; // Set Fist icon
        }

    }
}
