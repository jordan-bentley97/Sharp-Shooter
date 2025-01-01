using UnityEngine;

public class Music : MonoBehaviour {

    AudioSource[] audioSources;

    void Start() {
        audioSources = GetComponents<AudioSource>();
        PlayRandomMusic();
    }

    void PlayRandomMusic() {
        int randomIndex = Random.Range(0, audioSources.Length);
        audioSources[randomIndex].Play();
    }

}
