using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace BouncingBall
{
    public class PlayerThrower : MonoBehaviour
    {
        private Rigidbody myRb;

        /// <summary>
        /// Stop player's position in the air.
        /// </summary>
        public void Stop()
        {
            SetupPhysics(false);
        }


        /// <summary>
        /// Toss player up.
        /// </summary>
        /// <param name="percentage"></param>
        public void Throw(float percentage)
        {
            SetupPhysics(true);

            float force = percentage * PlayerController.Instance.BallParameters.ForceFactor;

            Debug.Log($"{LogTags.Debug} Throwing. percentage: {percentage}; ForceFactor: {PlayerController.Instance.BallParameters.ForceFactor}; Total Force: {force}");

            myRb.AddForce(new Vector3(0, force, 0));
            //myRb.AddForce(new Vector3(0, 150, 0));

        }


        private void SetupPhysics(bool physical)
        {
            myRb.useGravity = physical;
            myRb.isKinematic = !physical;
        }

        private void Awake()
        {
            if (!TryGetComponent<Rigidbody>(out myRb)) Debug.Log($"{LogTags.Warning} Unable to get component Rigidbody");

        }

    }
}