using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cat_clickCat : MonoBehaviour
{
    public GameObject cat;
    public Animator animator;

    bool isSitting;
    bool idle;

    // Start is called before the first frame update
    void Start()
    {
        animator = cat.GetComponent<Animator>();
        animator.SetBool("isSitting", false);
        animator.SetBool("idle", true);
        isSitting = false;
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cat == GetClickedObject(out RaycastHit hit))
            {
                if (isSitting == false)
                {
                    animator.SetBool("isSitting", true);
                    isSitting = true;
                }
                else
                {
                    animator.SetBool("isSitting", false);
                    isSitting = false;
                }
            }
        }
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            if (!isPointerOverUIObject()) { target = hit.collider.gameObject; }
        }
        return target;
    }
    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
}
