using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[RequireComponent(typeof(Collider))]
public class TimelineTriggerZone : MonoBehaviour
{
    public enum TriggerType
    {
        Once, Everytime,
    }

    [Tooltip("This is the gameobject which will trigger the director to play.  For example, the player.")]
    public GameObject triggeringGameObject;
    public PlayableDirector director;
    public TriggerType triggerType;
    public UnityEvent OnDirectorPlay;
    public UnityEvent OnDirectorFinish;
    public Camera PlayerCamera;
    public Camera CutsceneCamera;

    protected bool m_AlreadyTriggered;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != triggeringGameObject)
            return;

        if (triggerType == TriggerType.Once && m_AlreadyTriggered)
            return;

        PlayerCamera.enabled = false;
        CutsceneCamera.enabled = true;
        OnDirectorPlay.Invoke();
        director.Play();
        m_AlreadyTriggered = true;
        Invoke("FinishInvoke", (float)director.duration);
        director.stopped += checkFinish;
        
    }

    void checkFinish(PlayableDirector director)
    {
        PlayerCamera.enabled = true;
        CutsceneCamera.enabled = false;
    }

    void FinishInvoke()
    {
        OnDirectorFinish.Invoke();
    }
}
