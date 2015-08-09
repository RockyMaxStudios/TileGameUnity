using UnityEngine;
using System.Collections;

public class GenerateGrid : MonoBehaviour
{
    public Transform sceneCamera;
    private Camera cameraComponent;
    public int numberOfHorizontalRectangles = 5;
    public int numberOfVerticalRectangles = 5;
    public float spacingBetweenRectangles = 0.05f;
    private float screenWidthInWorldUnits;
    private float screenHeightInWorldUnits;    

    void Start()
    {
        cameraComponent = sceneCamera.GetComponent<Camera>();

        screenHeightInWorldUnits = cameraComponent.orthographicSize * 2;
        screenWidthInWorldUnits = screenHeightInWorldUnits * cameraComponent.aspect;

        for (int i = 0; i < numberOfHorizontalRectangles; i++)
            for (int j = 0; j < numberOfVerticalRectangles; j++)
            {
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                plane.transform.rotation = Quaternion.Euler(-90, 0, 0);

                float horizontalSpacing = cameraComponent.pixelWidth / numberOfHorizontalRectangles;
                float verticalSpacing = cameraComponent.pixelHeight / numberOfVerticalRectangles;
                plane.transform.position = cameraComponent.ScreenToWorldPoint(new Vector3(horizontalSpacing * 0.5f + horizontalSpacing * i, 
                                                                                          verticalSpacing * 0.5f + verticalSpacing * j, 
                                                                                          1));

                plane.transform.localScale = new Vector3(1 * cameraComponent.aspect / numberOfHorizontalRectangles - spacingBetweenRectangles/2,
                                                         1, 
                                                         1f / numberOfVerticalRectangles - spacingBetweenRectangles/2);
            }
    }
}
