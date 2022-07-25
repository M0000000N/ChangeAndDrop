//using System.Collections;
//using UnityEngine;

//public class CyclistAnimController : MonoBehaviour
//{
//    BicycleController bicycleController;
//    Animator anim;
//    string clipInfoCurrent, clipInfoLast;

//    public float speed;
//    public GameObject hipIK, chestIK, leftFootIK, leftFootIdleIK, headIK;
//    BicycleStatus bicycleStatus;
//    bool onOffBike;

//    public GameObject cyclist;
//    public GameObject externalCharacter;

//    float waitTime, prevLocalPosX;


//    void Start()
//    {
//        bicycleController = FindObjectOfType<BicycleController>();
//        bicycleStatus = FindObjectOfType<BicycleStatus>();
//        if (bicycleStatus != null)
//            onOffBike = bicycleStatus.onBike;
//        if (cyclist != null)
//            cyclist.SetActive(bicycleStatus.onBike);
//        if (externalCharacter != null)
//            externalCharacter.SetActive(!bicycleStatus.onBike);// why?
//        anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (cyclist != null && externalCharacter != null)
//        {
//            if (Input.GetKeyDown(KeyCode.Return) && bicycleController.transform.InverseTransformDirection(bicycleController.Rigidbody.velocity).z <= 0.1f)
//            {
//                externalCharacter.transform.position = cyclist.transform.root.position - transform.right * 0.5f + transform.forward * 0.1f;
//                bicycleStatus.onBike = !bicycleStatus.onBike;
//                if (bicycleStatus.onBike)
//                {
//                    if (prevLocalPosX < 0)
//                        anim.Play("OnBike");
//                    else
//                        anim.Play("OnBikeFlipped");
//                    StartCoroutine(AdjustRigWeight(0));
//                }
//                else
//                {
//                    anim.Play("OffBike");
//                    StartCoroutine(AdjustRigWeight(1));
//                }
//            }
//            prevLocalPosX = externalCharacter.transform.localPosition.x;
//        }
//        waitTime -= Time.deltaTime;
//        waitTime = Mathf.Clamp(waitTime, 0, 1.5f);


//        speed = bicycleController.transform.InverseTransformDirection(bicycleController.rb.velocity).z;
//        anim.SetFloat("Speed", speed);
//        if (bicycleStatus != null)
//        {
//            if (bicycleStatus.dislodged == false)
//            {
//                if (bicycleStatus.onBike)
//                {
//                    clipInfoCurrent = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
//                    if (clipInfoCurrent == "IdleToStart" && clipInfoLast == "Idle")
//                        StartCoroutine(LeftFootIK(0));
//                    if (clipInfoCurrent == "Idle" && clipInfoLast == "IdleToStart")
//                        StartCoroutine(LeftFootIK(1));
//                    if (clipInfoCurrent == "Idle" && clipInfoLast == "Reverse")
//                        StartCoroutine(LeftFootIdleIK(0));
//                    if (clipInfoCurrent == "Reverse" && clipInfoLast == "Idle")
//                        StartCoroutine(LeftFootIdleIK(1));

//                    clipInfoLast = clipInfoCurrent;
//                }
//            }
//            else
//            {
//                cyclist.SetActive(false);
//                if (Input.GetKeyDown(KeyCode.R))
//                {
//                    cyclist.SetActive(true);
//                    bicycleStatus.dislodged = false;
//                }
//            }
//        }
//        else
//        {
//            if (!bicycleController.isAirborne)
//            {
//                clipInfoCurrent = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
//                if (clipInfoCurrent == "IdleToStart" && clipInfoLast == "Idle")
//                    StartCoroutine(LeftFootIK(0));
//                if (clipInfoCurrent == "Idle" && clipInfoLast == "IdleToStart")
//                    StartCoroutine(LeftFootIK(1));
//                if (clipInfoCurrent == "Idle" && clipInfoLast == "Reverse")
//                    StartCoroutine(LeftFootIdleIK(0));
//                if (clipInfoCurrent == "Reverse" && clipInfoLast == "Idle")
//                    StartCoroutine(LeftFootIdleIK(1));

//                clipInfoLast = clipInfoCurrent;
//            }
//        }
//    }

//    IEnumerator AdjustRigWeight(int offset)
//    {
//        StartCoroutine(LeftFootIK(1));
//        if (offset == 0)
//        {
//            cyclist.SetActive(true);
//            externalCharacter.SetActive(false);
//        }
//        float t1 = 0f;
//        while (t1 <= 1f)
//        {
//            t1 += Time.deltaTime;
//            rig.weight = Mathf.Lerp(-0.05f, 1.05f, Mathf.Abs(offset - t1));
//            yield return null;
//        }
//        if (offset == 1)
//        {
//            yield return new WaitForSeconds(0.2f);
//            cyclist.SetActive(false);
//            externalCharacter.SetActive(true);
//            // Matching position and rotation to the best possible transform to get a seamless transition
//            externalCharacter.transform.position = cyclist.transform.root.position - transform.right * 0.5f + transform.forward * 0.1f;
//            externalCharacter.transform.rotation = Quaternion.Euler(externalCharacter.transform.rotation.eulerAngles.x, cyclist.transform.root.rotation.eulerAngles.y + 80, externalCharacter.transform.rotation.eulerAngles.z);
//        }

//    }
//    IEnumerator LeftFootIK(int offset)
//    {
//        float t1 = 0f;
//        while (t1 <= 1f)
//        {
//            t1 += Time.fixedDeltaTime;
//            leftFootIK.GetComponent<TwoBoneIKConstraint>().weight = Mathf.Lerp(-0.05f, 1.05f, Mathf.Abs(offset - t1));
//            leftFootIdleIK.GetComponent<TwoBoneIKConstraint>().weight = 1 - leftFootIK.GetComponent<TwoBoneIKConstraint>().weight;
//            yield return null;
//        }

//    }
//    IEnumerator LeftFootIdleIK(int offset)
//    {
//        float t1 = 0f;
//        while (t1 <= 1f)
//        {
//            t1 += Time.fixedDeltaTime;
//            leftFootIdleIK.GetComponent<TwoBoneIKConstraint>().weight = Mathf.Lerp(-0.05f, 1.05f, Mathf.Abs(offset - t1));
//            yield return null;
//        }

//    }
//}
