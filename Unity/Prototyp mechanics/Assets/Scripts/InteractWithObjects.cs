using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using DialogueNamespace;

namespace DialogueNamespace {
    // variables i need to call the dialogues (so much work TT)
    public enum esFamily { none, bacon, beer, key };
    public enum esChildern { none, mother, ball, drawing, smudge };
    public enum esWell { none, bucket, woman, well };
    public enum esFarmers { none, suspensions, playcards, people };
    public enum esCiaran { none, diary, bread, book, burnedPaper, shelves, coat, chair, drawing };
}

public class InteractWithObjects : MonoBehaviour
{

    public GameObject NotificationsUI;
    public GameObject keyObject;

    public Image newEntryImage;
    public Image updatedImage;
    public Image keyImage;
    public Image doorLocked;
    public Image doorOpened;

    public bool isInRange;

    private bool sFamily = false;
    private bool sChildren = false;
    private bool sWell = false;
    private bool sFarmers = false;
    private bool sCiaran = false;

    public static bool sFamilyFound = false;
    public static bool sChildrenFound = false;
    public static bool sWellFound = false;
    public static bool sFarmersFound = false;
    public static bool sCiaranFound = false;

    private bool soDoor = false;
    
    public static bool soKeyFound = false;
    public static bool soBookFound = false;
    public static bool soBurnedPaperFound = false;
    public static bool soShelvesFound = false;
    public static bool soCoatFound = false;

    public static bool soKeyUsed = false;

    // maps for the next semester!
    public static bool mapVicinaFound = false;
    public static bool mapKonostedtFound = false;
    public static bool mapCastraFound = false;
    public static bool mapCastleFound = false;
    //

    public static bool dialogueIsSaid = false;

    private bool familyYes = false;
    private bool childrenYes = false;
    private bool wellYes = false;
    private bool farmersYes = false;
    private bool ciaranYes = false; // i don't know how to name my variables anymore TT

    public static esFamily currentFamily;
    public static esChildern currentChildren;
    public static esWell currentWell;
    public static esFarmers currentFarmers;
    public static esCiaran currentCiaran; // so many variablessss

    // Start is called before the first frame update
    void Start() {
        NotificationsUI.SetActive(false);
        newEntryImage.enabled = false;
        updatedImage.enabled = false;
        keyImage.enabled = false;
        doorOpened.enabled = false;
        doorLocked.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        
        if (isInRange) {

            if (Input.GetKeyDown(KeyCode.F)) {
                //Debug.Log("pressed f!");
                NotificationsUI.SetActive(false);
                isInRange = false;

                whichObject();
                whichScenario();

                if (familyYes) {
                    Dialogues.sayFamily();
                    if (currentFamily == esFamily.key) {
                        isInRange = false;
                        sFamily = false;
                        familyYes = false;
                        currentFamily = esFamily.none;
                    }
                } else if (childrenYes) {
                    Dialogues.sayChildren();
                } else if (wellYes) {
                    Dialogues.sayWell();
                } else if (farmersYes) {
                    Dialogues.sayFarmers();
                } else if (ciaranYes) {
                    Dialogues.sayCiaran();
                }

                dialogueIsSaid = true;
            }
        }

    }

    void OnTriggerEnter(Collider other) {
        scenarioFamily(other);
        scenarioChildren(other);
        scenarioWell(other);
        scenarioFarmers(other);
        scenarioCiaran(other);

        if (other.gameObject.tag == "soDoor" && !soKeyUsed) {
            //Debug.Log("Door found!");
            isInRange = true;
            soDoor = true;
        }

        // Interface: popup notification to press "F" to interact
        if(isInRange) {
            NotificationsUI.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other) {
         
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "oBacon" || other.gameObject.tag == "oBeer" || (other.gameObject.tag == "soKey" && !soKeyFound)) {
            //Debug.Log("Family exited!");
            isInRange = false;
            sFamily = false;
            familyYes = false;
            currentFamily = esFamily.none;
        }

        if (other.gameObject.tag == "oMother" || other.gameObject.tag == "oBall" || other.gameObject.tag == "oDrawing" || other.gameObject.tag == "oSmudge") {
            //Debug.Log("exited!");
            isInRange = false;
            sChildren = false;
            childrenYes = false;
            currentChildren = esChildern.none;
        } 

        if (other.gameObject.tag == "oBucket" || other.gameObject.tag == "oWoman" || other.gameObject.tag == "oWell") {
            //Debug.Log("exited!");
            isInRange = false;
            sWell = false;
            wellYes = false;
            currentWell = esWell.none;
        } 

        if (other.gameObject.tag == "oSuspension" || other.gameObject.tag == "oPlaycards" || other.gameObject.tag == "oPeople") {
            //Debug.Log("exited!");
            isInRange = false;
            sFarmers = false;
            farmersYes = false;
            currentFarmers = esFarmers.none;
        } 

        if (other.gameObject.tag == "oDiary" || other.gameObject.tag == "oBread" || other.gameObject.tag == "soBook" || other.gameObject.tag == "soBurnedPaper" || other.gameObject.tag == "soShelves" || other.gameObject.tag == "soCoat" || other.gameObject.tag == "oChair" || other.gameObject.tag == "oPhoto") {
            //Debug.Log("exited!");
            isInRange = false;
            sCiaran = false;
            ciaranYes = false;
            currentCiaran = esCiaran.none;
        } 

        if (other.gameObject.tag == "soDoor") {
            //Debug.Log("left door!");
            isInRange = false;
            soDoor = false;
        }

        // Interface: popup notification to press "F" to interact - diasbled
        if (!isInRange) {
            NotificationsUI.SetActive(false);
        }
    }

    private void scenarioFamily(Collider other) {
        if (other.gameObject.tag == "oBacon") {
            isInRange = true;
            sFamily = true;
            familyYes = true;
            currentFamily = esFamily.bacon;
        } else if (other.gameObject.tag == "oBeer") {
            isInRange = true;
            sFamily = true;
            familyYes = true;
            currentFamily = esFamily.beer;
        } else if (other.gameObject.tag == "soKey") {
            isInRange = true;
            sFamily = true;
            familyYes = true;
            currentFamily = esFamily.key;
        }
    }

    private void scenarioChildren(Collider other) {
        if (other.gameObject.tag == "oMother") {
            isInRange = true;
            sChildren = true;
            childrenYes = true;
            currentChildren = esChildern.mother;
        } else if (other.gameObject.tag == "oBall") {
            isInRange = true;
            sChildren = true;
            childrenYes = true;
            currentChildren = esChildern.ball;
        } else if (other.gameObject.tag == "oDrawing") {
            isInRange = true;
            sChildren = true;
            childrenYes = true;
            currentChildren = esChildern.drawing;
        } else if (other.gameObject.tag == "oSmudge") {
            isInRange = true;
            sChildren = true;
            childrenYes = true;
            currentChildren = esChildern.smudge;
        }
    }

    private void scenarioWell(Collider other) {
        if (other.gameObject.tag == "oBucket") {
            isInRange = true;
            sWell = true;
            wellYes = true;
            currentWell = esWell.bucket;
        } else if (other.gameObject.tag == "oWoman") {
            isInRange = true;
            sWell = true;
            wellYes = true;
            currentWell = esWell.woman;
        } else if (other.gameObject.tag == "oWell") {
            isInRange = true;
            sWell = true;
            wellYes = true;
            currentWell = esWell.well;
        }
    }

    private void scenarioFarmers(Collider other) {
        if (other.gameObject.tag == "oSuspensions") {
            isInRange = true;
            sFarmers = true;
            farmersYes = true;
            currentFarmers = esFarmers.suspensions;
        } else if (other.gameObject.tag == "oPlaycards") {
            isInRange = true;
            sFarmers = true;
            farmersYes = true;
            currentFarmers = esFarmers.playcards;
        } else if (other.gameObject.tag == "oPeople") {
            isInRange = true;
            sFarmers = true;
            farmersYes = true;
            currentFarmers = esFarmers.people;
        }
    }

    private void scenarioCiaran(Collider other) {
        if (other.gameObject.tag == "oDiary") {
            isInRange = true;
            sCiaran = true;
            ciaranYes = true;
            currentCiaran = esCiaran.diary;
        } else if (other.gameObject.tag == "oBread") {
            isInRange = true;
            sCiaran = true;
            ciaranYes = true;
            currentCiaran = esCiaran.bread;
        } else if (other.gameObject.tag == "soBook") {
            isInRange = true;
            sCiaran = true;
            ciaranYes = true;
            currentCiaran = esCiaran.book;
        } else if (other.gameObject.tag == "soBurnedPaper") {
            isInRange = true;
            sCiaran = true;
            ciaranYes = true;
            currentCiaran = esCiaran.burnedPaper;
        } else if (other.gameObject.tag == "soShelves") {
            isInRange = true;
            sCiaran = true;
            ciaranYes = true;
            currentCiaran = esCiaran.shelves;
        } else if (other.gameObject.tag == "soCoat") {
            isInRange = true;
            sCiaran = true;
            ciaranYes = true;
            currentCiaran = esCiaran.coat;
        } else if (other.gameObject.tag == "oChair") {
            isInRange = true;
            sCiaran = true;
            ciaranYes = true;
            currentCiaran = esCiaran.chair;
        } else if (other.gameObject.tag == "oPhoto") {
            isInRange = true;
            sCiaran = true;
            ciaranYes = true;
            currentCiaran = esCiaran.drawing;
        }
    }

    private void whichScenario() {

        if (sFamily && !sFamilyFound) {
            sFamilyFound = true;
            // notification that there's a new entry in the notebook
            //Debug.Log("There's a new entry in the notebook!");
            newEntryImage.enabled = true;
            StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            // writing sound
        }

        if (sChildren && !sChildrenFound) {
            sChildrenFound = true;
            //Debug.Log("There's a new entry in the notebook!");
            newEntryImage.enabled = true;
            StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            // writing sound
        }

        if (sWell && !sWellFound) {
            sWellFound = true;
            //Debug.Log("There's a new entry in the notebook!");
            newEntryImage.enabled = true;
            StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            // writing sound
        }

        if (sFarmers && !sFarmersFound) {
            sFarmersFound = true;
            //Debug.Log("There's a new entry in the notebook!");
            newEntryImage.enabled = true;
            StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            // writing sound
        }

        if (sCiaran && !sCiaranFound) {
            sCiaranFound = true;
            //Debug.Log("There's a new entry in the notebook!");
            newEntryImage.enabled = true;
            StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            // writing sound
        }

    }

    private void whichObject() {

        if (currentFamily == esFamily.key && !soKeyFound) {
            soKeyFound = true;
            keyImage.enabled = true;
            Destroy(keyObject);

            if (!sFamilyFound) {
                sFamilyFound = true;
                //Debug.Log("There's a new entry in the notebook!");
                newEntryImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            } else {
                //Debug.Log("An entry in your Notebook has been updated!");
                updatedImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, updatedImage));
            }

            // writing sound
        }

        if (currentCiaran == esCiaran.book && !soBookFound) {
            soBookFound = true;

            if (!sCiaranFound) {
                sCiaranFound = true;
                //Debug.Log("There's a new entry in the notebook!");
                newEntryImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            } else {
                //Debug.Log("An entry in your Notebook has been updated!");
                updatedImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, updatedImage));
            }

            // writing sound
        }

        if (currentCiaran == esCiaran.burnedPaper && !soBurnedPaperFound) {
            soBurnedPaperFound = true;
            
            if (!sCiaranFound) {
                sCiaranFound = true;
                //Debug.Log("There's a new entry in the notebook!");
                newEntryImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            } else {
                //Debug.Log("An entry in your Notebook has been updated!");
                updatedImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, updatedImage));
            }

            // writing sound
        }

        if (currentCiaran == esCiaran.shelves && !soShelvesFound) {
            soShelvesFound = true;
            
            if (!sCiaranFound) {
                sCiaranFound = true;
                //Debug.Log("There's a new entry in the notebook!");
                newEntryImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            } else {
                //Debug.Log("An entry in your Notebook has been updated!");
                updatedImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, updatedImage));
            }

            // writing sound
        }

        if (currentCiaran == esCiaran.coat && !soCoatFound) {
            soCoatFound = true;
            
            if (!sCiaranFound) {
                sCiaranFound = true;
                //Debug.Log("There's a new entry in the notebook!");
                newEntryImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, newEntryImage));
            } else {
                //Debug.Log("An entry in your Notebook has been updated!");
                updatedImage.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, updatedImage));
            }

            // writing sound
        }

        if (soDoor && !soKeyUsed) {
            if (soKeyFound) {
                soKeyUsed = true;
                keyImage.enabled = false;
                //Debug.Log("Door unlocked!");
                doorOpened.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, doorOpened));
            } else {
                //Debug.Log("This door is locked.");
                doorLocked.enabled = true;
                StartCoroutine(RemoveAfterSeconds(3, doorLocked));
            }
        }

    }

    IEnumerator RemoveAfterSeconds (int seconds, Image obj){
        yield return new WaitForSeconds(seconds);
        obj.enabled = false;
    }

}
