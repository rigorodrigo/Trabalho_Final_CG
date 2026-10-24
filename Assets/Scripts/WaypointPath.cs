using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform[] waypoints;

    // Popula automaticamente os filhos caso você esqueça de arrastar no Inspector
    private void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    // Desenha a linha do caminho na aba Scene da Unity
    private void OnDrawGizmos()
    {
        if (transform.childCount < 2) return;

        Gizmos.color = Color.yellow;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
            Gizmos.DrawSphere(transform.GetChild(i).position, 0.3f);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.GetChild(transform.childCount - 1).position, 0.4f);
    }
}