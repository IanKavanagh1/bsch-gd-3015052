using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _navMeshAgent;


    private void Update()
    {
        if ( _navMeshAgent != null )
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hitPoint))
                    {
                        _navMeshAgent.destination = hitPoint.point;
                    }
                }
            }
        }
    }
}
