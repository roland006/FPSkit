using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    bool musicPlayed;
    public void PlayMusic(AudioClip clip)
    {
        if (musicPlayed)
        {
            StopMusic();
        }
       
        musicPlayed = true;
        AudioSource.clip = clip;
        AudioSource.loop = true;
        AudioSource.Play();
    }
  public   void StopMusic()
    {
        if (musicPlayed)
        {
            musicPlayed = false;

            if (AudioSource.isPlaying)
                AudioSource.Stop();
            
        }

    }
    

    
}
