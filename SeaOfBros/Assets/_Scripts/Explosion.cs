using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosiveFuse = 10;
    public float Explosiveforce = 50;
    public float ExplosiveRadius = 10;

    private Collider[] hitColliders;


    void Start()
    {
        ExplosionDamage();
    }

    void ExplosionDamage()
    {
        hitColliders = Physics.OverlapSphere(this.transform.position, ExplosiveRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Rigidbody>() != null && !hitCollider.gameObject.GetComponent<CharacterController>())
            {
                hitCollider.GetComponent<Rigidbody>().isKinematic = false;
                hitCollider.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Explosiveforce, this.transform.position, ExplosiveRadius);
            }
        }

        StartCoroutine(RemoveColliders());
    }

    private IEnumerator RemoveColliders()
    {
        yield return new WaitForSeconds(1f);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<BoxCollider>() && hitCollider.gameObject.layer != 3)
            {
                hitCollider.GetComponent<BoxCollider>().enabled = false;
            }
        }

        gameObject.SetActive(false);
    }
}
