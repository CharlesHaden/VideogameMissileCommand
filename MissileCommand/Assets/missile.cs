using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(explosion, 0.25f);
        Destroy(gameObject);
    }
}
