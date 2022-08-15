using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupItems
{
    Rune1,
    Rune2,
    Rune3,
    Rune4,
    Rune5,
    Rune6,
    Rune7,
    Rune8,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }
        _instance = this;

        GameStats.ResetStats();
    }

    public void PickupItem(PickupItems pickupItem)
    {
        if (pickupItem == PickupItems.Rune1) GameStats.Rune1Collected = true;
        if (pickupItem == PickupItems.Rune2) GameStats.Rune2Collected = true;
        if (pickupItem == PickupItems.Rune3) GameStats.Rune3Collected = true;
        if (pickupItem == PickupItems.Rune4) GameStats.Rune4Collected = true;
        if (pickupItem == PickupItems.Rune5) GameStats.Rune5Collected = true;
        if (pickupItem == PickupItems.Rune6) GameStats.Rune6Collected = true;
        if (pickupItem == PickupItems.Rune7) GameStats.Rune7Collected = true;
        if (pickupItem == PickupItems.Rune8) GameStats.Rune8Collected = true;
        GameStats.CollectedRunesCount++;
        GameStats.CarriedRunesCount++;
        GameStats.CarriedRunes.Add((int)pickupItem);
    }
}
