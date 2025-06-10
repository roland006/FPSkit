using Unity.Hierarchy;
using UnityEngine;
using TMPro;


public class DoorLockScript : MonoBehaviour
{


    public Inventory inventory;
    [Range(1, 7)] public int CanBeOpenedWith;
    public TextMeshPro text;
    [HideInInspector]
    public string beb;



    void Start()
    {
       text = GetComponentInChildren<TextMeshPro>();
        beb = CanBeOpenedWith.ToString();
        text.text = beb;
    }

    public void OpenTry()
    {

        switch (CanBeOpenedWith)
        {

            case 1:

                if (inventory.Key1)
                {
                    Destroy(gameObject);
                } 

                break;

            case 2:

                if (inventory.Key2)
                {
                    Destroy(gameObject);
                }

                break;

            case 3:

                if (inventory.Key3)
                {
                    Destroy(gameObject);
                }

                break;

            case 4:

                if (inventory.Key41 && inventory.Key42)
                {
                    Destroy(gameObject);
                }

                break;

            //case 5:

                //if (inventory.Key42)
                {
                    //Destroy(gameObject);
                }

                //break;

            case 6:

                if (inventory.Crowbar)
                {
                    Destroy(gameObject);
                }

                break;

            case 7:

                if (inventory.Boltcutter)
                {
                    Destroy(gameObject);
                }

                break;

            default:

                Debug.Log("Invalid Item");
                
                break;

        }

    }

}