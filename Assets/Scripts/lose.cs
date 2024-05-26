using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{
    public Animator ani;

    public bool hasLost;

    public AudioClip loseMusic;

    public AudioClip scream;

    public AudioSource music;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

    }


   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            if(hasLost) 
                return;
            hasLost = true;

            source.PlayOneShot(loseMusic);
            source.PlayOneShot(scream);
            music.Stop();

            ani.Play("deathAni");
            Invoke("RestartScene", 5);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
