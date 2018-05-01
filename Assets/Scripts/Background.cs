using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float xFrequency;
    public float yFrequency;
    public float amplitude;

    private Vector3 initialPosition;
    private float phaseX;
    private float phaseY;
    
    private void updatePosition()
    {
        phaseX += Time.deltaTime * xFrequency;
        phaseY += Time.deltaTime * yFrequency;

        phaseX %= 2f * Mathf.PI;
        phaseY %= 2f * Mathf.PI;

        float x = amplitude * Mathf.Sin(phaseX);
        float y = amplitude * Mathf.Sin(phaseY);

        Vector3 adjustment = new Vector3(x, y);

        transform.position = initialPosition + adjustment;
    }
    
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        updatePosition();
    }
}
