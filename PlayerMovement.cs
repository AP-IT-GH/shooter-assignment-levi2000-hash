using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playercontroller;
    private float speed = 100f;

    public float lookRateSpeed = 90f;

    private Vector2 lookInput, screenCenter, mouseDistnace;
    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistnace.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistnace.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        
        transform.Rotate(-mouseDistnace.y * lookRateSpeed * Time.deltaTime, mouseDistnace.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);
        
        float forwardSpeed = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float StrafeSpeed = CrossPlatformInputManager.GetAxis("Horizontal") * speed;

        //playercontroller.Move(new Vector3(horizontal, vertical, speed * Time.deltaTime));
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;

    }
}
