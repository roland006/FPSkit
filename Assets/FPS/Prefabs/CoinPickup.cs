using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public GameObject VFX_PickupSparkles;

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            int current = int.Parse(uiText.text);
            uiText.text = (current + 1).ToString();
            Instantiate(VFX_PickupSparkles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}