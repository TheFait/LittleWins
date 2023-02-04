using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnCollision : MonoBehaviour
{
    public GameObject PartySphere;
    public Transform SphereLocation;
    public AudioSource SFXPlayer, BGMusicPlayer;
    public AudioClip DefaultBGMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Destroy everything with a "Cleanup" tag
            GameObject[] toClean = GameObject.FindGameObjectsWithTag("Cleanup");

            foreach(GameObject go in toClean)
            {
                Destroy(go);
            }

            // Create new Sphere at location
            GameObject newSphere = Instantiate(PartySphere, SphereLocation);
            newSphere.GetComponent<WinCollisionDetection>().AudioSourceOnDeathSound = SFXPlayer;
            newSphere.GetComponent<WinCollisionDetection>().BackgroundMusicAudioSource = BGMusicPlayer;

            BGMusicPlayer.Stop();
            BGMusicPlayer.clip = DefaultBGMusic;
            BGMusicPlayer.Play();

            LogManager.Instance.Reset();
        }
    }

    private void Awake()
    {
        GameObject newSphere = Instantiate(PartySphere, SphereLocation);
        newSphere.GetComponent<WinCollisionDetection>().AudioSourceOnDeathSound = SFXPlayer;
        newSphere.GetComponent<WinCollisionDetection>().BackgroundMusicAudioSource = BGMusicPlayer;
    }
}
