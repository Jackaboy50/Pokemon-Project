using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTeamButton : MonoBehaviour
{
    [SerializeField] private GameObject TeamPrefab;
    public void OnClick()
    {
        Instantiate(TeamPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity , transform.parent.gameObject.transform);
        transform.position = new Vector2(transform.position.x, transform.position.y - 240);
        transform.SetSiblingIndex(transform.GetSiblingIndex() + 1);
    }
}
