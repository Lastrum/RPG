using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public float speed;
    public float height;

    public GameObject plank;
    public GameObject crown;

    public static bool hasPlank = false;
    
    private Rigidbody rb;
    private Vector3 newPosition;
    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        newPosition = transform.position;
        speed = speed * Time.deltaTime;
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);

                newPosition = new Vector3(hit.point.x, hit.point.y + height, hit.point.z);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);
    }
    
    void Update(){
        Movement();

        if (hasPlank)
        {
            plank.gameObject.SetActive(true);
        }
        else
        {
            plank.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plank"))
        {
            other.gameObject.SetActive(false);
            hasPlank = true;
        }

        if (other.CompareTag("Crown"))
        {
            other.gameObject.SetActive(false);
            crown.gameObject.SetActive(true);
        }
    }
}
