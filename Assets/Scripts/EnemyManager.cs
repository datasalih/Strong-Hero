using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using Unity;

public class EnemyManager : MonoBehaviour
{





    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {


       

            bool value = !anim.GetBool("Lifted");
            anim.SetBool("Lifted", value);
     
        

  




    }


}



