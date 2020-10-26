using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace CarterGames.CWIS
{
    public class Floating : MonoBehaviour
    {
        [SerializeField] private float subDepth = 1f;
        [SerializeField] private float displacementAmount = 3f;
        [SerializeField] private Rigidbody rB;
        [SerializeField] private int floaters;
        [SerializeField] private float drag = .99f;
        [SerializeField] private float angularDrag = .5f;

        private void FixedUpdate()
        {
            rB.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);

            if (transform.position.y < 0f)
            {
                float displacementMulti = Mathf.Clamp01(-transform.position.y / subDepth) * displacementAmount;
                rB.AddForceAtPosition(new Vector3(0, Mathf.Abs(Physics.gravity.y) * displacementMulti, 0f), transform.position, ForceMode.Acceleration);
                rB.AddForce(displacementMulti * -rB.velocity * drag * Time.fixedDeltaTime, ForceMode.VelocityChange);
                rB.AddTorque(displacementMulti * -rB.angularVelocity * angularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }
    }
}