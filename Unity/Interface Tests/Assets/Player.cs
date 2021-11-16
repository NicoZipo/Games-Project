using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    // variables that are not yet there
    



    // Save Data
    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    // Load Data
    public void LoadPlayer() {
        PlayerDataLevel1 data = SaveSystem.LoadPlayer();
        

        Vector3 position;
        position.x = data.player.playerPosition[0];
        position.y = data.player.playerPosition[1];
        position.z = data.player.playerPosition[2];
        transform.position = position;
    
        Quaterion rotation;
        rotation.x = data.player.playerRotation[0];
        rotation.y = data.player.playerRotation[1];
        rotation.z = data.player.playerRotation[2];
        transform.rotation = rotation;
    }

}
