using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRendererAnimation : MonoBehaviour
{
    public float duration = 1f;
    float speed = 2f;

    private bool isDoingLine;

    public LineRenderer line;

   // public GameObject gameObject1, gameObject2;

    public GameObject[] points;

    public GameObject mylable;

    public int count;
    public int startindex, nextIndex;
    public bool isLineComplete = false;

    private void Start()
    {
        // Add a Line Renderer to the GameObject
        // line = GetComponent<LineRenderer>();
        // Set the width of the Line Renderer
        // line.SetWidth(0.0012F, 0.0012F);

        resetline();
       // StartCoroutine(DoLine());
    }

    private void Update()
    {
        resetline();
    }

    private void OnEnable()
    {
        resetline();
      //  StartCoroutine(DoLine());
    }
    void resetline()
    {
        line.positionCount = points.Length;
        line.SetPosition(0, points[0].transform.position);
        line.SetPosition(1, points[1].transform.position);
        line.SetPosition(2, points[2].transform.position);

        count = 0;
        mylable.SetActive(true);

    }

    IEnumerator DoLine()
    {

        //while (!isDoingLine)
        //{
        //    startindex = 0;
        //    nextIndex = 1;
            
        //    yield return null;
        //}

        StartCoroutine(LineRoutine());
        yield return null;
    }

    IEnumerator LineRoutine()
    {
        isDoingLine = true;

        //while (count < points.Length)
        //{


        //    line.SetPosition(startindex, points[startindex].transform.position);

        //    var timePassed = 0f;
        //    while (timePassed < duration)
        //    {
        //        var factor = timePassed / duration;
        //        // optionally add ease-in ease-out
        //        //factor = Mathf.SmoothStep(0, 1, factor);

        //        line.SetPosition(nextIndex, Vector3.Lerp(points[startindex].transform.position, points[nextIndex].transform.position, factor));

        //        timePassed += Mathf.Min(Time.deltaTime * speed, duration - timePassed);

        //        yield return null;
        //    }
        //    Debug.Log("called");
        //    // when done just in case set the final position fix
        //    // line.SetPosition(nextIndex, points[nextIndex].transform.position);


        //    count++;
        //    if (count < points.Length)
        //    {
        //        startindex++;
        //        if (nextIndex < points.Length - 1)
        //        {
        //            nextIndex++;
        //        }
        //    }
        //}



        mylable.SetActive(true);
        isDoingLine = false;
        yield return null;

    }


}
