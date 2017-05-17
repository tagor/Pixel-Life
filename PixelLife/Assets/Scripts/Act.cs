using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Act : MonoBehaviour
{
    public Player player;
    public Camera camera;

    [Tooltip("Effects the Zoom, lower value is more zoom")]
    public float fieldOfView;
    private float oldFieldOfView;

    public Vector2 playerPosition;
    private Vector2 oldPlayerPosition;

    public Vector3 zoomPosition;
    private Vector3 oldCamPosition;

    private bool curtainsOpen;

    public void PrepareAndOpenCurtains()
    {    
        DisableMovement();
        PositionCharacters();
        PositionCamera();
        ZoomIn();

        curtainsOpen = true;
    }

 
    private void DisableMovement()
    {
        player.movementEnabled = false;
    }
    private void PositionCharacters()
    {
        oldPlayerPosition = player.transform.position;
        player.transform.position = playerPosition;
    }   
    private void PositionCamera()
    {
        oldCamPosition = camera.transform.position;
        camera.transform.position = zoomPosition;
    }
    private void ZoomIn()
    {
        oldFieldOfView = camera.fieldOfView;
        camera.fieldOfView = fieldOfView;
    }

    public void CloseCurtains()
    {
        EnableMovement();
        FreeCameraPosition();
        FreeCharacterPositions();
        ZoomOut();

        curtainsOpen = false;
    }

    private void EnableMovement()
    {
        player.movementEnabled = true;
    }
    private void FreeCameraPosition()
    {
        camera.transform.position = oldCamPosition;
    }
    private void FreeCharacterPositions()
    {
        player.transform.position = oldPlayerPosition;
    }
    private void ZoomOut()
    {
        camera.transform.SetParent(null);
        camera.fieldOfView = oldFieldOfView;
    }

}
