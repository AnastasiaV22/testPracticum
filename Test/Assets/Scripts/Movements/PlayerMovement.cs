using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Inputs
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        private float speed = 2f;
        private Rigidbody playerRB;

        private void Awake()
        {
            playerRB = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(float horizontalDirection, float verticalDirection)
        {
            playerRB.velocity = transform.forward * verticalDirection * speed;
            playerRB.transform.Rotate(0, horizontalDirection * speed, 0);
        }



    }

}