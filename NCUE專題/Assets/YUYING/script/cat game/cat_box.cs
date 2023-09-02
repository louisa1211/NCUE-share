using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cat_box : MonoBehaviour
{
    public GameObject canvas;
    public GameObject cube;
    public GameObject cubeManager;
    public GameObject fish;
    public GameObject box;
    public List<GameObject> waypoints;
    private Animator animator;
    public float speed = 2;
    int index = 0;
    int round = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("close", false);

        //canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("close", true);

        Vector3 fishDes = new Vector3(box.transform.position.x, (float)(box.transform.position.y + 0.7), box.transform.position.z);
        fish.transform.position = Vector3.MoveTowards(fish.transform.position, fishDes, 2f * Time.deltaTime);

        Vector3 destination = waypoints[index].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, destination);

        if (round < 3 && fish.transform.position.y == -2.5)
        {
            if (distance <= 0.05)
            {
                if (cat_randomValue.random[round] < 0.5)
                {
                    if (index == 2)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                    round++;
                }
                else
                {
                    if (index == 0)
                    {
                        index = 2;
                    }
                    else
                    {
                        index--;
                    }
                    round++;
                }
            }
        }

        //Cube¥X²{
        if (round == 3 && distance == 0)
        {
            cube.SetActive(true);
            cubeManager.SetActive(true);
        }
    }
}
