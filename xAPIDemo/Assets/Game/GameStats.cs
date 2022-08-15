using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats
{
    public static bool Rune1Collected, Rune2Collected, Rune3Collected, Rune4Collected, Rune5Collected, Rune6Collected, Rune7Collected, Rune8Collected;
    public static bool Rune1Inserted, Rune2Inserted, Rune3Inserted, Rune4Inserted, Rune5Inserted, Rune6Inserted, Rune7Inserted, Rune8Inserted;
    public static int CollectedRunesCount = 0;
    public static int CarriedRunesCount = 0;
    public static List<int> CarriedRunes = new List<int>();
    public static List<int> InsertedRunes = new List<int>();

    public static void ResetStats()
    {
        Rune1Collected = false;
        Rune2Collected = false;
        Rune3Collected = false;
        Rune4Collected = false;
        Rune5Collected = false;
        Rune6Collected = false;
        Rune7Collected = false;
        Rune8Collected = false;

        CollectedRunesCount = 0;

        Rune1Inserted = false;
        Rune2Inserted = false;
        Rune3Inserted = false;
        Rune4Inserted = false;
        Rune5Inserted = false;
        Rune6Inserted = false;
        Rune7Inserted = false;
        Rune8Inserted = false;

        CarriedRunesCount = 0;

        CarriedRunes.Clear();
        InsertedRunes.Clear();
    }
}
