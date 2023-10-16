using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject selected;

    public int index;
    List<GameObject> elemt;
    // Start is called before the first frame update
    void Start()
    {
        elemt = new List<GameObject>();
        index = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);

                selected = hit.collider.gameObject;
                
            }
        }
    }

    public void hide()
    {
        
        elemt.Add(selected);
        index++;
        selected.SetActive(false);
    }
    public void undo()
    {
        if (index >= 0)
        {
            selected = elemt[index];
            selected.SetActive(true);
            elemt.RemoveAt(index);
            index--;
        }
    
    }
}
