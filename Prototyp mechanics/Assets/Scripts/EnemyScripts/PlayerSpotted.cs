using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotted : MonoBehaviour
{
    [SerializeField] Collider player;
    private float timer = 0;
    public bool spotted;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col){
        
        if(col == player){
            
            spotted = true;
           timer = 10;
        }
        
        
       
    }
    private void Update(){
        if(spotted){
            if(timer > 0){
                timer -= Time.deltaTime;
            }
            else{
                spotted = false;
            }
           
        }

    }
}
