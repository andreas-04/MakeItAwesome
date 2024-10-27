using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ElizabethS_RapidWeaponSwitchTest
{
    private bool sceneLoaded;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene("Scenes/Level3", LoadSceneMode.Single);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        sceneLoaded = true;
    }

    [UnityTest]
    public IEnumerator RapidSwitchAndAttackTest()
    {
        yield return new WaitWhile(() => !sceneLoaded);

        var playerObject = GameObject.Find("Player");
        var playerAttack = playerObject.GetComponent<PlayerAttack>();
        var playerAnimationController = playerObject.GetComponent<PlayerAnimationControllerLvl3>();
        Assert.IsNotNull(playerAttack, "PlayerAttack component not found!");
        Assert.IsNotNull(playerAnimationController, "PlayerAnimationController component not found!");

        int switchAndAttackCount = 0;

        for (int i = 0; i < 100; i++)
        {
            // Switch to Sword and Attack
            playerAttack.ChangeWeapon(new SwordAttack());
            yield return null; // Let Unity process this switch
            Debug.Log($"Switched to Sword: {playerAttack.currentAttack.AnimationTrigger}");
            playerAttack.currentAttack.ExecuteAttack(playerObject.transform);
            playerAnimationController.PlayAttackAnimation(playerAttack.currentAttack.AnimationTrigger);
            switchAndAttackCount++;

            yield return new WaitForSeconds(0.05f);

            // Switch to Stick and Attack
            playerAttack.ChangeWeapon(new StickAttack());
            yield return null;
            Debug.Log($"Switched to Stick: {playerAttack.currentAttack.AnimationTrigger}");
            playerAttack.currentAttack.ExecuteAttack(playerObject.transform);
            playerAnimationController.PlayAttackAnimation(playerAttack.currentAttack.AnimationTrigger);
            switchAndAttackCount++;

            yield return new WaitForSeconds(0.05f);

            // Switch to Fist and Attack
            //playerAttack.ChangeWeapon(new FistAttack());
            //yield return null;
            //Debug.Log($"Switched to Fist: {playerAttack.currentAttack.AnimationTrigger}");
            //playerAttack.currentAttack.ExecuteAttack(playerObject.transform);
            //playerAnimationController.PlayAttackAnimation(playerAttack.currentAttack.AnimationTrigger);
            //switchAndAttackCount++;

            //yield return new WaitForSeconds(0.02f);
        }

        Debug.Log($"Total Switch and Attack Cycles: {switchAndAttackCount}");
        Assert.GreaterOrEqual(switchAndAttackCount, 50, "Not enough switch and attack cycles completed.");
    }
}
