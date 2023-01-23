using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject targetObject; //takip i�in i�erisine at�lan eleman�n nesnesi olu�uyor
    public Vector3 cameraOffset; //kameran�n uzakl�g� i�in gerekli
    public Vector3 targetedPosition; //smooth takio i�in gerekli
    private Vector3 velocity = Vector3.zero; //0 olan bir vekt�r
    public float smoothTime = 0.1F; //smooth katsay�s�
    // Update is called once per frame
    void Update()
    {
        targetedPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
    }

}
