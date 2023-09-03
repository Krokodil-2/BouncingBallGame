using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace BouncingBall
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;

        [Header("Logic")]
        [SerializeField] private PlayerMouseInput mouseInput;
        [SerializeField] private Raycaster raycaster;
        [SerializeField] private PlayerThrower thrower;
        [SerializeField] private StickDrawer stickDrawer;
        [Space]
        [Header("Player")]
        [SerializeField] private RegularBouncingBall myBall;
        public RegularBouncingBall BallParameters { get { return myBall; } }


        public void GameOver()
        {
            Debug.Log($"{LogTags.Debug} GAME OVER");

            Initialization();
        }

    
        /// <summary>
        /// Now Ball launched.
        /// </summary>
        /// <param name="distance"></param>
        private void MouseInput_OnThrow(float distance)
        {
            stickDrawer.HideStick(true);

            thrower.Throw(distance);

            ControlMode(false);      
        }

        /// <summary>
        /// Left mouse button click in the flight.
        /// </summary>
        private void MouseInput_OnMouseClick()
        {            
            if (raycaster.TryRaycast())
            {           
                ControlMode(true);              
            }
            else
            {
                // игрок не попал
            }           
        }

      
        private void Initialization()
        {
            stickDrawer.HideStick(false);

            ControlMode(true);

            this.gameObject.transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Changing control.
        /// </summary>
        /// <param name="slightShot"></param>
        private void ControlMode(bool slightShot)
        {
            if (slightShot)
            {
                thrower.Stop();

                mouseInput.OnMouseClick -= MouseInput_OnMouseClick;

                mouseInput.ThrowingRegime = true;
                mouseInput.OnThrow += MouseInput_OnThrow;
            }
            else
            {
                mouseInput.ThrowingRegime = false;
                mouseInput.OnThrow -= MouseInput_OnThrow;

                raycaster.Initialize();

                // Waiting for a mouse click. Currently Ball in the flight.
                mouseInput.OnMouseClick += MouseInput_OnMouseClick;
            }
          
        }
        private void Start()
        {
            Initialization();

        }
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
    }
}