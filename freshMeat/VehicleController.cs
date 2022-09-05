using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VehicleController : MonoBehaviour
{
    public static VehicleController main;
    AudioSource audSrc;
    public float minPitch = .1f;
    public float maxPitch = 1;
    public float pitchSpeed = 1f;

    private void Awake()
    {
        if (main == null)
            main = this;

        audSrc = gameObject.GetComponent<AudioSource>();
    }

    public float speed = 15;
    //public float maxSpeed = 1;
    //public float acceleration = 1;
    public float turnSpeed = 1;

    Rigidbody rigbod;
    // Start is called before the first frame update
    void Start()
    {
        rigbod = GetComponent<Rigidbody>();
        audSrc.Play();
    }

    void FixedUpdate()
    {
        if (UIManager.main.inGame)
        {
            var forwardInput = Input.GetAxis("Vertical");
            //if (forwardInput != 0)
            //{
            //    speed = Mathf.Min(speed + acceleration * Time.deltaTime, maxSpeed);
            //}
            //else
            //{
            //    speed = Mathf.Max(speed - acceleration * Time.deltaTime, 0);
            //}

            var turnInput = Input.GetAxis("Horizontal");

            if (forwardInput != 0)
            {
                rigbod.velocity = transform.forward * forwardInput * speed;
                audSrc.pitch = Mathf.Lerp(audSrc.pitch, maxPitch, pitchSpeed * Time.fixedDeltaTime);
            }
            else
            {
                var newPitch = Mathf.Lerp(audSrc.pitch, minPitch, pitchSpeed * Time.fixedDeltaTime);
                if (newPitch == minPitch)
                    audSrc.pitch = 0;
                else
                    audSrc.pitch = newPitch;
            }
            transform.Rotate(new Vector3(0, turnInput * turnSpeed * forwardInput * Time.fixedDeltaTime, 0));
        }
        else
        {
            audSrc.pitch = 0;
        }
    }
}
