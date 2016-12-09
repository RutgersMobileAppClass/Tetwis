using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject floor;

    Vector3 offset;
    float highest;

    // Use this for initialization
    void Start()
    {
        highest = -15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] allTetros = GameObject.FindGameObjectsWithTag("Tetro");  //returns GameObject[]
        float height = 0;
        highest = -15.0f;
        foreach (GameObject o in allTetros)
        {
            if (o.GetComponent<Rigidbody2D>().velocity.y < -4.0f)
            {
            }
            else {
                height = o.transform.position.y;
                if (height > highest)
                {
                    highest = height - 1.0f;
                }
            }
        }
    }
    
    void LateUpdate()
    {
        if (transform.position.y - 5.0f < highest)
        {
            transform.position += new Vector3(0, 0.01f, 0);
        }
        else if (transform.position.y - 15.0f > highest)
        {
            transform.position -= new Vector3(0, 0.01f, 0);
        }
    }
}