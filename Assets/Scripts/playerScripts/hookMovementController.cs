using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookMovementController : MonoBehaviour
{
    [SerializeField]
    float min_z = -50f, max_z = 50f;//kanca hareket derece s�n�rland�rmas�
    [SerializeField]
    float rotationSpeed;

    float rotationAngle;

    bool isTurnRight;
    bool isitTurnable;//maus t�kland�g�nda d�nmenin durmnas� i�in kod(variable to stop spinnig when mouse clicked)
    private void Start()
    {
        isitTurnable=true;
    }
    private void Update()
    {
        rotateFNC();
    }

    void rotateFNC()
    {
        if (!isitTurnable)
            return;
        if (isTurnRight)
        {
            rotationAngle += rotationSpeed * Time.deltaTime;
        }
        else
        {
            rotationAngle -= rotationSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        if (rotationAngle >= max_z)
        {
            isTurnRight=false;
        }
        else if(rotationAngle < min_z)
        {
            isTurnRight=true;
        }
      
    }
}
