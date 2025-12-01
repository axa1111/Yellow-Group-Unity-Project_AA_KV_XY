using UnityEngine;
//script is on the main camera

//https://medium.com/@icodewithben/3-1-creating-a-mouse-look-script-for-your-3d-character-b5c1de2a0df5 mouse rotation (look at)
//https://docs.unity3d.com/6000.0/Documentation/Manual/class-InputManager.html = float horizontal = Input.GetAxis("Horizontal");
public class PlayerMovement : MonoBehaviour
{
    [Header("Look variables")]
    [SerializeField]
    private float sensitivity = 300f; ///manages the sensitivity of the mouse serialize field for tesing in game scene
    [SerializeField]
    private Transform player; //reference to players transform which is moved (changed) using this script
    private float xRotation = 0f; //rotation float

    //movement variables
    private float walkSpeed = 5f; //walkspeed how fast player should move
    private CharacterController playerController; //reference to character controller component on player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked; //keep mouse centre of th scene and hide it as it's not needed
        playerController = player.GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation Using Mouse

        float x = sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime; //sensitiviy is muliplied by Input.GetAxis of mouse.X and then multiplied by Time.deltatime for smoother movements
        float y = sensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime; //same as the above line but for y axis of mouse 

        //rotate body left and right
        player.Rotate(Vector3.up * x); //player is being rotated on the y axis (Vector3.up = Vector(0,1,0) using the x value of the mouse )

        //rotate camera up and down
        xRotation -= y; //invert the y as mouse down is -1 and up is +1 same as XRotation += -y
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //clamp (limit) rotation 
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //rotate the player locaally using the xrotation we rotate around y axis

        
        //Movement

        float horizontal = Input.GetAxis("Horizontal"); //see input manager - axis in project settings this refers to D & A keys returns -1 if a (left) and +1 if right
        float vertical = Input.GetAxis("Vertical"); //see input manager - axis in project settings this refers to w/s keys

        Vector3 move = player.transform.right * horizontal + player.transform.forward * vertical; //multiply players z axiz by horizontal input value plus multiply z axis by vertical input value 

        move.y = -0.01f; //there was a little jump when the player first started moving (likely the players collider was not touching the ground properly) 
        //we move the character down ever so lightly to ensure the collider is always touching the ground so the little jump doesn't happen

        playerController.Move(move * walkSpeed * Time.deltaTime); //moving the player in the game based on input (move = wasd) multiplied by the moveSpeed multiplied by Time.deltaTime
    }
}
