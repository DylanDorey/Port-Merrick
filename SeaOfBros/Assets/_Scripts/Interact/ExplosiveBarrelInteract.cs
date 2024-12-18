using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelInteract : MonoBehaviour
{
    public bool shipExplosiveBarrel;

    public Animator sloopAnimator;

    private bool startEffect = false;

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

    [SerializeField]
    private GameObject sloop;

    [SerializeField]
    private GameObject explosiveTrigger;

    [SerializeField]
    private GameObject bridgeProps;


    private void Update()
    {
        if (startEffect)
        {
            StartEffect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the other object is the player
        if (other.CompareTag("Player") || other.CompareTag("Harpoon"))
        {
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

        model.SetActive(false);

        explosiveSmokeParticle.Play();

        //
        yield return new WaitForSeconds(.3f);

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
            sloop.GetComponent<Sloop>().startAnim = true;
            startEffect = false;
        }
        else
        {
            //spawn explosive prefab
            Instantiate(explosiveTrigger, transform.position + new Vector3(0f, -1f, -2f), Quaternion.identity);

            startEffect = false;
        }
    }
}
