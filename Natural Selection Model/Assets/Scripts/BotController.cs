using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BotController : MonoBehaviour 
{

    public GameObject GameController;
    private GameController GameScript;
    public GameObject SpawnController;
    public GameObject botPrefab;
    private Vector3 startPos;
    //private GameObject spawnPos;
    public float speed = 0;
    private Transform nearestFood;
    private Rigidbody rb;
    public float energy;
    private int eatenToday = 0;
    public bool isBack = true;
    //public bool DayIsOver = false;


    public void Awake()
    {
        GameScript = GameController.GetComponent<GameController>();
        GameScript.AllBots.Add(gameObject);
        startPos = transform.position;
        isBack = true;
        rb = GetComponent<Rigidbody>();
    }


    public void StartRound()
    {
            if (gameObject.tag == "Team1")
            {
                startPos = GameObject.FindGameObjectWithTag("Spawn1").transform.position;
                GameScript.TeamOne.Add(gameObject);
            }
            else
            {
                startPos = GameObject.FindGameObjectWithTag("Spawn2").transform.position;
                GameScript.TeamTwo.Add(gameObject);
            }
            speed = 3;
            energy = 5;
            startPos = transform.position;
            nearestFood = FindFood();
            isBack = false;
    }

    public void SetSpeed()
    {
        speed = 0;
        Duplicate();
    }

    private void Duplicate()
    { 
        if (eatenToday > 1)
        {
            if (gameObject.tag == "Team1")
            {
                SpawnController.GetComponent<SpawnController>().newOnes += 1;
                SpawnController.GetComponent<SpawnController>().Spawn();
            }
            else
            {
                SpawnController.GetComponent<SpawnController>().newTwos += 1;
                SpawnController.GetComponent<SpawnController>().Spawn();
            }
            //Instantiate(botPrefab, startPos, Quaternion.identity);
        }
        else if(eatenToday == 0)
        {
            Destroy(gameObject);
            GameController.GetComponent<GameController>().TeamOne.Remove(gameObject);
            GameController.GetComponent<GameController>().AllBots.Remove(gameObject);
        }
        eatenToday = 0;
        isBack = true;
    }

    private void FixedUpdate()
    {
        if (isBack == false)
        {
            energy -= Time.deltaTime;
            if (energy > 0)
            {
                if (nearestFood != null)
                {
                    //Debug.Log("nearestFood != null");
                    Vector3 direction = (nearestFood.position - transform.position).normalized;
                    rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
                }
                else
                {
                    //Debug.Log("nearestFood == null");
                    FindFood();
                }
            }
            else
            {
                Vector3 moveBack = (startPos - transform.position).normalized;
                rb.MovePosition(transform.position + (moveBack * speed * Time.deltaTime));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Food"))
        {
            collision.gameObject.GetComponent<Renderer>().enabled = false;
            collision.gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.tag = "Untagged";
            eatenToday += 1;
            nearestFood = FindFood();
        }
    }

    public Transform FindFood()
    {
        /*List<Transform> tList = new List<Transform>();
        foreach (GameObject x in GameScript.activeFood)
        {
            tList.Add(x.transform);
        }

        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in tList)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;*/

        //canidates.Add(GameObject.FindGameObjectsWithTag("Food");
        GameObject[] canidates = GameObject.FindGameObjectsWithTag("Food");
        float minDistance = Mathf.Infinity;
        Transform closest;

        if (canidates.Length == 0)
        {
            return null;
        }

        closest = canidates[0].transform;
        for (int i = 1; i < canidates.Length; i++)
        {
            //Debug.Log("FoundFood");
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
