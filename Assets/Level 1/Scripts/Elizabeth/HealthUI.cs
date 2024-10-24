using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour, IObserver
{
    [SerializeField] Subject player;  // Player object reference
    Image healthUI;

    private void OnEnable()
    {
        player.addObserver(this);
        healthUI = transform.Find("Filled").GetComponent<Image>();
    }

    private void OnDisable()
    {
        player.removeObserver(this);
    }

    public void OnNotify(PlayerActions action, float currentHealth)
    {
        // Normalize the health to set fill amount
        healthUI.fillAmount = currentHealth / 100f;  //health is between 0 and 100

        switch (action)
        {
            case PlayerActions.damaged:
                Debug.Log("Ouch. Damage Taken");
                Debug.Log("Health: " + currentHealth);
                return;
            case PlayerActions.healed:
                Debug.Log("Thirst Quenching");
                Debug.Log("Health: " + currentHealth);
                return;
        }
    }
}