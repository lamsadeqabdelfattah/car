using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips; // Array to hold the audio clips
    private AudioSource audioSource;
    private List<AudioClip> remainingClips; // List to keep track of remaining clips to be played
    
    private static AudioManager instance = null;

    public static AudioManager Instance

    {
        get { return instance; }
    }

    private void Awake()
    {
        // If an instance of AudioManager already exists, destroy the new one
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set the instance to this instance and make sure it persists across scenes
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        // Add an AudioSource component if not already present
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Initialize the remainingClips list and start playing audio
        remainingClips = new List<AudioClip>(audioClips);
        StartCoroutine(PlayRandomAudio());
    }

    private void Update()

    {
        audioSource.volume= PlayerPrefs.GetFloat("sound", 0.5f);
    }

    private IEnumerator PlayRandomAudio()
    {
        while (true)
        {
            // If no remaining clips, refill the list with all audio clips
            if (remainingClips.Count == 0)
            {
                remainingClips = new List<AudioClip>(audioClips);
            }

            // Randomly select an audio clip from the remaining clips
            int randomIndex = Random.Range(0, remainingClips.Count);
            AudioClip selectedClip = remainingClips[randomIndex];
            remainingClips.RemoveAt(randomIndex); // Remove the selected clip from the list

            // Set the selected clip to the AudioSource and play it
            audioSource.clip = selectedClip;
            audioSource.Play();

            // Wait until the current audio clip finishes playing
            yield return new WaitForSeconds(selectedClip.length);
        }
    }
}
