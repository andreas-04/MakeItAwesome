using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
/*
public class EnemyTests
{
    private GameObject enemy;

    [SetUp]
    public void Setup()
    {
        enemy = new GameObject("Enemy");
        enemy.AddComponent<Rigidbody>();
        enemy.AddComponent<BoxCollider>();
        var health = enemy.AddComponent<EnemyHealth>();
        health.maxHealth = 100;
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(enemy);
    }

    [Test]
    public void EnemyHasHealth()
    {
        var health = enemy.GetComponent<EnemyHealth>();
        Assert.IsNotNull(health, "Enemy should have a health component.");
    }

    [Test]
    public void EnemyHealthInitializedCorrectly()
    {
        var health = enemy.GetComponent<EnemyHealth>();
        Assert.AreEqual(100, health.CurrentHealth, "Enemy health should initialize to max health.");
    }

    [Test]
    public void EnemyTakesDamage()
    {
        var health = enemy.GetComponent<EnemyHealth>();
        health.TakeDamage(20);
        Assert.AreEqual(80, health.CurrentHealth, "Enemy health should decrease when taking damage.");
    }

    [Test]
    public void EnemyDiesAtZeroHealth()
    {
        var health = enemy.GetComponent<EnemyHealth>();
        health.TakeDamage(100);
        Assert.AreEqual(0, health.CurrentHealth, "Enemy health should be zero when damaged fully.");
        Assert.IsTrue(health.IsDead, "Enemy should be marked as dead when health reaches zero.");
    }

    [Test]
    public void EnemyRespawns()
    {
        var health = enemy.GetComponent<EnemyHealth>();
        health.TakeDamage(100);
        health.Respawn();
        Assert.AreEqual(100, health.CurrentHealth, "Enemy health should reset to max on respawn.");
        Assert.IsFalse(health.IsDead, "Enemy should no longer be dead after respawn.");
    }

    [Test]
    public void EnemyMovesForward()
    {
        var enemyMovement = enemy.AddComponent<EnemyMovement>();
        Vector3 initialPosition = enemy.transform.position;
        enemyMovement.Move(Vector3.forward, 1f);
        Assert.AreNotEqual(initialPosition, enemy.transform.position, "Enemy should move forward when Move is called.");
    }

    [Test]
    public void EnemyCollidesWithPlayer()
    {
        var player = new GameObject("Player");
        player.AddComponent<BoxCollider>();
        player.tag = "Player";

        bool collisionDetected = false;
        enemy.AddComponent<EnemyCollision>().OnPlayerCollision += () => collisionDetected = true;

        // Simulate collision
        Physics.Simulate(0.1f);
        Assert.IsTrue(collisionDetected, "Enemy should detect collision with the player.");
    }

    [UnityTest]
    public IEnumerator EnemyTakesDamageOverTime()
    {
        var health = enemy.GetComponent<EnemyHealth>();
        for (int i = 0; i < 5; i++)
        {
            health.TakeDamage(10);
            yield return null; // Wait for next frame
        }
        Assert.AreEqual(50, health.CurrentHealth, "Enemy should lose health over time.");
    }

    [Test]
    public void EnemyDetectsPlayerInRange()
    {
        var player = new GameObject("Player");
        player.transform.position = new Vector3(0, 0, 5);
        var enemyAI = enemy.AddComponent<EnemyAI>();
        enemyAI.detectionRange = 10f;

        bool playerDetected = enemyAI.IsPlayerInRange(player.transform.position);
        Assert.IsTrue(playerDetected, "Enemy should detect player within range.");
    }

    [Test]
    public void EnemyDoesNotDetectPlayerOutOfRange()
    {
        var player = new GameObject("Player");
        player.transform.position = new Vector3(0, 0, 15);
        var enemyAI = enemy.AddComponent<EnemyAI>();
        enemyAI.detectionRange = 10f;

        bool playerDetected = enemyAI.IsPlayerInRange(player.transform.position);
        Assert.IsFalse(playerDetected, "Enemy should not detect player outside of range.");
    }
}
*/