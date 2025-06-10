using UnityEngine;

public class PickUpSoundScript : MonoBehaviour
{
    [Range(0,1)]public float Volume;
    public AudioClip PickupSound;
    public int PickupNum;
    private AudioSource audioSource;


    private void OnTriggerEnter(Collider other)
    {

        //Inventory inventory = other.gameObject.GetComponent<Inventory>();
        //inventory.AddItem();

        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(PickupSound, transform.position, Volume);

    }
}