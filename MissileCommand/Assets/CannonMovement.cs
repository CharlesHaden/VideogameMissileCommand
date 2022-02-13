using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition =  Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 directionOfCannon = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );
        transform.up = directionOfCannon;
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.position += new Vector3(-0.1f, 0, 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.position += new Vector3(0.1f, 0, 0);
        }
    }
}
