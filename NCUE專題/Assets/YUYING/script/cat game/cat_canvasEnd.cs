using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class cat_canvasEnd : MonoBehaviour
{
    public GameObject cat;
    public Animator animator;
    public GameObject fish;
    public float fishSpeed = 1;

    public AudioSource audioSourceWin;
    public AudioSource audioSourceLose;

    // Start is called before the first frame update
    void Start()
    {
        animator = cat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fishDes = new Vector3(fish.transform.position.x, 1, fish.transform.position.z);
        fish.transform.position = Vector3.MoveTowards(fish.transform.position, fishDes, fishSpeed * Time.deltaTime);

        if (cat_selectCube.selectCube)
        {
            animator.SetBool("win", true);
            GetComponent<Text>().text = "Victory";
            fish.SetActive(true);
            audioSourceWin.Play();
            audioSourceLose.Pause();
        }
        else
        {
            animator.SetBool("lost", true);
            GetComponent<Text>().text = "Failure";
            fish.SetActive(false);
            audioSourceLose.Play();
            audioSourceWin.Pause();
        }
        
    }
}
