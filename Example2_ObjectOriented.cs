// LEVEL 2: OBJECT ORIENTED PROGRAMMING
using System;
using System.Collections.Generic;

public class Frame
{
    public int[] Rolls { get; }
    public bool IsStrike => Rolls[0] == 10;
    public bool IsSpare => Rolls.Length == 2 && Rolls[0] + Rolls[1] == 10;
    public int Score => Rolls[0] + Rolls[1];
    public int BonusRolls => IsStrike ? 2 : IsSpare ? 1 : 0;

    public Frame(int[] rolls)
    {
        Rolls = rolls;
    }

    public int CalculateScore(int[] nextRolls, int nextRollIndex)
    {
        int score = Score;

        for (int i = 0; i < BonusRolls; i++)
        {
            score += nextRolls[nextRollIndex + i];
        }

        return score;
    }
}

public class BowlingGame
{
    private List<Frame> frames;

    public BowlingGame(int[] rolls)
    {
        frames = new List<Frame>();

        for (int i = 0; i < rolls.Length; i += 2)
        {
            int[] frameRolls = new int[2];

            if (rolls[i] == 10)
            {
                frameRolls[0] = 10;
            }
            else
            {
                frameRolls[0] = rolls[i];
                frameRolls[1] = rolls[i + 1];
            }

            frames.Add(new Frame(frameRolls));
        }
    }

    public int Score()
    {
        int totalScore = 0;

        for (int i = 0; i < frames.Count; i++)
        {
            totalScore += frames[i].CalculateScore(GetNextRolls(i), GetNextRollIndex(i));
        }

        return totalScore;
    }

    private int[] GetNextRolls(int currentIndex)
    {
        List<int> nextRolls = new List<int>();

        for (int i = currentIndex + 1; i < frames.Count; i++)
        {
            nextRolls.AddRange(frames[i].Rolls);
        }

        return nextRolls.ToArray();
    }

    private int GetNextRollIndex(int currentIndex)
    {
        int nextRollIndex = 0;

        for (int i = currentIndex + 1; i < frames.Count; i++)
        {
            nextRollIndex += frames[i].Rolls.Length;
        }

        return nextRollIndex;
    }
}
