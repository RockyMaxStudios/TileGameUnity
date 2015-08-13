using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryGame : MonoBehaviour
{
    Grid grid;
    Camera cameraComponent;

    int sequenceLength = 3;
    List<Transform> generatedSequence = new List<Transform>();
    
    void Start()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        cameraComponent = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        PlaySequence();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray clickRay = cameraComponent.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHitInfo;
            
            if (Physics.Raycast(clickRay, out rayHitInfo))
            {
                foreach (Transform plane in grid.planes)
                {
                    if (rayHitInfo.collider.gameObject.transform == plane)
                    {
                        //plane.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
                        plane.GetComponent<PlaneScript>().Click();
                    }
                }
            }
        }
    }

    private void PlaySequence()
    {

    }

    private void GenerateSequence()
    {
        generatedSequence.Clear();

        for (int i = 0; i < sequenceLength; i++)
            generatedSequence.Add(grid.planes[Random.Range(0, grid.planes.Count)]);
    }
}

