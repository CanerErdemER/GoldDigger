using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookMovementController : MonoBehaviour
{
    [SerializeField]
    float min_z = -50f, max_z = 50f;//kanca hareket derece sýnýrlandýrmasý
    [SerializeField]
    float rotationSpeed;

    float rotationAngle;

    bool isTurnRight;
    bool isitTurnable;//maus týklandýgýnda dönmenin durmnasý için kod(variable to stop spinnig when mouse clicked)

    [SerializeField]
    float fallingSpeed=3f;
    float startSpeed;

    ropeRenderer rr;

    [SerializeField]
    float min_y = -40f;
    float startPos_y;
    bool goDown;
    private void Awake()
    {
        rr = GetComponent<ropeRenderer>();
    }
    private void Start()
    {
        startPos_y=transform.position.y;
        startSpeed = fallingSpeed;
        isitTurnable=true;
    }
    private void Update()
    {
        rotateFNC();
        mousePressedFNC();
        hookMoveFNC();
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

    void mousePressedFNC()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isitTurnable)
            {
             isitTurnable=false;
             goDown=true;

            }
        }
    }

    void hookMoveFNC()
    {
        if (isitTurnable)
            return;
        if (!isitTurnable)
        {
            Vector3 temp = transform.position;
            if (goDown)
            {
                temp -= transform.up * Time.deltaTime * fallingSpeed;

            }
            else
            {
                temp += transform.up * Time.deltaTime * fallingSpeed;
                
            }
            transform.position = temp;

            if (temp.y <= min_y)
            {
                goDown=false;
            }
            if (temp.y >= startPos_y)
            {
                isitTurnable=true;
                fallingSpeed = startSpeed;
                
            }
            rr.showRopeFNC(temp, true);//Hook ile startPos arasý ipi uzatan fonksiyon
        }
    }
}
