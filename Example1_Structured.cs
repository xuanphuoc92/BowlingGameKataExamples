// LEVEL 1: STRUCTURAL PROGRAMMING
using System;

public static class BowlingGame
{
    public static int Score(int[] rolls)
    {
        int totalScore = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (rolls[rollIndex] == 10) // Strike Frame
            {
                totalScore += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
                rollIndex++;
            }
            else if (rolls[rollIndex] + rolls[rollIndex + 1] == 10) // Spare Frame
            {
                totalScore += 10 + rolls[rollIndex + 2];
                rollIndex += 2;
            }
            else // Normal Frame
            {
                totalScore += rolls[rollIndex] + rolls[rollIndex + 1];
                rollIndex += 2;
            }
        }

        return totalScore;
    }
}
