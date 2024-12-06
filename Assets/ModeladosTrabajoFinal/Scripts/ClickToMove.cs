using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    public class ClickToMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
        private RaycastHit hitInfo = new RaycastHit();

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                    agent.destination = hitInfo.point;
            }

            if (agent.velocity.magnitude > 0.1f)
            {
                animator.SetBool("EstoyCaminando", true);
            }
            else
            {
                animator.SetBool("EstoyCaminando", false);
            }
        }
    }
}