using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject[] runeObjects;
    public GameObject trailsObject;
    public GameObject particlesObject;
    public GameObject InsertingCanvas;

    private bool playerInPortalTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var rune in runeObjects)
        {
            rune.SetActive(false);
        }
        trailsObject.SetActive(false);
        particlesObject.SetActive(false);
        InsertingCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<runeObjects.Length; i++)
        {
            if (GameStats.InsertedRunes.Contains(i))
            {
                runeObjects[i].SetActive(true);
            }
            else
            {
                runeObjects[i].SetActive(false);
            }
        }

        //if (GameStats.Rune1Inserted) runeObjects[0].SetActive(true);
        //else runeObjects[0].SetActive(false);
        //if (GameStats.Rune2Inserted) runeObjects[1].SetActive(true);
        //else runeObjects[1].SetActive(false);
        //if (GameStats.Rune3Inserted) runeObjects[2].SetActive(true);
        //else runeObjects[2].SetActive(false);
        //if (GameStats.Rune4Inserted) runeObjects[3].SetActive(true);
        //else runeObjects[3].SetActive(false);
        //if (GameStats.Rune5Inserted) runeObjects[4].SetActive(true);
        //else runeObjects[4].SetActive(false);
        //if (GameStats.Rune6Inserted) runeObjects[5].SetActive(true);
        //else runeObjects[5].SetActive(false);
        //if (GameStats.Rune7Inserted) runeObjects[6].SetActive(true);
        //else runeObjects[6].SetActive(false);
        //if (GameStats.Rune8Inserted) runeObjects[7].SetActive(true);
        //else runeObjects[7].SetActive(false);

        if (playerInPortalTrigger)
        {
            if (Input.GetButtonDown("Jump"))
            {
                InsertRunes();
            }
        }
    }

    private void InsertRunes()
    {
        foreach(var carriedRune in GameStats.CarriedRunes)
        {
            Debug.Log(carriedRune);

            // TODO: add some animation between the runes

            GameStats.InsertedRunes.Add(carriedRune);
        }
        GameStats.CarriedRunes.Clear();
        GameStats.CarriedRunesCount = 0;

        if (GameStats.InsertedRunes.Count == 8)
        {
            // ALL RUNES INSERTED! OPEN THE PORTAL
            StartCoroutine(PortalOpeningSequence());
        }
    }

    private IEnumerator PortalOpeningSequence()
    {
        InsertingCanvas.SetActive(false);

        yield return new WaitForSeconds(1f);

        particlesObject.SetActive(true);
        trailsObject.SetActive(true);
    }

    public void PlayerEnteredPortal()
    {
        playerInPortalTrigger = true;
        if (GameStats.CarriedRunesCount > 0)
        {
            InsertingCanvas.SetActive(true);
        }
        else
        {
            InsertingCanvas.SetActive(false);
        }
    }

    public void PlayerLeftPortal()
    {
        InsertingCanvas.SetActive(false);

        playerInPortalTrigger = false;
    }
}
