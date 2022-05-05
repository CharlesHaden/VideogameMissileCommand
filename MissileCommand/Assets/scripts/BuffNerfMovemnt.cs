using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffNerfMovemnt : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * speed *
            -10 * Time.deltaTime;
    }
}
