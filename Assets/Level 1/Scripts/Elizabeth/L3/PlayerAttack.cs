using UnityEngine;

    public class PlayerAttack : MonoBehaviour
    {
        public Attack currentAttack;
        private PlayerAnimationControllerLvl3 playerAnimationController;

        private void Start()
        {
            currentAttack = new Attack(); // Default attack...
            playerAnimationController = GetComponent<PlayerAnimationControllerLvl3>();
        }

        private void Update()
        {
            HandleAttack();
        }

      public void HandleAttack()
        {
     
        if (Input.GetKeyDown(KeyCode.Z)) //Attack Key
            {
                currentAttack.ExecuteAttack(transform); // Call the ExecuteAttack method from Attack Class based on current equipped attack
                playerAnimationController.PlayAttackAnimation(currentAttack.AnimationTrigger);
            
        }

            //Equips weapons
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeWeapon(new Attack());
                Debug.Log("Equipped Fist Attack");
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                ChangeWeapon(new SwordAttack());
                Debug.Log("Equipped Sword Attack");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                ChangeWeapon(new StickAttack());
                Debug.Log("Equipped Stick Attack");
            }
        }

        public void ChangeWeapon(Attack newWeapon)
        {
            currentAttack = newWeapon;
        }
    }

