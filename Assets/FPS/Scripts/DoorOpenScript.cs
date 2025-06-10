using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOpenScript : MonoBehaviour
{
    public float Distance;
    public GameObject Hint;
    public GameObject Hint2;
    public DoorLockScript Lock;
    public SideDefenition Side;


    public void Update()
    {
        Ray Reach = new Ray(transform.position, transform.forward);
        RaycastHit Reached;


        if (Physics.Raycast(Reach, out Reached, Distance))
        {

            if (Reached.collider.gameObject.tag == "Door")
            {

                Hint.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {

                    Lock = Reached.collider.gameObject.GetComponent<DoorLockScript>();
                    Lock.OpenTry();

                }

            }
            else
            {
                Hint.SetActive(false);
            }

            if (Reached.collider.gameObject.tag == "OneWayDoor")
            {
                Side = Reached.collider.gameObject.GetComponent<SideDefenition>();
                if (Side.IsRightSide)
                {
                    Hint2.SetActive(false);
                    Hint.SetActive(true );
                }
                else
                {
                    Hint2.SetActive(true);
                    Hint.SetActive(false);
                }
                //Hint2.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Side = Reached.collider.gameObject.GetComponent<SideDefenition>();
                    Side.TryOpen();
                }
            }
            else
            {
                Hint2.SetActive(false);
            }

        }
        else
        {
            Hint.SetActive(false);
            Hint2.SetActive(false);
        }

    }

}
