using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraMovement : MonoBehaviour
{
    public Transform character;

    [SerializeField] private Camera camera;

    private float playerStartingPosition;

    [SerializeField] private float distanceFromPlayer = -10;
    [SerializeField] private float cameraflow = 0.9f;


    [SerializeField] private float zoomSize = 4;
    private float startedZoomSize;
    private bool IsZoomedIn = false;

    [SerializeField] private float shakeLength = 100;
    [SerializeField] private float shakeDistance = 0.2f;

    private void Awake()
    {

        camera = GetComponent<Camera>();
        if(!character)character = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        startedZoomSize = camera.orthographicSize;
        playerStartingPosition = character.position.x;
    }
    void Update()
    {
        #region NoConstraints
        /*
           Vector2 startPosition = transform.position;
            Vector2 endPosition = character.position;

            Vector2 nextPosition = Vector2.Lerp(startPosition, endPosition, cameraflow);
            transform.position = new Vector3(nextPosition.x, nextPosition.y, distanceFromPlayer);
        */
        #endregion


        #region VerticalConstraints
        Vector2 startPosition = transform.position;
        Vector2 endPosition = character.position;

        Vector2 nextPosition = Vector2.Lerp(startPosition, endPosition, cameraflow);
        transform.position = new Vector3(playerStartingPosition, nextPosition.y, distanceFromPlayer);

        #endregion

        /*if (Input.GetKeyDown(KeyCode.Mouse0)) Shake();
        if (Input.GetKeyDown(KeyCode.Mouse1)) CameraZoom();*/
        // cia testavimui funciju kaip norit taip naudokit

    }
    

    private void CameraZoom()
    {
        if (IsZoomedIn)
        {
            camera.orthographicSize = startedZoomSize;
            IsZoomedIn = false;

        }
        else
        {
            camera.orthographicSize = zoomSize;
            IsZoomedIn = true;

        }

    }

    public void Shake(int frames = 200)
    {
        StartCoroutine(CameraShake(frames));
    }

    public IEnumerator CameraShake(float shakeLength)
    {
        
        for (int i = 0; i < shakeLength; i++)
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-shakeDistance, shakeDistance), transform.position.y + Random.Range(-shakeDistance, shakeDistance),distanceFromPlayer);
            yield return null;
        }

    }
}
