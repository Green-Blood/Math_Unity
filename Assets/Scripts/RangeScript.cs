using UnityEngine;
using UnityEngine.UI;

public class RangeScript : MonoBehaviour
{
    #region Variables
    // Public variables
    string theInputText;
    public InputField theInputField;
    public GameObject theDisplay;
    public GameObject theRangeButton;
    public GameObject theRandomDisplay;
    public GameObject theEquation;
    public GameObject theAnswers;
    // Private varables
    int inputValue = 0;
    int value1 = 0;
    int value2 = 0;
    int equationRandom = 0;
    float result = 0;
    GameObject equationButton;
    #endregion
    
    //Function to store the range of the number 
    public void StoreRange()
    {
        //  Takes user input
        if(!string.IsNullOrEmpty(theInputField.text))
        {
            theInputText = theInputField.text;
            // Displays the range user have chose
            theDisplay.GetComponent<Text>().text = "The range is " + theInputText;
            
            // Convert user input to integer and show random number
            inputValue = int.Parse(theInputField.text);
            inputValue = Random.Range(1, inputValue);
            theRandomDisplay.GetComponent<Text>().text = "The random number is " + inputValue;
            
            // Deactivates the Range submit button 
            theRangeButton.SetActive(false);
            theEquation.SetActive(true);
            theAnswers.SetActive(true);
            theInputField.gameObject.SetActive(false);
            
            // Assignes random values to valu1 and value2 
            value1 = Random.Range(1, inputValue);
            value2 = Random.Range(1, inputValue);
            // Creates random operator
            equationRandom = Random.Range(0, 4);
            // Switch to assign random operators and get the result from it
            switch(equationRandom)
            {
                case 0:
                    theEquation.gameObject.transform.GetChild(1).GetComponentInChildren<Text>().text = "+";
                    result = value1 + value2;
                    break;
                case 1:
                    theEquation.gameObject.transform.GetChild(1).GetComponentInChildren<Text>().text = "-";
                    result = value1 - value2;
                    break;
                case 2:
                    theEquation.gameObject.transform.GetChild(1).GetComponentInChildren<Text>().text = "/";
                    result = value1 / value2;
                    break;
                case 3:
                    theEquation.gameObject.transform.GetChild(1).GetComponentInChildren<Text>().text = "*";
                    result = value1 * value2;
                    break;
            }
            // Assigns values to objects      
            theEquation.gameObject.transform.GetChild(0).GetComponentInChildren<Text>().text = value1.ToString(); 
            theEquation.gameObject.transform.GetChild(2).GetComponentInChildren<Text>().text = value2.ToString();
            // Assigns the result to object  
            for(int i =  0; i < theAnswers.gameObject.transform.childCount; i++)
            {
                if(i == equationRandom )
                {
                    theAnswers.gameObject.transform.GetChild(equationRandom).GetComponentInChildren<Text>().text = result.ToString();
                }
                else
                {
                    theAnswers.gameObject.transform.GetChild(i).GetComponentInChildren<Text>().text = Random.Range(0, inputValue).ToString();
                }
            } 
        }
        else
        {
            //Error check
            theDisplay.GetComponent<Text>().text = "Please put a number.";
            theDisplay.GetComponent<Text>().color = Color.red;            
        }
    }
    
    // Get function
    public float getResult()
    {
        return result; 
    }


}
