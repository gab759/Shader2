using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Dissolve : MonoBehaviour
{
    [SerializeField] private float _dissolveTime = 0.75f;

    private Material _material;

    private int _dissolveAmount = Shader.PropertyToID("_DissolveAmount");
    private int _verticalDissolveAmount = Shader.PropertyToID("_VerticalDissolve");

    private void Start()
    {
        SkinnedMeshRenderer renderer = GetComponent<SkinnedMeshRenderer>(); 
        _material = renderer.material;
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            StartCoroutine(Vanish(false, true));
        }
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            StartCoroutine(Apper(false, true));
        }
    }

    private IEnumerator Vanish(bool useDissolve, bool useVertical)
    {
        float elapsedTime = 0f;

        while (elapsedTime < _dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(0f, 1.1f, elapsedTime / _dissolveTime);
            float lerpedVerticalDissolve = Mathf.Lerp(0f, 1.1f, elapsedTime / _dissolveTime);

            if (_material != null)
            {
                if (useDissolve)
                    _material.SetFloat(_dissolveAmount, lerpedDissolve);

                if (useVertical)
                    _material.SetFloat(_verticalDissolveAmount, lerpedVerticalDissolve);
            }

            yield return null;
        }
    }

    private IEnumerator Apper(bool useDissolve, bool useVertical)
    {
        float elapsedTime = 0f;

        while (elapsedTime < _dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(1.1f, 0f, elapsedTime / _dissolveTime);
            float lerpedVerticalDissolve = Mathf.Lerp(1.1f, 0f, elapsedTime / _dissolveTime);

            if (_material != null)
            {
                if (useDissolve)
                    _material.SetFloat(_dissolveAmount, lerpedDissolve);

                if (useVertical)
                    _material.SetFloat(_verticalDissolveAmount, lerpedVerticalDissolve);
            }

            yield return null;
        }
    }
}
