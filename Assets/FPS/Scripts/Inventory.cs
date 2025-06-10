using UnityEngine;

public class Inventory : MonoBehaviour
{

    //[HideInInspector]
    public int ItemNum;
    public bool Key1, Key2, Key3, Key41, Key42, Crowbar, Boltcutter;
    public Transform Player;
    //public DoorLockScript NeededToOpen;
    //public PickUpScript PickupName;

    public void AddItem()
    {

        //Debug.Log("Зарос получен");
        switch (ItemNum)
        {

            case 1:
                Key1 = true; Debug.Log("Получен ключ 1");
                break;
            case 2:
                Key2 = true; Debug.Log("Получен ключ 2");
                break;
            case 3:
                Key3 = true; Debug.Log("Получен ключ 3");
                break;
            case 4:
                Key41 = true; Debug.Log("Получен ключ 4.1");
                break;
            case 5:
                Key42 = true; Debug.Log("Получен ключ 4.2");
                break;
            case 6:
                Crowbar = true; Debug.Log("Получена монтировка");
                break;
            case 7:
                Boltcutter = true; Debug.Log("Получен болторез");
                break;
            default:
                Debug.Log("Хуйня, переделывай");
                break;

        }

    }
}