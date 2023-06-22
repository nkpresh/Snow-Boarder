using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    float loadDelay = 1;

    [SerializeField]
    ParticleSystem crashEffect;

    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().Play();
            PlayerController player = FindObjectOfType<PlayerController>();
            player.DisableControls();
            Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
