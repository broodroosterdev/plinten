namespace Plinten;

class PlintenCalculator
{
    public static int CalculateSkirtingNeeded(double skirtingLength, List<double> requiredPieces)
    {
        // First sort the list of required pieces, from large to small.
        var sortedPieces = requiredPieces.OrderDescending().ToList();
        
        // Store the amount of skirt that is not yet cut
        var skirtRemaining = skirtingLength;
        
        // Count the amount of skirting needed
        var skirtingNeeded = 1;
        
        // Loop through the sorted pieces, until all pieces have been cut
        while (sortedPieces.Count > 0)
        {
            // Go through the list from large to small, until a piece is found that will fit on the remaining space of the skirt.
            var pieceIndex = sortedPieces.FindIndex(skirt => skirt <= skirtRemaining);
            
            // An index of -1 indicates no piece was found that will fit the remaining space.
            // This means the remaining space is too small to be used, so a new skirt is needed.
            if (pieceIndex == -1)
            {
                skirtingNeeded++;
                skirtRemaining = skirtingLength;
            }
            // If we did find a piece that matches:
            else
            {
                // Subtract the length from the remaining space and remove the piece from the list.
                skirtRemaining -= sortedPieces[pieceIndex];
                sortedPieces.RemoveAt(pieceIndex);
            }
        }
        
        // When we finish from the loop, it means all pieces have found its way on a skirt.
        // We can then return the total amount of skirts needed
        return skirtingNeeded;
    }
}