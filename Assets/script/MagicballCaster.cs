using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicballCaster : MonoBehaviour
{

    public Magicball magicballPrefab;
    public Transform magicballSourceTransform;
    
     private void Update()
    {
        if   (Input.GetMouseButtonDown(0))
        {
            Instantiate(magicballPrefab, magicballSourceTransform.position, magicballSourceTransform.rotation);
           
        }

    }
}
