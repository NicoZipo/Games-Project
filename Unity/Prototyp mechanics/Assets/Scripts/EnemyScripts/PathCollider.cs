using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCollider : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame
    
    [SerializeField]    private Collider col1;
    
    [SerializeField]    private Collider col2;
   
    [SerializeField]    private Collider col3;
    public bool collidedTarget1 = false;
    public bool collidedTarget2 = false;

   public bool collidedTarget3 = false;
    private void OnTriggerEnter(Collider col){
     
     if(col == col1){
         collidedTarget1 = true;
         collidedTarget2 = false;
         collidedTarget3 = false;
     }
     if(col==col2){
        
         collidedTarget1 = false;
         collidedTarget2 = true;
         collidedTarget3 = false;
     }
     if(col == col3){
        collidedTarget1 = false;
        collidedTarget2 = false;
        collidedTarget3 = true;
     }
   
       
    }
}
