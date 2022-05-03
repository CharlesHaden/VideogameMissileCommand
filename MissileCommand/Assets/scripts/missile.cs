using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    private Vector2 target;
    public GameObject hitEffect;
    private GameObject[] city;
    [SerializeField] private float speed = 1f;

    private void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        city = GameObject.FindGameObjectsWithTag("City");
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == (Vector3)target)
        {
            GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 0.60f);
            Destroy(gameObject);
        }
    }
    
}
