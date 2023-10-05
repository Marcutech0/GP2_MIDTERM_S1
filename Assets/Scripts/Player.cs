using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        turn.x += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.EulerAngles(0, turn.x, 0);
    }
}
