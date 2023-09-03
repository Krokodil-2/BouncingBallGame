using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.InputSystem;
namespace BouncingBall
{
    public class PlayerMouseInput : MonoBehaviour
    {
        #region Events
        public event Action OnMouseClick;
        private void DoMouseClick() { OnMouseClick?.Invoke(); }

        public event Action<float> OnThrow;
        private void DoThrow(float distance) { OnThrow?.Invoke(distance); }


        #endregion



        private bool pressed = false;

        private bool throwingRegime;
        public bool ThrowingRegime
        {
            get { return throwingRegime; }
            set { throwingRegime = value; }
        }

        private Vector2 startPosition;
        private Vector2 endPosition;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (throwingRegime)
            {
                if (!pressed)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("Key Down");
                        pressed = true;

                        startPosition = Input.mousePosition;
                    }

                }
                else
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        //Debug.Log("Key Pressed");
                        endPosition = Input.mousePosition;

                    }

                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        pressed = false;
                        float screenSizeFactor = Screen.height / 100;
                        Debug.Log($"Factor = {Screen.height} / {100} = {screenSizeFactor}");

                        // Дистанция между двумя точками на экране зависит от разрешения экрана
                        Debug.Log($"Distance (percentage): {((startPosition.y - endPosition.y) / screenSizeFactor)}");


                        DoThrow((startPosition.y - endPosition.y) / screenSizeFactor);
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("Mouse Click");

                    DoMouseClick();
                }
            }

        }
    }
}