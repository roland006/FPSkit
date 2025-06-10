using Unity.FPS.Gameplay;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public PickUpSoundScript Pickup;
    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Pickup")
        {

            //Debug.Log("YOU PICKED UP SOMETHING");
            Pickup = other.GetComponent<PickUpSoundScript>();
            inventory.ItemNum = Pickup.PickupNum;
            inventory.AddItem();

        }  
     }
}