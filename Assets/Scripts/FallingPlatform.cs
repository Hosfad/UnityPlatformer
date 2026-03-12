using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingPlatform : MonoBehaviour
{
    [Header("Platform Settings")]
    public float fallDelay = 1.0f;
    public float jiggleIntensity = 0.05f;
    public float timeBeforeReset = 3.0f;

    private Rigidbody rb;
    private Vector3 initialPosition;
    private bool isTriggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player stepped on the platform. Starting fall sequence.");
        StartCoroutine(FallSequence());
    }

    IEnumerator FallSequence()
    {
        isTriggered = true;
        float elapsedTime = 0f;

        while (elapsedTime < fallDelay)
        {
            Vector3 randomOffset = Random.insideUnitSphere * jiggleIntensity;

            transform.position = initialPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition;

        rb.isKinematic = false;

        yield return new WaitForSeconds(timeBeforeReset);

        ResetPlatform();
    }

    void ResetPlatform()
    {
        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;
        transform.position = initialPosition;

        isTriggered = false;
    }
}