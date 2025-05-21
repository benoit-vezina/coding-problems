using System.Text;

namespace ZigzagConversion;

static class Solution
{
    public static string Convert(string s, int numRows)
    {
        // No changes for single char string or single row
        if (s.Length == 1 || numRows == 1)
            return s;

        // Initialize the string arr
        string[] arr = new string[numRows];
        for (int i = 0; i < numRows; i++)
            arr[i] = string.Empty;

        // Start at first row in Down mode
        Mode activeMode = Mode.Down;
        int row = 0;
        for (int i = 0; i < s.Length; i++)
        {
            arr[row] += s[i];

            // Mode switch conditions
            if (activeMode == Mode.Down && (row + 1) == numRows)
                activeMode = Mode.Diagonal;
            else if (activeMode == Mode.Diagonal && row == 0)
                activeMode = Mode.Down;

            // Increment or decrement the row depending on the mode
            if (activeMode == Mode.Down) row++;
            else if (activeMode == Mode.Diagonal) row--;
        }

        // Build the output
        string output = string.Empty;
        foreach (string el in arr) output += el;

        return output;
    }

    private enum Mode
    {
        Down,
        Diagonal
    }

    public static string ConvertAiOne(string s, int numRows)
    {
        // Edge cases
        if (numRows == 1 || s.Length <= numRows)
            return s;

        // Initialize array of StringBuilder objects for each row
        var rows = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
            rows[i] = new StringBuilder();

        int currentRow = 0;
        bool goingDown = false;

        // Process each character
        foreach (char c in s)
        {
            rows[currentRow].Append(c);

            // Change direction at boundary rows
            if (currentRow == 0 || currentRow == numRows - 1)
                goingDown = !goingDown;

            // Move to next row (up or down)
            currentRow += goingDown ? 1 : -1;
        }

        // Combine all rows
        var result = new StringBuilder();
        foreach (var row in rows)
            result.Append(row);

        return result.ToString();
    }
    
    public static string ConvertAiTwo(string s, int numRows)
    {
        // Edge cases
        if (numRows == 1 || s.Length <= numRows)
            return s;
        
        var result = new StringBuilder(s.Length);
        int cycleLen = 2 * numRows - 2; // Length of one complete zigzag cycle
        
        // Process each row
        for (int i = 0; i < numRows; i++)
        {
            // Process characters for current row
            for (int j = 0; j + i < s.Length; j += cycleLen)
            {
                // Add the primary character in this row
                result.Append(s[j + i]);
                
                // Add the secondary character (if it exists and we're not in first or last row)
                if (i != 0 && i != numRows - 1 && j + cycleLen - i < s.Length)
                    result.Append(s[j + cycleLen - i]);
            }
        }
        
        return result.ToString();
    }
}
