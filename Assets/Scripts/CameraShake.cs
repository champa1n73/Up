using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = .5f;
    
    [Header("References")]
    [SerializeField] FollowCamera followCamera;

    [Header("Position")]
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }
    

    IEnumerator Shake()
    {
        float elapsedTime = 0;

        while(elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        } 
        initialPosition = followCamera.GetNewPosition();
    }
}
