using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LuzParpadeo : MonoBehaviour 
{ 
    public bool titila = false;
    public float timeDelay;
    void Update() 
    { 
        if (titila == false)
        { 
            StartCoroutine(LuzQueTitila()); 
        }
    } 
    IEnumerator LuzQueTitila()
    { 
        titila = true;
        this.gameObject.GetComponent<Light>().enabled = false; 
        timeDelay = Random.Range(0.1f, 0.4f);
        yield return new WaitForSeconds(timeDelay); 
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.1f, 0.4f); yield return new WaitForSeconds(timeDelay);
        titila = false; 
    }
}