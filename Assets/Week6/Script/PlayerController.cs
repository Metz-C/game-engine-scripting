using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Week6
{


    public class PlayerController : MonoBehaviour
    {
        //in the new system
        Rigidbody rb;
        const float SPEED = 5.5f;
        
        [SerializeField] InputAction moveAction;
        InputAction jumpAction;

        PlayerControllerMappings mappings;
       

        // Create the C# File PalyerControllerMappings mappings;

        private void Awake()
        {
            mappings = new PlayerControllerMappings();

            //rb = GetComponent<Rigidbody>();
           
        }

        private void OnEnable()
        {
            moveAction = mappings.Player.Move;
            moveAction.Enable();

            jumpAction = mappings.Player.Jump;
            jumpAction.Enable();
            jumpAction.performed += OnJump;
        }

        private void OnDisable()
        {
            moveAction.Disable();
            jumpAction.Disable();
            jumpAction.performed -= OnJump;
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            //float moveX = Input.GetAxis("Horizontal");
            //float moveY = Input.GetAxis("Vertical");
            //float moveZ = Input.GetAxis("Horizontal");
            //moveDirection = new Vector2(moveX, moveY).normalized;

            //INFO: ReadValue is a generic function
            /*      Returns a vector2 with value of the format (x,y) where
             *      x represents our input from A and D 
             *      y represents our input from W and S
             *      on a range from -1 to +1
             */

            Vector2 input = moveAction.ReadValue<Vector2>();
            input *= SPEED * Time.deltaTime;

            transform.position = new Vector3(transform.position.x + input.x, 
                                             transform.position.y, 
                                             transform.position.z + input.y);
           


        }

        void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("Jump!");
        }

    }
}
