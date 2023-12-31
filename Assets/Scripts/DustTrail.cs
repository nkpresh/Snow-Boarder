using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem dustTrail;

    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.collider.tag == "Ground")
        {
            dustTrail.Stop();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            dustTrail.Play();
        }
    }
}



