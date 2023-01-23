using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject targetObject; //takip için içerisine atýlan elemanýn nesnesi oluþuyor
    public Vector3 cameraOffset; //kameranýn uzaklýgý için gerekli
    public Vector3 targetedPosition; //smooth takio için gerekli
    private Vector3 velocity = Vector3.zero; //0 olan bir vektör
    public float smoothTime = 0.1F; //smooth katsayýsý
    // Update is called once per frame
    void Update()
    {
        targetedPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
    }

}
