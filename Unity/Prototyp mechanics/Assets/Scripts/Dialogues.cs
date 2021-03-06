using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using DialogueNamespace;

public class Dialogues : MonoBehaviour
{

    // Instance of this class
    public static Dialogues dialoguesInstance;

    //public static Text _dialogueText;
    //public static Image _dialogueImage;
    //public static Text _pressF;
    //public static GameObject _DialogueUI;

    public Text dialogueText;
    //public  Image dialogueImage;
    //public Text pressF;
    public GameObject DialogueUI;

    public static bool dialogueIsOpen = false;

    private short init;

    void Start() {
        //init = 1;
        //Debug.Log(init);
        dialoguesInstance = this;

        //_dialogueText = dialogueText;
        //_dialogueImage = dialogueImage;
        //_pressF = pressF;
        //_DialogueUI = DialogueUI;

        DialogueUI.SetActive(false);
        //dialogueImage.enabled = false;
        dialogueText.enabled = false;
        //pressF.enabled = false;
    }

    void Update() {

        if (dialogueIsOpen) {

            if (Input.GetKeyDown(KeyCode.F)) {
                //dialogueImage.enabled = false;
                dialogueText.enabled = false;
                //pressF.enabled = false;
                DialogueUI.SetActive(false);
                dialogueIsOpen = false;

                Time.timeScale = 1;
            }

        }

    }

    public void sayFamily() {
        //Debug.Log("Family Dialogue");
        //Debug.Log(InteractWithObjects.currentFamily);
        //_dialogueText.GetComponent<Text>().text = "This is a family object!";

        if (InteractWithObjects.currentFamily == esFamily.key) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "I grabbed the Key!";
            dialogueIsOpen = true;
            //Debug.Log("The Key!");
        } else if (InteractWithObjects.currentFamily == esFamily.bacon) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "I found the bacon!";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentFamily == esFamily.beer) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "I found the beer!"; // it's working :DDDDD me happyyy
            dialogueIsOpen = true;
        }

        setVisible();
    }

    public void sayChildren() {
        if (InteractWithObjects.currentChildren == esChildern.mother) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "Alice??? It eases my heart that at least she can stay close to her children. With all of them frozen in time together, they seem closer than my heart has felt to anyone ever since.";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentChildren == esChildern.ball) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "Ah, I still remember when mother wove that ball. The children???s beaming faces as they received the gift are ingrained in my mind to this day - as well as mother???s sparkling eyes...";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentChildren == esChildern.drawing) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "A drawing of me, Henry and Cateline. We are unrecognizable, nevertheless had we plenty of fun creating it. I am amazed, as how it is still undamaged like this.";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentChildren == esChildern.smudge) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "Ah, Henry has always been a very clumsy one, with so much enthusiasm. ... I can???t help but harbor concern for if these children will ever be able to lead a careless life again, for if there even will be time again for them to keep living???";
            dialogueIsOpen = true;
        }

        setVisible();
    }

    public void sayWell() {
        if (InteractWithObjects.currentWell == esWell.bucket) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "I found a bucket!";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentWell == esWell.woman) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "I know this woman!";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentWell == esWell.well) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "I don't like this well.";
            dialogueIsOpen = true;
        }

        setVisible();
    }

    public void sayFarmers() {
        if (InteractWithObjects.currentFarmers == esFarmers.suspensions) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "I found the suspensions!";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentFarmers == esFarmers.playcards) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "I found playcards!";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentFarmers == esFarmers.people) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "Ah, here are the farmers!";
            dialogueIsOpen = true;
        }

        setVisible();
    }

    public void sayCiaran() {
       if (InteractWithObjects.currentCiaran == esCiaran.diary) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "Oh, a diary! hehehehe";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentCiaran == esCiaran.bread) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "That's some tasty looking bread!";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentCiaran == esCiaran.book) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "In this book there's a ripped out page?";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentCiaran == esCiaran.burnedPaper) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "There's some burned paper in the oven.";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentCiaran == esCiaran.shelves) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "Ciaran???s shelves are full to the brink. That is odd, it must be a good season for him. I am glad.";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentCiaran == esCiaran.coat) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "That coat??? It looks similar to the ones those strange people from just before have worn too.";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentCiaran == esCiaran.chair) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "Ciaran??? he hasn???t been the same ever since. Always mentally absent, no driving force. He has been getting better lately. Something must have changed.";
            dialogueIsOpen = true;
        } else if (InteractWithObjects.currentCiaran == esCiaran.drawing) {
            Time.timeScale = 0;
            dialogueText.GetComponent<Text>().text = "She was still so young...";
            dialogueIsOpen = true;
        }

        setVisible();
    }

    private void setVisible() {
        //dialogueImage.enabled = true;
        dialogueText.enabled = true;
        //pressF.enabled = true;
        DialogueUI.SetActive(true);
        //Debug.Log("set visible");
    }

}
