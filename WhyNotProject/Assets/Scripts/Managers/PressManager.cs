using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        throw new System.InvalidOperationException($"{transform.name} 에서 잘못된 호출.");
    }

}
