using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicBoundaries : MonoBehaviour 

    //THIS SCRIPT ONLY WORKS ON ORTHOGRAPHIC CAMERA VIEW
    //Use perspective camera script if you want to switch views, bookmarks

{
    public Camera MainCamera;
    private Rect screenBounds;

    //only for keeping whole object in screen, cut if the "half" behavior is preferred
    private float objectWidth;
    private float objectHeight;


    // Start is called before the first frame update
    void Start()
    {
        DefineCameraBoundaries();

        DefineObjectBoundaries();
    }


    void LateUpdate()
    {
        KeepObjectInBoundaries();

        MovingCameraBoundaryUpdate();

    }


    private void DefineCameraBoundaries()
    {
        float cameraHeight = MainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * MainCamera.aspect;
        Vector2 cameraSize = new Vector2(cameraWidth, cameraHeight);
        Vector2 cameraCenterPosition = MainCamera.transform.position;
        Vector2 cameraBottomLeftPosition = cameraCenterPosition - (cameraSize / 2);
        screenBounds = new Rect(cameraBottomLeftPosition, cameraSize);
    }

    private void DefineObjectBoundaries()
    {
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }


    private void KeepObjectInBoundaries()
    {
        //Keeps attached object inside screen bounds
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x + screenBounds.width - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y + screenBounds.height - objectHeight);

        //other variant
        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, screenBounds.x + screenBounds.width);
        //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, screenBounds.y + screenBounds.height);

        transform.position = viewPos;

    }

    private void MovingCameraBoundaryUpdate()
    {
        //Moves bounds with player if the camera is supposed to move
        //even plays nice with CameraMovement smoothing script :)
        screenBounds.position = (Vector2)MainCamera.transform.position - (screenBounds.size / 2);
    }

}
