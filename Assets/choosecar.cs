using UnityEngine;
using UnityEngine.UI; // Include the UI namespace
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class DoorOpener : MonoBehaviour
{
    // Reference to the Animator component of the door
    private List<RCC_CarControllerV3> _spawnedVehicles = new List<RCC_CarControllerV3>();
    public int index;
    // Reference to the UI Button (assign this in the Inspector)
    public Button playButton;
    bool inside = false;
    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the door GameObject

 

        // Check if the openButton is assigned and disable it at the start
        if (playButton != null)
        {
            playButton.gameObject.SetActive(false);
            playButton.onClick.AddListener(play); // Add click listener to the button
        }
        else
        {
            Debug.LogError("Open Button is not assigned. Please assign the button in the Inspector.");
        }
    }

    // This method is called when another collider enters the trigger collider attached to the door
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            inside = true;

            playButton.gameObject.SetActive(true);
            
        }
    }

    // This method is called when another collider exits the trigger collider attached to the door
    private void OnTriggerExit(Collider other)
    {
        // Check if the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            inside = false;
            playButton.gameObject.SetActive(false);
            
        }
    }

    // Method to open the door
    private void play()
    {   if (inside)
        {
            carManager.instance.register(index);
            SceneManager.LoadScene(2);
        }
    }
}
