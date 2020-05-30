using UnityEngine;
using UnityEngine.UI;

public class CalculateMath : MonoBehaviour
{
    public GameObject theRangeScript;
    public GameObject theDisplay;

    //Function to check if the user has correct answer 
    public void Calculate()
    {
    
        float answer = float.Parse(gameObject.GetComponentInChildren<Text>().text);
        float result = theRangeScript.GetComponent<RangeScript>().getResult();
        Debug.Log(result);
        if(answer == result )
        {
            theDisplay.GetComponent<Text>().text = result + " and You are right! ";
            theDisplay.GetComponent<Text>().color = Color.green;
        
        }
        else
        {
            theDisplay.GetComponent<Text>().text = result + "and You are wrong! ";
            theDisplay.GetComponent<Text>().color = Color.red;
        }

    }
}
