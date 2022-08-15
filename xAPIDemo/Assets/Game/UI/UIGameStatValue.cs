using UnityEngine;
using TMPro;

public class UIGameStatValue : MonoBehaviour
{
    public enum GameStatValue
    {
        CollectedBlues,
    }

    public TMP_Text TextComponent;
    public GameStatValue ValueToDisplay;
    public string Format = "{0}x";

    // Update is called once per frame
    void Update()
    {
        if (ValueToDisplay == GameStatValue.CollectedBlues)
        {
            TextComponent.text = string.Format(Format, GameStats.CollectedRunesCount);
        }
    }
}
