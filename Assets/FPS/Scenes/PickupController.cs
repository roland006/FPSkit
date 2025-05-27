using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickableItem
{
    void OnPickUp();
    void OnDrop();
    void Enable();
    void Disable();
}

public interface IInstantPickable
{
    void OnInstantPickUp();
}

public class PickupController : MonoBehaviour
{
    public List<IPickableItem> inventory = new List<IPickableItem>();
    public Transform itemContainer;
    public Transform player;
    public float pickUpRange;
    private int currentItemIndex = -1;

    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(player.position, pickUpRange);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Pickable"))
            {
                IPickableItem pickable = hit.GetComponent<IPickableItem>();
                if (pickable != null)
                {
                    PickUp(pickable);
                    continue;
                }

                IInstantPickable instant = hit.GetComponent<IInstantPickable>();
                if (instant != null)
                {
                    instant.OnInstantPickUp();
                    Destroy(hit.gameObject); 
                }
            }
        }

        for (int i = 1; i <= inventory.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i)) // 1-9 keys
            {
                SwitchItem(i - 1);
            }
        }
    }

    private void PickUp(IPickableItem newItem)
    {
        if (newItem != null && !inventory.Contains(newItem))
        {
            inventory.Add(newItem);
            newItem.OnPickUp();
            newItem.Disable();
        }

        if (inventory.Count == 1)
        {
            SwitchItem(0);
        }
    }

    private void SwitchItem(int index)
    {
        if (index >= 0 && index < inventory.Count && index != currentItemIndex)
        {
            if (currentItemIndex != -1)
            {
                inventory[currentItemIndex].Disable();
            }

            currentItemIndex = index;
            inventory[currentItemIndex].Enable();
        }
    }
}
