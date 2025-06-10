using UnityEngine;
using static UnityEditor.PlayerSettings;

public class KeyAnimationScript : MonoBehaviour
{
    [Range(0, 1000)] public float RotationSpeed = 1f;
    [Range(0, 1)] public float FlySpeed = 1f;
    public float FlyHeight = 1f;
    public Transform Key;
    [Range(0, 1)]public float Delay;

    private Vector3 StartPos;
    private Vector3 EndPos;
    private bool ReachedUp = false;

    void Start()
    {

        StartPos = Key.transform.position;
        EndPos = new Vector3(StartPos.x, StartPos.y + FlyHeight, StartPos.z);

    }


    void FixedUpdate()
    {
        Key.transform.Rotate(0, RotationSpeed * Time.deltaTime, 0, Space.World);

        if (!ReachedUp)
        {
            Key.transform.position = Vector3.Lerp(Key.transform.position,EndPos, Time.deltaTime*FlySpeed);
            if (Key.transform.position.y >= EndPos.y - Delay)
            {
                ReachedUp = true;
            }
        }
        else if (ReachedUp) 
        {
            Key.transform.position = Vector3.Lerp(Key.transform.position, StartPos, Time.deltaTime * FlySpeed);
            if (Key.transform.position.y <= StartPos.y + Delay)
            {
                ReachedUp = false;
            }
        }
    }
}