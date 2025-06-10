using UnityEngine;
using TMPro;
using UnityEditor;
public class SecretScript : MonoBehaviour
{
    public bool IsFound;
    static int FoundOverall;
    public AudioClip CollectSound;
    public TextMeshProUGUI SecretText;
    public void OnTriggerEnter(Collider other)
    {
        if (!IsFound)
        {

            FoundOverall += 1;
            AssetDatabase.Refresh();
            SecretText.text = "SECRETS FOUND " + FoundOverall.ToString() + "/3";
            AudioSource.PlayClipAtPoint(CollectSound,transform.position,0.5f);
            transform.position = new Vector3(100, 100, 100);
            
        }
    }
}
