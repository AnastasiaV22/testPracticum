using System.Collections;
using System.Collections.Generic;
using Test.Inputs;
using UnityEngine;

namespace Test.Inputs
{
    public class InputController : MonoBehaviour
    {
        private float horizontalDirection;
        private float verticalDirection;
        [SerializeField] private PlayerMovement playerMovement;

        float verticalRotation;
        [SerializeField] private CameraMovement cameraMovement;

        private void Update()
        {
            horizontalDirection = Input.GetAxisRaw("Horizontal");
            verticalDirection = Input.GetAxisRaw("Vertical");


            verticalRotation = 2f * Input.GetAxis("Mouse Y");
        }

        void FixedUpdate()
        {
            playerMovement.MoveCharacter(horizontalDirection, verticalDirection);
            
            cameraMovement.transform.Rotate(0, verticalRotation, 0, Space.World );

        }

    }
}

