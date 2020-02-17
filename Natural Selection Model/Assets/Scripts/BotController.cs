using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour {

    public GameObject botPrefab;
    private Vector3 startPos;
    public GameObject spawnPos;
    public float speed = 3;
    private Transform nearestFood;
    private Rigidbody rb;
    public float energy;
    private int eatenToday = 0;
    public bool isBack = false;
    //public bool DayIsOver = false;

    public void StartRound()
    {
        if (gameObject.tag == "Team1")
        {
            spawnPos = GameObject.FindGameObjectWithTag("Spawn1");
        }
        else
        {
            spawnPos = GameObject.FindGameObjectWithTag("Spawn2");
        }
        speed = 3;
        energy = 5;
        startPos = spawnPos.transform.position;
        nearestFood = FindFood();
        rb = GetComponent<Rigidbody>();
        isBack = false;
    }

    public void SetSpeed()
    {
        speed = 0;
        isBack = true;
        Duplicate();
    }

    private void Duplicate()
    {
        if (eatenToday > 1)
        {
            Instantiate(botPrefab, startPos, Quaternion.identity);
        }
        else if(eatenToday == 0)
        {
            Destroy(gameObject);
        }
        eatenToday = 0;
    }

    private void FixedUpdate()
    {
        energy -= Time.deltaTime;
        if (energy > 0)
        {
            if (nearestFood != null)
            {
                Vector3 direction = (nearestFood.position - transform.position).normalized;
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
            else
            {
                FindFood();
            }
        }
        else
        {
            if (transform.position != startPos)
            {
                Vector3 newPosition = Vector3.MoveTowards(rb.position, startPos, speed * Time.deltaTime);
                rb.MovePosition(newPosition);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Food"))
        {
            collision.gameObject.SetActive(false);
            eatenToday += 1;
            //Destroy(collision.collider.gameObject);
            nearestFood = FindFood();
        }
    }

    public Transform FindFood()
    {
        GameObject[] canidates = GameObject.FindGameObjectsWithTag("Food");
        float minDistance = Mathf.Infinity;
        Transform closest;

        if (canidates.Length == 0)
        {
            return null;
        }

        closest = canidates[0].transform;
        for (int i = 1; i < canidates.Length; ++i)
        {
            float distance = (canidates[i].transform.position - transform.position).sqrMagnitude;
            if (distance < minDistance)
            {
                closest = canidates[i].transform;
                minDistance = distance;
            }
        }
        return closest;
    }


}
