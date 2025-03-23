class PlintenCalculator
{
    public static int CalculateSkirtingNeeded(double skirtingLength, List<double> requiredPieces)
    {
        // First sort the list of required pieces, from large to small.
        var sortedCuts = requiredPieces.OrderDescending().ToList();
        
        // Store the amount of skirt that is not yet cut
        var skirtRemaining = skirtingLength;
        
        // Count the amount of skirting needed
        var skirtingNeeded = 1;
        
        while (sortedCuts.Count > 0)
        {
            var pieceIndex = sortedCuts.FindIndex(skirt => skirt <= skirtRemaining);
            if (pieceIndex == -1)
            {
                skirtingNeeded++;
                skirtRemaining = skirtingLength;
            }
            else
            {
                skirtRemaining -= sortedCuts[pieceIndex];
                sortedCuts.RemoveAt(pieceIndex);
            }
        }

        return skirtingNeeded;
    }
}

// See https://aka.ms/new-console-template for more information


