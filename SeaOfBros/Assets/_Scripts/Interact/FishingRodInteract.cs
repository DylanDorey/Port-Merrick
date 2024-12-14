using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingRodInteract : MonoBehaviour
{
    private bool equipped = false;
    private bool fishCaught = false;

    [SerializeField]
    private GameObject fishingRod;

    [SerializeField]
    private GameObject fishPrefab;

    private GameObject fish;

    [SerializeField]
    private Transform endPoint;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource fishingRodAudioSource;

    [SerializeField]
    private AudioClip castSound;

    [SerializeField]
    private AudioClip reelSound;


    private void Start()
    {
        fishingRod.transform.GetChild(0).gameObject.SetActive(false);
        equipped = false;
    }

    private void Update()
    {
        if(equipped)
        {
            fishingRod.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            fishingRod.transform.GetChild(0).gameObject.SetActive(false);

            if (fishCaught)
            {
                Destroy(fish);
            }
        }

        if(fishCaught && fish != null)
        {
            fish.transform.position = endPoint.position;
        }
    }

    public void OnEquip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            equipped = !equipped;
        }
    }

    public void OnCast(InputAction.CallbackContext context)
    {
        if (context.performed && equipped)
        {
            //play casting animation
            animator.SetBool("Casting", true);

            //
            StartCoroutine(CatchFish());

            fishingRodAudioSource.clip = castSound;
            fishingRodAudioSource.Play();
        }
    }

    private IEnumerator CatchFish()
    {
        float randomCatchTime = Random.Range(5f, 12f);

        yield return new WaitForSeconds(randomCatchTime);

        fishCaught = true;

        fish = Instantiate(fishPrefab, endPoint.position, Quaternion.identity);
        fish.transform.eulerAngles += new Vector3(0f, 90f, 0f);

        //SHOW CAUGHT UI

        //TEMP
        animator.SetBool("Reeling", true);
        animator.SetBool("Casting", false);


        fishingRodAudioSource.clip = reelSound;
        fishingRodAudioSource.Play();

        StartCoroutine(ReelDelay());
    }

    private IEnumerator ReelDelay()
    {
        yield return new WaitForSeconds(8f);

        animator.SetBool("Reeling", false);

        Destroy(fish, 2f);
    }
}
