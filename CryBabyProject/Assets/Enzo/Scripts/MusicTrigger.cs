using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField]
    AudioSource carMusic;

    private void Start()
    {
        carMusic = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider col)
    {
        if (gameObject.tag == "Player")
        {
            carMusic.Play();
        }
    }
}
