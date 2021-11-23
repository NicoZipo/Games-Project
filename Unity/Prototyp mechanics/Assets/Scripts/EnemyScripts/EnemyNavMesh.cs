using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    
    [SerializeField] private Transform movePos1;
    [SerializeField] private Transform movePos2;
     [SerializeField] private Transform movePos3;
     [SerializeField] private Transform player;
     [SerializeField] PathCollider collider;
     [SerializeField] PlayerSpotted spotted;

    public bool stoneCollided;
    public Vector3 stonePosition;
    private NavMeshAgent navMeshAgent;
    private void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    
    private void Update(){
         LayerMask mask = LayerMask.GetMask("Player");
         
          if (Physics.Raycast(transform.position, transform.forward, 1000000000.0f, mask))
            {
                Debug.Log("Fired and hit a wall");
            }
        if(spotted.spotted){
           
                navMeshAgent.destination = player.position;
        }
        else{
            if(stoneCollided){
                navMeshAgent.destination = stonePosition;
            }
            else{
                if(collider.collidedTarget1){
                        navMeshAgent.destination = movePos2.position;
                }
                else if(collider.collidedTarget2){
                        navMeshAgent.destination = movePos3.position;
                }
                else if(collider.collidedTarget3){
                        navMeshAgent.destination = movePos1.position;
                }
                else{
                        navMeshAgent.destination = movePos1.position;
                }
            }
               
        }

     

    }
}
