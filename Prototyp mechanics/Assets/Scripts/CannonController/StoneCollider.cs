using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollider : MonoBehaviour
{
   EnemyNavMesh enemy;
private void Start(){
enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyNavMesh>();
}
    
    float timer = 0;
    // Start is called before the first frame update
  private void OnCollisionEnter(Collision collision){
    Debug.Log(collision.transform.position.ToString());
      enemy.stonePosition = this.transform.position;
      enemy.stoneCollided = true;
      timer = 10;
  }
private void Update(){
    if(enemy.stoneCollided){
       
        timer -= Time.deltaTime;
        if(timer < 0){
            enemy.stoneCollided = false;
        }
    }
}
  
}
