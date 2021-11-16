using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataLevel1 {

// stores if level has been finished
    public bool levelFinished;

// stores player data
    public struct Player {
        public float[] playerPosition;
        public float[] playerRotation;
    }

// stores enemy data
    public struct Enemy {
        float[] enemyPosition;
        float[] enemyRotation;
    }

// array with all enemies present in level
    public Enemy[] allEnemies;

// stores if certain scenarios have already been found and which of their objects
    public struct Scenarios {
        bool familyEating;
        bool playingChildren;
        bool womenAtWell;
        bool famersWorking;
        bool ascendedTalking;
        bool ciaransHouse;
        //bool dog;

// wie sehr ist das wichtig, dass wir die einzelnen Objekte speichern? geht dann der glitch weg? ist das so gut?
        struct FamilyObjects {
            bool key;
            bool bacon;
            bool beer;
        }

        struct ChildrenObjects {
            bool mother;
            bool ball;
            bool drawing;
            bool smudge;
        }

        struct WellObjects {
            bool bucket;
            bool woman;
            bool well;
        }

        struct FarmersObejcts {
            bool suspensions;
            bool playcards;
            bool farmers;
        }

        struct CiaranObjects {
            bool diary;
            bool bread;
            bool book;
            bool burnedPaper;
            bool shelves;
            bool coat;
            bool chair;
            bool drawing;
        }
    }

// stores at which quest the player is atm
    enum quests {
        packThings,
        family,
        farmers,
        notebook,
        ciaran,
        ciaransHouse,
        followDisciple
    }

// stores which questItems have been found in this Level
    public struct QuestItems {
        bool key;
    }

// stores the amount of stones the player has at the moment
    //public short stonesOnPlayer;

// stores which stones have already been picked up
// we need that starting from Level 1
    /*public struct stones {
        bool stone1 = false;
        // etc.
    }*/

// various things that can be altered in the settings menu
    /*short volume;
    short brightness;

    public struct keyBindings {
        char walkForward;
        char walkBackward;
        char strifeLeft;
        char strifeRight;
        char jump;
        char hide;
        char sneak;
        char run;
        char throwStone;
        char interact;
        char takeAndUse;
    }*/

    public PlayerDataLevel1(Player p) {
        this.levelFinished = false;

        // player data
        Player player = new Player();

        this.player.playerPosition = new float[3];
        this.player.playerPosition[0] = p.transform.position.x;
        this.player.playerPosition[1] = p.transform.position.y;
        this.player.playerPosition[2] = p.transform.position.z;

        this.player.playerRotation = new float[3];
        this.player.playerPosition[0] = p.transform.rotation.x;
        this.player.playerPosition[1] = p.transform.rotation.y;
        this.player.playerPosition[2] = p.transform.rotation.z;

        // enemy data

    }

}
