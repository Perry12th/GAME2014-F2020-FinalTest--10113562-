using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SrinkingPlatform : MonoBehaviour
{
    bool playerOnPlatform = false;
    [SerializeField]
    AudioSource shrinkNoise;
    [SerializeField]
    AudioSource growNoise;
    // Update is called once per frame
    void Update()
    {
        if(playerOnPlatform)
        {
            Shrink();
        }
        else
        {
            Grow();
        }
    }

    private void Shrink()
    {
        if(transform.localScale.x > Mathf.Epsilon || transform.localScale.y > Mathf.Epsilon)
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.999f, transform.localScale.y * 0.999f);
        }
    }
    private void Grow()
    {
        if (transform.localScale.x < 1.0f || transform.localScale.y < 1.0f)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1.01f, transform.localScale.y * 1.01f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            shrinkNoise.Play();
            playerOnPlatform = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            growNoise.Play();
            playerOnPlatform = false;
        }
    }
}
