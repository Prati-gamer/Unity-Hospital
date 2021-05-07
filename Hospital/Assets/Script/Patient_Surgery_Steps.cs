using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Patient_Surgery_Steps : MonoBehaviour
{
    public TextMeshProUGUI largeText;

    private void PickRandomFromSteps()
    {
        string[] steps = new string[] { "Physician clearance", "Informed Consent signed", "Patient verification", "Dressed for operation room", "Surgical checklist", "Based on the  type of anethesia, preopeye cleaning need to done", "Intill betadine drops and Sent him/her to OR" };
        string randomSteps = steps[Random.Range(0, steps.Length)];
        largeText.text = randomSteps;
    }

    private void Awake()
    {
        PickRandomFromSteps();
    }
}

