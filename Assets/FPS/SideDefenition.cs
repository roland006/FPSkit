using UnityEngine;

public class SideDefenition : MonoBehaviour
{
    public bool IsRightSide;
    public GameObject Hint;
    public void TryOpen()
    {
        if (IsRightSide)
        {
            Destroy(gameObject);
        }

    }

}
