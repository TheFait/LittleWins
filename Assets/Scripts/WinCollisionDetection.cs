using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinCollisionDetection : MonoBehaviour
{
    public GameObject OnDeathParticleSystem;
    public GameObject OnDeathParticleRain;
    public GameObject ExplosionVFX;

    public AudioSource AudioSourceOnDeathSound, BackgroundMusicAudioSource;
    public AudioClip OnDeathSoundEffect;
    public AudioClip CelebrationMusic;

    //bool to control animated movement on destroy
    private bool _isMoving;
    private Vector3 _movePosition;
    private float _moveSpeed = 2f;

    private void Awake()
    {
        _movePosition = transform.position + new Vector3(0f, 3f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Debug.Log($"Collided with {collision.gameObject.name}");
        //LogManager.Instance.AddToLog("Collided with: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collided with {other.gameObject.name}");
        //LogManager.Instance.AddToLog("Collided with: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        {
            LogManager.Instance.SetLog("Yay we won!!");

            // Disable first particle vfx
            transform.GetChild(0).gameObject.SetActive(false);


            // Disable Collider and Mesh Renderer
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

            //Turn on explosion VFX
            ExplosionVFX.SetActive(true);

            if(AudioSourceOnDeathSound != null)
            {

                Debug.Log("Playing audio");
                AudioSourceOnDeathSound.PlayOneShot(OnDeathSoundEffect);
                //audioPlayer.Play();
            }

            if (BackgroundMusicAudioSource != null)
            {
                StartCoroutine("CO_ChangeBackgroundMusic");
            }                   

            _isMoving = true;
            //Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, _movePosition, Time.deltaTime * _moveSpeed);


        }
    }

    private IEnumerator CO_ChangeBackgroundMusic()
    {
        BackgroundMusicAudioSource.Stop();
        BackgroundMusicAudioSource.clip = CelebrationMusic;
        yield return new WaitForSeconds(1.5f);
        _isMoving= false;
        BackgroundMusicAudioSource.Play();

        if (OnDeathParticleSystem)
        {
            //Instantiate(OnDeathParticleSystem, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(OnDeathParticleRain, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
