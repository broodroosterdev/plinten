using Plinten;
using Xunit;

public class PlintenCalculatorTests
{
    [Theory]
    // Tests from assignment
    [InlineData(new double[] {240, 60}, 1)]
    [InlineData(new double[] {240, 60, 100}, 2)]
    
    // Extra tests to make sure solution is robust
    [InlineData(new double[] {100, 100, 100}, 1)]
    [InlineData(new double[] {100, 150, 100}, 2)]
    [InlineData(new double[] {100, 50, 50, 50, 100}, 2)]
    [InlineData(new double[] {250, 60, 100}, 2)]
    [InlineData(new double[] {250, 60, 250}, 3)]
    public void TestCalculateSkirtingNeeded(double[] requiredPieces, int expectedSkirtingNeeded)
    {
        const double skirtingLength = 300;
        Assert.Equal(expectedSkirtingNeeded, PlintenCalculator.CalculateSkirtingNeeded(skirtingLength, requiredPieces.ToList()));
    }
}