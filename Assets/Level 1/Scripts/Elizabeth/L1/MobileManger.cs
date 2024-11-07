using UnityEngine;
using UnityEngine.UI;  // Make sure to include this to access the Button component

public class MobileManager : MonoBehaviour
{
    // Reference to the joystick and button UI elements (set these in the Inspector)
    public GameObject joystick;
    public GameObject attackButton;  // Reference to the attack button

    void Start()
    {
        // Check if the build is for a mobile platform 
#if UNITY_IOS || UNITY_ANDROID
        joystick.SetActive(true);  // Enable joystick on mobile builds
        attackButton.SetActive(true);  // Enable attack button on mobile builds
#else
        joystick.SetActive(false);  // Disable joystick on non-mobile builds 
        attackButton.SetActive(false);  // Disable attack button on non-mobile builds
#endif
    }
}
