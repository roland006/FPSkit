using System.Collections;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{

    public GameObject Player;
    public GameObject Cam1, Cam2, Cam3,HUD;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Cam1.gameObject.SetActive(true);
        Player.SetActive(false);
        HUD.gameObject.SetActive(false);
        StartCoroutine(FinishCutScene());
    }

    IEnumerator FinishCutScene()
    {
        yield return new WaitForSeconds(5);
        Cam1.SetActive(false);
        Cam2.SetActive(true);
        yield return new WaitForSeconds(3);
        Cam2.SetActive(false);
        Cam3.SetActive(true);
        yield return new WaitForSeconds(3);
        Cam3.SetActive(false);
        Player.SetActive(true);
        HUD.gameObject.SetActive(true);
    }

}
