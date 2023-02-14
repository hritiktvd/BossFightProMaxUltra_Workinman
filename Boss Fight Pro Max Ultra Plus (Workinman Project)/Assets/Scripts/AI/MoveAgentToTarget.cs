using UnityEngine;
using UnityEngine.AI;

public class MoveAgentToTarget : MonoBehaviour
{
    public Transform targetPos;
    public NavMeshAgent crowdAgent;

    private Animator animator;


    private const string IDLE_ANIMATION_BOOL = "idle";
    private const string WALK_ANIMATION_BOOL = "walking";

    // Start is called before the first frame update
    void Start()
    {
        crowdAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        crowdAgent.SetDestination(targetPos.position);
    }

    private void Update()
    {

        AnimateWalking();

    }

    private void Animate(string boolname)
    {
        DisableOtherAnimationns(animator, boolname);

        animator.SetBool(boolname, true);
    }

    public void AnimateIdle()
    {
        Animate(IDLE_ANIMATION_BOOL);
        crowdAgent.isStopped = true;
    }

    public void AnimateWalking()
    {
        Animate(WALK_ANIMATION_BOOL);
        crowdAgent.SetDestination(targetPos.position);
        crowdAgent.isStopped = false;

    }

    private void DisableOtherAnimationns(Animator animator, string anim_name)
    {
        foreach(AnimatorControllerParameter parameter in animator.parameters)
        {
           if(parameter.name != anim_name)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }


}
