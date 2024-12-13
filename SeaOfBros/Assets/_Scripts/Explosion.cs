using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosiveFuse = 10;
    public float Explosiveforce = 10;
    public float ExplosiveRadius = 10;


    private void Start()
    {
        Invoke("ExplosionDamage", ExplosiveFuse);
    }

    void ExplosionDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, ExplosiveRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Rigidbody>() != null)
            {
                Debug.Log("hit");
                hitCollider.GetComponent<Rigidbody>().AddExplosionForce(Explosiveforce, this.transform.position, ExplosiveRadius);
            }
        }
    }
}
