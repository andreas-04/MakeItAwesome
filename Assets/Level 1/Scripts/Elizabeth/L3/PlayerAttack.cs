using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Attack currentAttack;
    private PlayerAnimationControllerLvl3 playerAnimationControllerLvl3;

    // Reference to the UI Button for attack
    public Button attackButton;

    // Sprites for each attack type (assign in the Inspector)
    public Sprite StickAttack;
    public Sprite SwordAttack;
    public Sprite FistAttack;

    // Reference to the weapon switch button (for mobile or desktop)
    public Button switchWeaponButton;

    // Array to store all the weapon types
    private Attack[] weaponTypes;
    private int currentWeaponIndex = 0;

    private void Start()
    {
        // Initialize the weapon types array
        weaponTypes = new Attack[] { new Attack(), new SwordAttack(), new StickAttack() }; // Attack is the base class (Fist)

        // Set default weapon to FistAttack (base class Attack)
        currentAttack = weaponTypes[currentWeaponIndex];
        playerAnimationControllerLvl3 = GetComponent<PlayerAnimationControllerLvl3>();

        // Set the default attack icon and bind the button
        UpdateAttackButtonIcon(FistAttack);
        attackButton.onClick.AddListener(HandleAttack);

        // Bind weapon switch button to switch weapon
        switchWeaponButton.onClick.AddListener(SwitchWeapon);
    }

    private void Update()
    {
        // Handle weapon switching through key inputs (for desktop testing)
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Switch to Fist Attack
            ChangeWeapon(0, FistAttack);
            Debug.Log("Equipped Fist Attack");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Switch to Sword Attack
            ChangeWeapon(1, SwordAttack);
            Debug.Log("Equipped Sword Attack");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Switch to Stick Attack
            ChangeWeapon(2, StickAttack);
            Debug.Log("Equipped Stick Attack");
        }
    }

    private void HandleAttack()
    {
        // Execute the current attack and play the related animation
        currentAttack.ExecuteAttack(transform);
        playerAnimationControllerLvl3.PlayAttackAnimation(currentAttack.AnimationTrigger);
    }

    // Change weapon and update icon based on the index
    public void ChangeWeapon(int weaponIndex, Sprite newIcon)
    {
        currentWeaponIndex = weaponIndex; // Set the current weapon index
        currentAttack = weaponTypes[currentWeaponIndex]; // Update the current weapon
        UpdateAttackButtonIcon(newIcon); // Update the attack icon
    }

    private void UpdateAttackButtonIcon(Sprite newIcon)
    {
        attackButton.GetComponent<Image>().sprite = newIcon;
    }

    // Switch weapon using the switch weapon button (for mobile use)
    private void SwitchWeapon()
    {
        // Cycle through weapons
        currentWeaponIndex = (currentWeaponIndex + 1) % weaponTypes.Length; // Cycle back to 0 when we go past the last index

        // Update current attack and icon based on the new index
        if (currentWeaponIndex == 0)
        {
            ChangeWeapon(currentWeaponIndex, FistAttack);
        }
        else if (currentWeaponIndex == 1)
        {
            ChangeWeapon(currentWeaponIndex, SwordAttack);
        }
        else if (currentWeaponIndex == 2)
        {
            ChangeWeapon(currentWeaponIndex, StickAttack);
        }

        Debug.Log($"Switched to {weaponTypes[currentWeaponIndex].GetType().Name}");
    }
}
