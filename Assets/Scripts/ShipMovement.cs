using UnityEngine;
using UnityEngine.InputSystem;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private float maxShipSpeed = 10000f;
        [SerializeField] private float moveSpd = 50f;
        [SerializeField] private float rotSpd = 50f;

        private Rigidbody rb;
        private Actions actions;

        private bool canMove;
        private bool canRot;


        private void Awake()
        {
            actions = new Actions();
            actions.Enable();
        }


        private void OnDisable()
        {
            actions.Disable();
        }


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }


        private void FixedUpdate()
        {
            if (!actions.Driver.Movement.ReadValue<Vector2>().y.Equals(0))
                Move();
            else
                SlowToStop();
        }


        private void Move()
        {
            if (rb.velocity.z < 500f)
            {
                rb.drag = 0f;

                if (actions.Driver.Movement.ReadValue<Vector2>().y > .1f)
                    rb.AddForce(transform.forward * moveSpd * Time.deltaTime, ForceMode.Force);
                else if (actions.Driver.Movement.ReadValue<Vector2>().y < -.1f)
                    rb.AddForce(-transform.forward * moveSpd * Time.deltaTime, ForceMode.Force);
            }


            if (actions.Driver.Movement.ReadValue<Vector2>().x > .1f)
                transform.Rotate(new Vector3(0, actions.Driver.Movement.ReadValue<Vector2>().x * rotSpd * Time.deltaTime, 0));
            else if (actions.Driver.Movement.ReadValue<Vector2>().x < -.1f)
                transform.Rotate(new Vector3(0, -actions.Driver.Movement.ReadValue<Vector2>().x * rotSpd * Time.deltaTime, 0));

        }


        private void SlowToStop()
        {
            rb.drag = .25f;
        }
    }
}