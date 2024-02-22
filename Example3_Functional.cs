// LEVEL 3: FUNCTIONAL PROGRAMMING PARADIGM
using System;
using System.Collections.Generic;
using System.Linq;

public static class BowlingGame
{
    public static int Score(int[] rolls)
    {
        return ScoreFrame(rolls.ToList(), 1, 0);
    }

    private static int ScoreFrame(List<int> rolls, int frame, int totalScore)
    {
        if (frame > 10 || !rolls.Any()) // Base case: all frames are scored or no rolls left
            return totalScore;

        if (rolls.First() == 10)
        {
            totalScore += 10 + rolls.Skip(1).Take(2).Sum();
            return ScoreFrame(rolls.Skip(1).ToList(), frame + 1, totalScore);
        }
        else if (rolls.Take(2).Sum() == 10)
        {
            totalScore += 10 + rolls.Skip(2).First();
            return ScoreFrame(rolls.Skip(2).ToList(), frame + 1, totalScore);
        }
        else
        {
            totalScore += rolls.Take(2).Sum();
            return ScoreFrame(rolls.Skip(2).ToList(), frame + 1, totalScore);
        }
    }
}
