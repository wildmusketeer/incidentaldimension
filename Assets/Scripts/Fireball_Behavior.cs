using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball_Behavior : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip fireballDestroySFX;
    public AudioClip deathSFX;

    public GameObject fireball3D;

    public Vector3 mDirection = new Vector3(1, 0, 0);
    public float mMovementSpeed = 10.0f;


    // Use this for initialization
    void Start()
    {
        audioSource = GameObject.Find("FireballSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += mDirection * mMovementSpeed * Time.deltaTime;

        
    }

    private void OnTriggerStay(Collider other)
    {
        bool hitConverter = other.gameObject.layer == LayerMask.NameToLayer("Converter");
    
       
        
        if (hitConverter)
        {
            Debug.Log("Fireball Hit Converter");
            //convert into 3D on sphere
            GameObject newFireball3D = GameObject.Instantiate(fireball3D);

            newFireball3D.GetComponent<Fireball3D_Behavior>().mCurrPosition = transform.position;
            newFireball3D.GetComponent<Fireball3D_Behavior>().mDirection = mDirection;
            newFireball3D.SetActive(true);
            GameObject.Destroy(gameObject);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        bool hitBox = collision.collider.gameObject.layer == LayerMask.NameToLayer("Box");
        bool hitWall = collision.collider.gameObject.layer == LayerMask.NameToLayer("Wall");
        bool hitButton = collision.collider.gameObject.layer == LayerMask.NameToLayer("Button");
        bool hitPlayer = collision.collider.gameObject.layer == LayerMask.NameToLayer("Player");
        bool toDestroy = false;
        if (hitBox)
        {
            Debug.Log("Fireball Hit Box");
            collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(mDirection * 500.0f, ForceMode.Impulse);
            toDestroy = true;
        }
        else if(hitWall)
        {
            Debug.Log("Fireball Hit Wall");
            toDestroy = true;
        }
        else if(hitButton)
        {
            Debug.Log("Fireball Hit Button");

        }
        else if(hitPlayer)
        {
            audioSource.pitch = 1.0f;
            audioSource.PlayOneShot(deathSFX);
            SceneManager.LoadScene(0);
        }

        if(toDestroy)
        {
            audioSource.pitch = 1.0f;
            audioSource.PlayOneShot(fireballDestroySFX);
            GameObject.Destroy(gameObject);
        }
    }
}
