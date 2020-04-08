using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    Transform cameraTransform;
    Transform targetTransform;

    Vector3 localRotation;
    float cameraDistance = 10f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;
    public float MinZoom = 1.5f;
    public float MaxZoom = 100f;

    public bool CameraDisabled = true;

    void Start()
    {
        this.cameraTransform = this.transform;
        this.targetTransform = this.transform.parent;
        cameraDistance = -cameraTransform.localPosition.z;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CameraDisabled = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            CameraDisabled = true;
        }

        if(!CameraDisabled)
        {
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                localRotation.y = Mathf.Clamp(localRotation.y, 0f, 90f);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;
            scrollAmount *= this.cameraDistance * .3f;
            cameraDistance -= scrollAmount;
            cameraDistance = Mathf.Clamp(cameraDistance, MinZoom, MaxZoom);
        }

        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        targetTransform.rotation = Quaternion.Lerp(targetTransform.rotation, QT, Time.deltaTime * OrbitDampening);

        if (cameraTransform.localPosition.z != -cameraDistance)
        {
            cameraTransform.localPosition = new Vector3(
                0f,
                0f,
                Mathf.Lerp(cameraTransform.localPosition.z, -cameraDistance, Time.deltaTime * ScrollDampening));
        }
    }
}
