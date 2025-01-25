using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Durée pendant laquelle la caméra va trembler.
    public float shakeDuration = 1f;

    // Amplitude de la secousse. Une valeur plus élevée secoue la caméra plus fortement.
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPos;

    void OnEnable()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }
}
