using UnityEngine;
using UnityEngine.UI;  // Make sure to include this to access the Button component

public class MobileManager : MonoBehaviour
{
    // References to the joystick, attack button, and weapon switch button
    public GameObject joystick;
    public GameObject attackButton;  // Reference to the attack button
    public GameObject switchWeaponButton;  // Reference to the weapon switch button

    void Start()
    {
        // Check if the build is for a mobile platform 
#if UNITY_IOS || UNITY_ANDROID
        joystick.SetActive(true);  // Enable joystick on mobile builds
        attackButton.SetActive(true);  // Enable attack button on mobile builds
        switchWeaponButton.SetActive(true);  // Enable weapon switch button on mobile builds
#else
        joystick.SetActive(false);  // Disable joystick on non-mobile builds 
        attackButton.SetActive(false);  // Disable attack button on non-mobile builds
        switchWeaponButton.SetActive(false);  // Disable weapon switch button on non-mobile builds
#endif
    }
}
