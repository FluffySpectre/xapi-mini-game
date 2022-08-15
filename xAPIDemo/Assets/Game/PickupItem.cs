using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public PickupItems ItemType;
    public GameObject DestroyReplacement;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        GameManager.Instance.PickupItem(ItemType);

        Destroy(transform.parent.gameObject);

        if (DestroyReplacement)
        {
            GameObject replacement = Instantiate(DestroyReplacement, transform.position, transform.rotation);
            Destroy(replacement, 5f);
        }
    }
}
