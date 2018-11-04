using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 10f;
    [SerializeField] float ySpeed = 10f;
    [SerializeField] float xMovementConstraint = 3f;
    [SerializeField] float yMovementConstraint = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float throwPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 6f;
    [SerializeField] float throwRollFactor = -20f;

    float xThrow, yThrow;

	// Use this for initialization
	void Start () {
        
	}	

	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + (yThrow * throwPitchFactor) ;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * throwRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float xNewPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xMovementConstraint, xMovementConstraint);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float yNewPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yMovementConstraint, yMovementConstraint);

        transform.localPosition = new Vector3(xNewPos, yNewPos, transform.localPosition.z);
    }
}
