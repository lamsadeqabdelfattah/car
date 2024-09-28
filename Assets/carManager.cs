using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carManager : MonoBehaviour
{
    private List<RCC_CarControllerV3> _spawnedVehicles = new List<RCC_CarControllerV3>();
    public Transform[] spawnPosition;
    public static carManager instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else if (instance != this)
            Destroy(gameObject);


        for (int i = 0; i < RCC_DemoVehicles.Instance.vehicles.Length; i++)
        {

            // Spawning the vehicle with no controllable, no player, and engine off. We don't want to let player control the vehicle while in selection menu.
            RCC_CarControllerV3 spawnedVehicle = RCC.SpawnRCC(RCC_DemoVehicles.Instance.vehicles[i], spawnPosition[i].position, spawnPosition[i].rotation, false, false, false);

            // Disabling spawned vehicle. 
            spawnedVehicle.gameObject.SetActive(false);

            // Adding and storing it in _spawnedVehicles list.
            _spawnedVehicles.Add(spawnedVehicle);

        }

        SpawnVehicle();
    }
    public void register(int index)
    {
        print(index);
        // Registers the vehicle as player vehicle.
        RCC.RegisterPlayerVehicle(_spawnedVehicles[index]);

        // Starts engine and enabling controllable when selected.
        _spawnedVehicles[index].StartEngine();
        _spawnedVehicles[index].SetCanControl(true);

        // Save the selected vehicle for instantianting it on next scene.
        PlayerPrefs.SetInt("SelectedRCCVehicle", index);
        RCC_SceneManager.Instance.activePlayerVehicle = _spawnedVehicles[index];

    }
    public void SpawnVehicle()
    {

        // Disabling all vehicles.
        for (int i = 0; i < _spawnedVehicles.Count; i++)
            _spawnedVehicles[i].gameObject.SetActive(true);
         

        //		RCC_SceneManager.Instance.RegisterPlayer (_spawnedVehicles [selectedIndex], false, false);
      //  RCC_SceneManager.Instance.activePlayerVehicle = _spawnedVehicles[i];

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
