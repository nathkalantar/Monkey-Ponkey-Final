using UnityEngine;

public class FollowCamara : MonoBehaviour
{
    [Header("Objeto a Seguir")]
    // This is the object that the camera will follow
    public Transform objetivo;

    //Bound camera to limits
    public bool limitar = false;
    public float izquierda = -5f;
    public float derecha = 5f;
    public float abajo = -5f;
    public float arriba = 5f;

    private Vector3 lerpedPosition;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    // FixedUpdate is called every frame, when the physics are calculated
    void FixedUpdate()
    {
        if (objetivo != null)
        {
            // Find the right position between the camera and the object
            lerpedPosition = Vector3.Lerp(transform.position, objetivo.position, Time.deltaTime * 10f);
            lerpedPosition.z = -10f;
        }
    }



    // LateUpdate is called after all other objects have moved
    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Move the camera in the position found previously
            transform.position = lerpedPosition;

            // Bounds the camera to the limits (if enabled)
            if (limitar)
            {
                Vector3 bottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);
                Vector3 topRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight));
                Vector2 screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

                Vector3 boundPosition = transform.position;
                if (boundPosition.x > derecha - (screenSize.x / 2f))
                {
                    boundPosition.x = derecha - (screenSize.x / 2f);
                }
                if (boundPosition.x < izquierda + (screenSize.x / 2f))
                {
                    boundPosition.x = izquierda + (screenSize.x / 2f);
                }

                if (boundPosition.y > arriba - (screenSize.y / 2f))
                {
                    boundPosition.y = arriba - (screenSize.y / 2f);
                }
                if (boundPosition.y < abajo + (screenSize.y / 2f))
                {
                    boundPosition.y = abajo + (screenSize.y / 2f);
                }
                transform.position = boundPosition;
            }
        }
    }
}
