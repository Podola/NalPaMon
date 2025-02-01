using System;
using UnityEngine;

public class DialogKeyShow : MonoBehaviour
{
    public LayerMask PlayerLayer;
    public int layerSize;
    public GameObject KeyPrefab;
    private void Update()
    {
        RaycastHit2D ray = Physics2D.CircleCast(transform.position,layerSize,Vector2.zero,PlayerLayer);
        KeyPrefab.SetActive(ray);
        if (ray && Input.GetKeyDown(KeyCode.F))
        {
            ray.collider.gameObject.GetComponent<NpcDialog>().DialogExecution();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, layerSize);
    }
}
