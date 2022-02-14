using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 90);
            transform.position += new Vector3(-0.1f, 0, 0);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -90);
            transform.position += new Vector3(0.1f, 0, 0);
        }
        
    }
}
