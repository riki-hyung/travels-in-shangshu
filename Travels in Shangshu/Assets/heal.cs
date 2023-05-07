using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    public void Grab(GameObject charObject)
    {
        transform.position = new Vector3(1000000,0,0);
        Destroy(this.gameObject, 2);
    }
}
