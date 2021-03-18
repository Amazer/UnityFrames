using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChannel : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioSource audioSource => _audioSource;

    void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    public void Play(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void Stop()
    {
        _audioSource.Stop();
    }

    public void Mute(bool mute)
    {
        _audioSource.mute = mute;
    }

    public static SoundChannel CreateChannel(Transform parent,string name="Channel")
    {
        GameObject go = new GameObject(name);
        SoundChannel channel = go.AddComponent<SoundChannel>();
        go.transform.SetParent(parent);
        go.transform.localPosition = Vector3.zero;
        return channel;
    }

    public static void DestroyChannel(SoundChannel channel)
    { 
        GameObject.Destroy(channel.gameObject);
    }
}