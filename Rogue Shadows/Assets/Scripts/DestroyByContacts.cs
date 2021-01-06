using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContacts : MonoBehaviour
{
    bool flag;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            flag = true;
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);    
    }   
}
