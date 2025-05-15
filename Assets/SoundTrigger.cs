using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Audio source for jetpack sfx")]
    public AudioSource AudioSource;

    [Header("Audio")]
    [Tooltip("Sound played when using the jetpack")]
    public AudioClip AudioClip;
    public bool IsMusic;
    public bool IsStop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void OnTriggerEnter(Collider other)
    {
        
        MusicPlayer musicPlayer = other.GetComponent<MusicPlayer>();
        if (IsMusic)
        {
            if (IsStop)
            {
                musicPlayer.StopMusic();
            }
            else
                musicPlayer.PlayMusic(AudioClip);
        }
        else
        {
            AudioSource.PlayOneShot(AudioClip);
        }
    }
}
