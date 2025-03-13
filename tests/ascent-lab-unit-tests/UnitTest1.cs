namespace ascent_lab_unit_tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        bool expected = true;

        // Act
        bool actual = true;

        // Assert
        Assert.Equal(expected, actual);
    }
}
 