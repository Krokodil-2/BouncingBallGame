using BouncingBall;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StickDrawer : MonoBehaviour
{
    [SerializeField] private Stick stick;
    [SerializeField] private VisualEffect visualEffect;

    public void DrawStick(bool successfully, Vector3 hitPoint)
    {
        stick.gameObject.SetActive(true);

        StartCoroutine(Timer());
        StartCoroutine(VisualEffect());
        Debug.Log($"Hit point {hitPoint}");
       
    }

    public void HideStick(bool hide)
    {
        stick.gameObject.SetActive(false);

    }

    private IEnumerator VisualEffect()
    {
        visualEffect.Play();
        yield return null;

    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.2f);
        stick.gameObject.SetActive(false);

    }
    private void Awake()
    {
        stick.gameObject.SetActive(false);

    }
}
