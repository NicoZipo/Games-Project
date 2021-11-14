using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float rotationspeed = 3;
    [SerializeField] public float blastPower = 10 ;
    
    public GameObject CannonBall;
    public Transform ShotPoint;

   public GameObject Player;

    void Update()
    {
       float horizontalRotation = Player.transform.rotation.x;  
       float verticalRotation = Input.GetAxis("Mouse Y");
       transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(verticalRotation * -rotationspeed, horizontalRotation, 0));

       if(Input.GetMouseButtonDown(0)){
           GameObject CreatedCannonBall = Instantiate(CannonBall, ShotPoint.position, ShotPoint.rotation);
           CreatedCannonBall.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * blastPower;
           Destroy(CreatedCannonBall, 12);
                  }
    }

    
}
