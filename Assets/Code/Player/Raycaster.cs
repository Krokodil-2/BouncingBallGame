using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BouncingBall
{
    /// <summary>
    /// Клас дял проверки возможности зацепления игрока за стену
    /// </summary>
    public class Raycaster : MonoBehaviour
    {
        [Header("Debug")]
        [SerializeField] private bool useDebug;
        [Space(20)]
        [SerializeField] private StickDrawer stickDrawer;

        private int MaxAttemptsNumber = 1;
        private int currentAttemts;

        /// <summary>
        /// Raycast to determine the surface in front of the player.
        /// </summary>
        /// <returns></returns>
        public bool TryRaycast()
        {
            if (currentAttemts >= MaxAttemptsNumber)
            {
                RaycastHit hit;

                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    // Игрок попал в безопасную зону
                    if (hit.collider.GetComponent<SafeArea>())
                    {

                        stickDrawer.DrawStick(true, hit.point);

                        if (useDebug) Debug.Log($"{LogTags.Debug} Did Hit Safe Zone");
                        return true;

                    }
                    else if (hit.collider.GetComponent<DangerArea>())
                    {

                        stickDrawer.DrawStick(false, hit.point);

                        // Неудачная попытка
                        currentAttemts--;

                        if (useDebug) Debug.Log($"{LogTags.Debug} Did Hit Danger Zone. Attempts left - {currentAttemts}");
                        return false;
                    }
                    else
                    {
                        if (useDebug) Debug.Log($"{LogTags.Warning} Hit Unknown");
                        return false;
                    }

                }
                else
                {
                    if (useDebug) Debug.Log($"{LogTags.Warning} Did not hit anything");
                    return false;

                }
            }
            else
            {
                return false;
            }
           
        }

        /// <summary>
        /// Initialize to get max attempts number.
        /// </summary>
        public void Initialize()
        {
            MaxAttemptsNumber = PlayerController.Instance.BallParameters.AttemptsNumber;
            currentAttemts = MaxAttemptsNumber;

            if (useDebug) Debug.Log($"{LogTags.Debug} Raycaster Initialization. Max Attemts - {MaxAttemptsNumber}");
        }
       
    }
}