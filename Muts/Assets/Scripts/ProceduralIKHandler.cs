using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralIKHandler : MonoBehaviour
{
    //BicycleController bicycleController;
    //CyclistAnimController cyclistAnimController;
    //GameObject hipIKTarget, chestIKTarget, headIKTarget;
    //public Vector2 chestIKRange, hipIKRange, headIKRange;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    bicycleController = transform.root.GetComponent<BicycleController>();
    //    cyclistAnimController = transform.GetComponent<CyclistAnimController>();

    //    hipIKTarget = cyclistAnimController.hipIK.GetComponent<MultiParentConstraint>().data.sourceObjects[0].transform.gameObject;
    //    chestIKTarget = cyclistAnimController.chestIK.GetComponent<TwoBoneIKConstraint>().data.target.gameObject;
    //    headIKTarget = cyclistAnimController.headIK.GetComponent<MultiAimConstraint>().data.sourceObjects[0].transform.gameObject;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public GameObject hipIKTarget, chestIKTarget, headIKTarget;
    public Vector2 chestIKRange, hipIKRange, headIKRange;

    private Animator anim;
    BicycleStatus bicycleStatus;

    private void Start()
    {
        bicycleStatus = FindObjectOfType<BicycleStatus>();
        anim = GetComponent<Animator>();
        //if (bicycleStatus != null) 
            //onOffBike = bicycleStatus.onBike;
    }
    private void OnEnable()
    {
        if(bicycleStatus)
        {

        }
    }
}
