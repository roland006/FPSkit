using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class CutScene : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Transform cutSceneCamera;
    [SerializeField] private List<Transform> points;
    [SerializeField] private UnityEvent onStart;
    [SerializeField] private UnityEvent onFinish;

    private IEnumerator Start()
    {
        mainCamera.SetActive(false);
        cutSceneCamera.gameObject.SetActive(true);
        onStart.Invoke();

        foreach (Transform point in points)
            yield return StartCoroutine(GoToPoint(point));

        onFinish.Invoke();
        cutSceneCamera.gameObject.SetActive(false);
        mainCamera.SetActive(true);
    }

    private IEnumerator GoToPoint(Transform point)
	{
        Vector3 startPosition = cutSceneCamera.position;
        Quaternion startRotation = cutSceneCamera.rotation;

        for (float i = 0; i < 1f; i += Time.deltaTime)
		{
            cutSceneCamera.position = Vector3.Lerp(startPosition, point.position, i);
            cutSceneCamera.rotation = Quaternion.Lerp(startRotation, point.rotation, i);
            yield return null;
		}

        yield return new WaitForSeconds(0.25f);
	}

#if UNITY_EDITOR
	public void SpawnPoint()
	{
        GameObject gobj = new GameObject();
        gobj.name = $"Point {points.Count + 1}";

        Transform p = gobj.transform;
        p.position = SceneView.lastActiveSceneView.camera.transform.position;
        p.rotation = SceneView.lastActiveSceneView.camera.transform.rotation;
        p.SetParent(this.transform);

        points.Add(p);
    }

    public void UpdatePoints()
    {
        points.Clear();

		foreach (Transform t in transform)
		{
            points.Add(t);
		}
    }

    public void DeleteAllPoints()
    {
        UpdatePoints();

        foreach (Transform t in points)
        {
            DestroyImmediate(t.gameObject);
        }

        points.Clear();
    }
#endif
}