using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour {

    private GameObject objectHit;
    private GameObject objectGrabbed;

    public Text displayText;
    public Text letterText;
    public TextAsset fileText;

    private void Start()
    {
        displayText.text = "";
        letterText.text = "";
    }

    // Update is called once per frame
    void Update () {
        
        // When mouse button is clicked down
        if (Input.GetMouseButtonDown(0))
        {
            // Check to see if the mouse clicked on one of the symbols
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                objectGrabbed = hit.collider.gameObject;
                if (objectGrabbed.name != "bucket")
                {
                    setLetterText(objectGrabbed.name);
                    setWordText("");
                    // Play Letter Sound
                    FindObjectOfType<AudioPlayer>().PlaySound(objectGrabbed.name);
                }
            }
        }
        // When mouse button is released
        if(Input.GetMouseButtonUp(0))
        {
            // Check to see if the mouse is let go on the bucket
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                objectHit = hit.collider.gameObject;
                if(objectHit.name == "bucket")
                {
                    setWordText(objectGrabbed.name);
                }
                else
                {
                    setLetterText("");
                }
            }
        }
	}

    // Sets the display word using a text file
    void setWordText(string letter)
    {
        if (!string.IsNullOrEmpty(letter))
        {
            int index = System.Convert.ToChar(letter) - 64;
            string[] fileContent = getTextFile();
            displayText.text = fileContent[index-1];
            // Play the corresponding sound
        }
        else
        {
            displayText.text = "";
        }
    }

    // Get the contents of the Text file 
    string[] getTextFile()
    {
        string[] content = fileText.text.Split('\n');
        return content;
    }
    
    // Sets the letter that is currently being held
    void setLetterText(string letter)
    {
        letterText.text = letter;
    }
}
