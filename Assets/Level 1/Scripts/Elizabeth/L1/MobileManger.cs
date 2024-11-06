using UnityEngine;

public class MobileManager : MonoBehaviour
{
    // Reference to the joystick UI element (set this in the Inspector)
    public GameObject joystick;

    void Start()
    {
        // Check if the build is for a mobile platform (iOS/Android)
#if UNITY_IOS || UNITY_ANDROID
        joystick.SetActive(true);  // Enable joystick on mobile builds
#else
            joystick.SetActive(false); // Disable joystick on non-mobile builds (PC, Mac, etc.)
#endif
    }
}
