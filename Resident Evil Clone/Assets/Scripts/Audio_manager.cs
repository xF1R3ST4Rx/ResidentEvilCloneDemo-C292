using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] public AudioClip[] zombiedamage;
    public static audio_Manager instance;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    // Update is called once per frame
    public void PlayOneShot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
