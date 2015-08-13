using UnityEngine;
using System.Collections;

public class MemoryGame : MonoBehaviour
{
    GenerateGrid generateGrid;
    Camera cameraComponent;

    void Start()
    {
        generateGrid = GameObject.Find("GenerateGrid").GetComponent<GenerateGrid>();
        cameraComponent = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray clickRay = cameraComponent.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHitInfo;
            
            if (Physics.Raycast(clickRay, out rayHitInfo))
            {
                foreach (Transform plane in generateGrid.planes)
                {
                    if (rayHitInfo.collider.gameObject.transform == plane)
                    {
                        plane.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
                    }
                }
            }
        }
    }
}

