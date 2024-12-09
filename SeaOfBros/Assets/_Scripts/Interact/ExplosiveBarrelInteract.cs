using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelInteract : MonoBehaviour
{
    public bool shipExplosiveBarrel;

    public Animator sloopAnimator;

    private bool startEffect;

    private float fuseTime;

    [SerializeField]
    private ParticleSystem fuseSmokeParticle;

    [SerializeField]
    private ParticleSystem fuseSparksParticle;

    [SerializeField]
    private ParticleSystem explosiveParticle;

    [SerializeField]
    private ParticleSystem explosiveSmokeParticle;


    [SerializeField]
    private AudioClip fuseSound;

    [SerializeField]
    private AudioClip explosionSound;

    [SerializeField]
    private AudioSource explosiveBarrelAudioSource;

    [SerializeField]
    private GameObject model;

    private Camera playerCam;
    private bool lerpCam = false;

    private void Update()
    {
        if(lerpCam && playerCam != null)
        {
            playerCam.fieldOfView += 0.6f;
        }

        if(!lerpCam && playerCam != null)
        {
            if(playerCam != null && playerCam.fieldOfView < 60f || playerCam.fieldOfView > 60f)
            {

                playerCam.fieldOfView = 60f;
            }
        }

        if (startEffect)
        {
            StartEffect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the other object is the player
        if (other.CompareTag("Player"))
        {
            playerCam = other.transform.GetChild(0).GetComponent<Camera>();

            //start the explosive barrel coroutine sequence for particles
            StartCoroutine(ExplosiveBarrelCoroutine());
        }
    }

    /// <summary>
    /// plays all particle effects in sequential order with a delay
    /// </summary>
    /// <returns> the length of the fuse time </returns>
    private IEnumerator ExplosiveBarrelCoroutine()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        //play the fuse particle effect
        fuseSmokeParticle.Play();
        fuseSparksParticle.Play();

        //play fuse audio
        explosiveBarrelAudioSource.clip = fuseSound;
        explosiveBarrelAudioSource.Play();

        //set the fuseTime to the particle effects duration
        fuseTime = fuseSmokeParticle.main.duration;

        //wait the fuse time
        yield return new WaitForSeconds(fuseTime);

        fuseSmokeParticle.Stop();
        fuseSparksParticle.Stop();

        //play explosion audio
        explosiveBarrelAudioSource.clip = explosionSound;
        explosiveBarrelAudioSource.Play();

        //play the explosive particle effect, then disable the game object
        explosiveParticle.Play();

        lerpCam = true;

        model.SetActive(false);

        explosiveSmokeParticle.Play();

        //
        yield return new WaitForSeconds(.3f);

        lerpCam = false;

        startEffect = true;

        //
        yield return new WaitForSeconds(7f);

        gameObject.SetActive(false);
    }

    private void StartEffect()
    {
        if(shipExplosiveBarrel)
        {
            sloopAnimator.SetBool("isSinking", true);
        }
        else
        {

        }
    }
}
