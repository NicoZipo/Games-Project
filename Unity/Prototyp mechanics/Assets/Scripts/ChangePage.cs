using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePage : MonoBehaviour
{
    
    private bool openedAgain = false;

// deklaration of things present in the notebookUI
    public Image oldImage;
    public Sprite[] spritesNotes;
    private short notesNum;

    public Sprite mission;
    public Sprite[] spritesMaps;

    public Image noScenarioImage;
    public Sprite[] spritesScenarios1;

    public Image soKeyImage;
    public Image soBookImage;
    public Image soBurnedPaperImage;
    public Image soShelvesImage;
    public Image soCoatImage;

    public Image noMissionImage;
    public Sprite[] spritesMissions1;

    public GameObject buttonNotes;
    public GameObject buttonMission;
    public GameObject buttonMap;

    public GameObject buttonRightNotes;
    public GameObject buttonLeftNotes;
    private bool outerRightNotes = false;
    private bool outerLeftNotes = true;

    public GameObject buttonOrsus;
    public GameObject buttonVicina;
    public GameObject buttonKonostedt;
    public GameObject buttonCastra;
    public GameObject buttonCastle;

    public Image mapOrsusImage;
    // these are for the next semester:
    public Image mapVicinaImage;
    public Image mapKonostedtImage;
    public Image mapCastraImage;
    public Image mapCastleImage;
    //

    private bool mapInVicina = false;
    private bool mapInKonostedt = false;
    private bool mapInCastra = false;
    private bool mapInCastle = false;

// deklaration of Scenarios1 and Objects in Level1, as well as Quests
// i forgot if i even need them oops
    public enum Scenarios1 {
        sFamily,
        sChildren,
        sWell,
        sFarmers,
        sCiaran
    }

    public enum ImportantObjects1 {
        soKey,
        soBook,
        soBurnedPaper,
        soShelves,
        soCoat
    }

/* @Laura */
// variables for the quests! i need those too, so I created them already :D
    private short questNum = 0;
//

    void Start() {
        notesNum = 0;
        noScenarioImage.enabled = false;
        disableMapImages();
        disableObjectImages();
        goToMission();
    }

    void Update() {
        if (CanvasMenus.openNotebookAgain) {
            goToMission();
            CanvasMenus.openNotebookAgain = false;
            openedAgain = true;
            notesNum = 0;
        }
    }

    public void turnRightNotes() {

        if (openedAgain) {
            outerRightNotes = false;
            buttonLeftNotes.SetActive(true);
            openedAgain = false;
        }

        noScenarioImage.enabled = false;
        disableObjectImages();

        if (outerLeftNotes) {
            buttonLeftNotes.SetActive(true);
            outerLeftNotes = false;
        }

        if (!outerRightNotes) {
            notesNum++; 
        }

        if (notesNum == spritesNotes.Length - 1 && !outerRightNotes)
        {
            buttonRightNotes.SetActive(false);
            outerRightNotes = true;
        }

        oldImage.sprite = spritesNotes[notesNum];
        noteDownScenario();
        noteDownImportantObjects();
        
        
    }

    public void turnLeftNotes() {

        noScenarioImage.enabled = false;
        disableObjectImages();

        if (outerRightNotes) {
            buttonRightNotes.SetActive(true);
            outerRightNotes = false;
        }

        if (!outerLeftNotes) {
            notesNum--; 
        }

        if (notesNum == 0 && !outerLeftNotes)
        {
            buttonLeftNotes.SetActive(false);
            outerLeftNotes = true;
        }

        oldImage.sprite = spritesNotes[notesNum];  
        noteDownScenario();
        noteDownImportantObjects();

    }

    public void goToMission() {
        notesNum = 0;
        noScenarioImage.enabled = false;
        disableObjectImages();
        disableMapImages();

        noMissionImage.enabled = true;

        buttonMission.SetActive(false);
        buttonMap.SetActive(true);
        buttonNotes.SetActive(true);

        buttonLeftNotes.SetActive(false);
        buttonRightNotes.SetActive(false);

        buttonOrsus.SetActive(false);
        buttonVicina.SetActive(false);
        buttonKonostedt.SetActive(false);
        buttonCastra.SetActive(false);
        buttonCastle.SetActive(false);

        oldImage.sprite = mission;

        openedAgain = true;
        notesNum = 0;
    }

    public void goToNotes() {
        // in the next semester i'll have to add extra tabs for the notes for the other levels!
        // I'm too lazy to do that now lol
        notesNum = 0;

        noMissionImage.enabled = false;
        disableObjectImages();
        disableMapImages();

        noScenarioImage.enabled = false;
        noteDownScenario();
        noteDownImportantObjects();

        buttonMission.SetActive(true);
        buttonMap.SetActive(true);
        buttonNotes.SetActive(false);

        buttonOrsus.SetActive(false);
        buttonVicina.SetActive(false);
        buttonKonostedt.SetActive(false);
        buttonCastra.SetActive(false);
        buttonCastle.SetActive(false);
        
        buttonRightNotes.SetActive(true);
        buttonLeftNotes.SetActive(false);
        oldImage.sprite = spritesNotes[notesNum];

    }

    public void goToMap() {
        notesNum = 0;
        noScenarioImage.enabled = false;
        disableObjectImages();
        disableMapImages();

        noMissionImage.enabled = false;

        buttonMission.SetActive(true);
        buttonMap.SetActive(false);
        buttonNotes.SetActive(true);

        buttonOrsus.SetActive(true);
        buttonVicina.SetActive(true);
        buttonKonostedt.SetActive(true);
        buttonCastra.SetActive(true);
        buttonCastle.SetActive(true);

        buttonLeftNotes.SetActive(false);
        buttonRightNotes.SetActive(false);

        mapOrsus();

        openedAgain = true;
        notesNum = 0;
    }

    public void mapOrsus() {
        buttonOrsus.SetActive(false);

        if (mapInVicina) {
            buttonVicina.SetActive(true);
        } else {
            buttonVicina.SetActive(false);
        }
        if (mapInKonostedt) {
            buttonKonostedt.SetActive(true);
        } else {
            buttonKonostedt.SetActive(false);
        }
        if (mapInCastra) {
            buttonCastra.SetActive(true);
        } else {
            buttonCastra.SetActive(false);
        }
        if (mapInCastle) {
            buttonCastle.SetActive(true);
        } else {
            buttonCastle.SetActive(false);
        }

        disableMapImages();
        mapOrsusImage.enabled = true;

        oldImage.sprite = spritesMaps[0];

        openedAgain = true;
        notesNum = 0;
    }

    public void mapVicina() {
        buttonOrsus.SetActive(true);

        if (mapInVicina) {
            buttonVicina.SetActive(false);
        }
        if (mapInKonostedt) {
            buttonKonostedt.SetActive(true);
        } else {
            buttonKonostedt.SetActive(false);
        }
        if (mapInCastra) {
            buttonCastra.SetActive(true);
        } else {
            buttonCastra.SetActive(false);
        }
        if (mapInCastle) {
            buttonCastle.SetActive(true);
        } else {
            buttonCastle.SetActive(false);
        }

        disableMapImages();
        if (InteractWithObjects.mapVicinaFound) {
            mapVicinaImage.enabled = true;
        }

        oldImage.sprite = spritesMaps[1];

        openedAgain = true;
        notesNum = 0;
    }

    public void mapKonostedt() {
        buttonOrsus.SetActive(true);

        if (mapInVicina) {
            buttonVicina.SetActive(true);
        } else {
            buttonVicina.SetActive(false);
        }
        if (mapInKonostedt) {
            buttonKonostedt.SetActive(false);
        }
        if (mapInCastra) {
            buttonCastra.SetActive(true);
        } else {
            buttonCastra.SetActive(false);
        }
        if (mapInCastle) {
            buttonCastle.SetActive(true);
        } else {
            buttonCastle.SetActive(false);
        }

        disableMapImages();
        if (InteractWithObjects.mapKonostedtFound) {
            mapKonostedtImage.enabled = true;
        }

        oldImage.sprite = spritesMaps[2];

        openedAgain = true;
        notesNum = 0;
    }

    public void mapCastra() {
        buttonOrsus.SetActive(true);

        if (mapInVicina) {
            buttonVicina.SetActive(true);
        } else {
            buttonVicina.SetActive(false);
        }
        if (mapInKonostedt) {
            buttonKonostedt.SetActive(true);
        } else {
            buttonKonostedt.SetActive(false);
        }
        if (mapInCastra) {
            buttonCastra.SetActive(false);
        }
        if (mapInCastle) {
            buttonCastle.SetActive(true);
        } else {
            buttonCastle.SetActive(false);
        }

        disableMapImages();
        if (InteractWithObjects.mapCastraFound) {
            mapCastraImage.enabled = true;
        }

        oldImage.sprite = spritesMaps[3];

        openedAgain = true;
        notesNum = 0;
    }

    public void mapCastle() {
        buttonOrsus.SetActive(true);

        if (mapInVicina) {
            buttonVicina.SetActive(true);
        } else {
            buttonVicina.SetActive(false);
        }
        if (mapInKonostedt) {
            buttonKonostedt.SetActive(true);
        } else {
            buttonKonostedt.SetActive(false);
        }
        if (mapInCastra) {
            buttonCastra.SetActive(true);
        } else {
            buttonCastra.SetActive(false);
        }
        if (mapInCastle) {
            buttonCastle.SetActive(false);
        }

        disableMapImages();
        if (InteractWithObjects.mapCastleFound) {
            mapCastleImage.enabled = true;
        }

        oldImage.sprite = spritesMaps[4];

        openedAgain = true;
        notesNum = 0;
    }

    private void disableMapImages() {
        mapOrsusImage.enabled = false;
        mapVicinaImage.enabled = false;
        mapKonostedtImage.enabled = false;
        mapCastraImage.enabled = false;
        mapCastleImage.enabled = false;
    }

    private void noteDownScenario() {
        if (notesNum == 0 && InteractWithObjects.sFamilyFound) {
            noScenarioImage.enabled = true;
            noScenarioImage.sprite = spritesScenarios1[0];
        } else if (notesNum == 1 && InteractWithObjects.sFarmersFound) {
            noScenarioImage.enabled = true;
            noScenarioImage.sprite = spritesScenarios1[1];
        } else if (notesNum == 2 && InteractWithObjects.sWellFound) {
            noScenarioImage.enabled = true;
            noScenarioImage.sprite = spritesScenarios1[2];
        } else if (notesNum == 3 && InteractWithObjects.sChildrenFound) {
            noScenarioImage.enabled = true;
            noScenarioImage.sprite = spritesScenarios1[3];
        } else if (notesNum == 4 && InteractWithObjects.sCiaranFound) {
            noScenarioImage.enabled = true;
            noScenarioImage.sprite = spritesScenarios1[4];
        }
    }

    private void noteDownImportantObjects() {
        if (notesNum == 0 && InteractWithObjects.soKeyFound) {
            soKeyImage.enabled = true;
        }
        if (notesNum == 4 && InteractWithObjects.soBookFound) {
            soBookImage.enabled = true;
        }
        if (notesNum == 4 && InteractWithObjects.soBurnedPaperFound) {
            soBurnedPaperImage.enabled = true;
        }
        if (notesNum == 4 && InteractWithObjects.soShelvesFound) {
            soShelvesImage.enabled = true;
        } 
        if (notesNum == 4 && InteractWithObjects.soCoatFound) {
            soCoatImage.enabled = true;
        }
    }

    private void disableObjectImages() {
        soKeyImage.enabled = false;
        soBookImage.enabled = false;
        soBurnedPaperImage.enabled = false;
        soShelvesImage.enabled = false;
        soCoatImage.enabled = false;
    }



/* @Laura */
// function to progress with the quests!
// quests should be:
    // written into the notebook (you just have to call my "noteDownQuests()" function below :D)
    // said by Yakub (Monologue-like) (you can use the Canvas->Panel "Dialogues" that I already created for that, that should work just fine!) (I can explain how the canvases work to you, if you want)
// quests that have the point of looking around at a scenario are completed as soon as the player inspected 1 object of the scenario
    // exception! quest 2 is only completed, when 1 object of the second scenario (the farmers) has been inspected
// we have 6 quests in total -> see "Timeshift - 1. Level" Docs "Storyverlauf"
    public void questProgression() {

    }

    private void noteDownQuests() {
        if (questNum == 0) {
            noMissionImage.sprite = spritesMissions1[0];
        } else if (questNum == 1) {
            noMissionImage.sprite = spritesMissions1[1];
        } else if (questNum == 2) {
            noMissionImage.sprite = spritesMissions1[2];
        } else if (questNum == 3) {
            noMissionImage.sprite = spritesMissions1[3];
        } else if (questNum == 4) {
            noMissionImage.sprite = spritesMissions1[4];
        }
    }

    
}
