using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFactory : MonoBehaviour, IFactory {

    [SerializeField]
    GameObject redWave;
    [SerializeField]
    GameObject blueWave;

    const int BLUE = 0;
    const int RED = 1;

    public GameObject FactoryMethod(object[] parameters)
    {
        GameObject mainObject = null ;
        if((int) parameters[0] == BLUE)
        {
            mainObject = Instantiate(blueWave, new Vector3(transform.position.x, -2.96374f, transform.position.z) + new Vector3(0, 0, 1), Quaternion.identity);
        } else if((int) parameters[0] == RED){
            mainObject = Instantiate(redWave, new Vector3(transform.position.x, -2.96374f, transform.position.z) + new Vector3(0, 0, 1), Quaternion.identity);
        }

        return mainObject;
    }


}
