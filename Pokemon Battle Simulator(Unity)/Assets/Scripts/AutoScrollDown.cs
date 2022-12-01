using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoScrollDown : MonoBehaviour
{
    public void ScrollDown()
    {
        StartCoroutine("AutoScroll");
    }

    private IEnumerator AutoScroll()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        transform.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
    }
}
