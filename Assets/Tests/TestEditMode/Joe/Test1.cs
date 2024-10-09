using NUnit.Framework;

[TestFixture]  // Marks this class as a test class
public class PlayerMovementTests
{
    private PlayerMovement _playerMovement;

    [SetUp]  // This runs before every test
    public void SetUp()
    {
        _playerMovement = new PlayerMovement();  // Initialize the class being tested
    }

    [Test]  // Marks this method as a test case
    public void CalculateSpeed_DistanceAndTimeGiven_ReturnsCorrectSpeed()
    {
        // Arrange
        float distance = 100f;
        float time = 10f;

        // Act
        float result = _playerMovement.CalculateSpeed(distance, time);

        // Assert
        Assert.AreEqual(10f, result);  // Speed should be 100 / 10 = 10
    }

    [Test]
    public void CalculateSpeed_TimeIsZero_ReturnsZero()
    {
        // Arrange
        float distance = 100f;
        float time = 0f;

        // Act
        float result = _playerMovement.CalculateSpeed(distance, time);

        // Assert
        Assert.AreEqual(0f, result);  // If time is zero, speed should be 0
    }

    [Test]
    public void CalculateSpeed_NegativeTime_ReturnsZero()
    {
        // Arrange
        float distance = 100f;
        float time = -5f;

        // Act
        float result = _playerMovement.CalculateSpeed(distance, time);

        // Assert
        Assert.AreEqual(0f, result);  // If time is negative, speed should be 0
    }
}
