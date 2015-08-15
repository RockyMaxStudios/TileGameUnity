using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public Transform sceneCamera;
    public Transform planePrefab;
    private Camera cameraComponent;
    public int numberOfHorizontalRectangles = 5;
    public int numberOfVerticalRectangles = 5;
    public float spacingBetweenRectangles = 0.05f;
    private float screenWidthInWorldUnits;
    private float screenHeightInWorldUnits;
    [HideInInspector]
    public List<Transform> planes = new List<Transform>();

    void Start()
    {
        GeneratePlanes();
    }

    private void GeneratePlanes()
    {
        cameraComponent = sceneCamera.GetComponent<Camera>();

        screenHeightInWorldUnits = cameraComponent.orthographicSize * 2;
        screenWidthInWorldUnits = screenHeightInWorldUnits * cameraComponent.aspect;

        for (int i = 0; i < numberOfHorizontalRectangles; i++)
            for (int j = 0; j < numberOfVerticalRectangles; j++)
            {
                Transform plane = GameObject.Instantiate(planePrefab);
                plane.GetComponent<Renderer>().material.color = new Color(0, 0, 0);

                //Set rotation
                plane.rotation = Quaternion.Euler(-90, 0, 0);

                //Set position
                float horizontalSpacing = cameraComponent.pixelWidth / numberOfHorizontalRectangles;
                float verticalSpacing = cameraComponent.pixelHeight / numberOfVerticalRectangles;
                plane.position = cameraComponent.ScreenToWorldPoint(new Vector3(horizontalSpacing * 0.5f + horizontalSpacing * i,
                                                                                          verticalSpacing * 0.5f + verticalSpacing * j,
                                                                                          1));

                //Set scale
                plane.localScale = new Vector3(1 * cameraComponent.aspect / numberOfHorizontalRectangles - spacingBetweenRectangles / 2,
                                                         1,
                                                         1f / numberOfVerticalRectangles - spacingBetweenRectangles / 2);

                planes.Add(plane);
            }
    }
}

