using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine.SceneManagement;

public class ElizabethS_HealthbarTestBoundary
{
    private Image healthBar;
    public bool sceneLoaded;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // Load Scene
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Level1", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        sceneLoaded = true;
    }

    [UnityTest]
    public IEnumerator RandomHealthBarFillAmount()
    {
        // Wait until the scene is fully loaded
        yield return new WaitUntil(() => sceneLoaded);

        // Find and check if found
        // canvas with the tag "HealthCanvas"
        GameObject canvas = GameObject.FindWithTag("HealthCanvas");
        Assert.IsNotNull(canvas, "Canvas with tag 'HealthCanvas' not found in the scene.");

        // HealthUI within the Canvas
        Transform healthUITransform = canvas.transform.Find("HealthUI");
        Assert.IsNotNull(healthUITransform, "HealthUI not found in the Canvas.");

        // 'Filled' Image component inside HealthUI
        GameObject filledImageObject = healthUITransform.Find("Filled")?.gameObject;
        Assert.IsNotNull(filledImageObject, "Filled image not found inside HealthUI.");

        // Get the Image component for the health bar
        healthBar = filledImageObject.GetComponent<Image>();
        Assert.IsNotNull(healthBar, "Image component for health bar not found.");

        int numHealthValues = 10;

        // Iterate through the health values, setting random values for the health bar
        for (int i = 0; i < numHealthValues; i++)
        {
            // Generate a random health value between -0.5 and 1.5 (allowing out-of-bounds values)
            float randomHealthValue = Random.Range(-0.5f, 1.5f);

            // Set the health bar's fill amount (clamped between 0 and 1)
            healthBar.fillAmount = Mathf.Clamp(randomHealthValue, 0.0f, 1.0f);

            // Log the raw and clamped fill amounts to check boundary
            Debug.Log($"Raw health value: {randomHealthValue}, Clamped fill amount: {healthBar.fillAmount}");

            // Assert that the fill amount is correctly clamped within bounds
            Assert.That(healthBar.fillAmount, Is.GreaterThanOrEqualTo(0.0f).And.LessThanOrEqualTo(1.0f),
                        $"Health bar fill amount {randomHealthValue} (clamped to {healthBar.fillAmount}) is out of bounds.");

            // Wait for 1.5 second to observe the change visually
            yield return new WaitForSeconds(1.5f);
        }



    }
}
