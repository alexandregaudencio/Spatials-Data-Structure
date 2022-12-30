using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private int worldSizeSimulation;
    [SerializeField] private GameObject sphere;
    [SerializeField] private int count;
    [SerializeField] private Color worldWireColor;
    [SerializeField] private List<ObjectController> sphereControllers;
    public int maxBoundary => worldSizeSimulation / 2;
    public static SimulationManager instance;

    private void Start()
    {
        instance = this;
        GenerateObjects();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = worldWireColor;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one*worldSizeSimulation);
    }

    private void GenerateObjects()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject sphere =  Instantiate(this.sphere);
            sphere.transform.position = SpawnPosition();
            sphereControllers.Add(sphere.GetComponent<ObjectController>());
        }
    }


    private Vector3 SpawnPosition()
    {
        return new Vector3(Random.Range(-maxBoundary + 1, maxBoundary - 1), 
            Random.Range(-maxBoundary + 1, maxBoundary - 1), 
            Random.Range(-maxBoundary + 1, maxBoundary - 1));
    }

}