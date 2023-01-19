using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ref1;
    public GameObject ref2;
    public GameObject ref3;
    public GameObject[] refObj;

    public GameObject melon;
    public GameObject melonPos;
    public GameObject melonPos2;
    bool isMelon = false;
    public GameObject melonPlate;
    public GameObject melonPlatePos;
    public GameObject under1;
    public GameObject under1Pos;
    public GameObject under2;
    public GameObject under2Pos;
    public GameObject watermelon;
    public GameObject watermelonPos;
    public GameObject watermelonPos2;
    bool isWatermelon = false;

    void Start()
    {
        StartCoroutine("GameStart");
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        ref1.SetActive(false);
        ref2.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine("Ref1");
    }

    IEnumerator Ref1()
    {
        ref2.SetActive(false);
        ref3.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine("EndRef");
    }

    IEnumerator EndRef()
    {
        ref3.SetActive(false);
        for(int i =0; i < refObj.Length; i++)
        {
            refObj[i].SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine("Melon");
    }

    IEnumerator Melon()
    {
        melon.transform.position = Vector2.Lerp(melon.transform.position, melonPos.transform.position, 1f);
        melonPlate.transform.position = Vector2.Lerp(melonPlate.transform.position, melonPlatePos.transform.position, 1f);
        under1.transform.position = Vector2.Lerp(under1.transform.position, under1Pos.transform.position, 1f);
        under2.transform.position = Vector2.Lerp(under2.transform.position, under2Pos.transform.position, 1f);
        watermelon.transform.position = Vector2.Lerp(watermelon.transform.position, watermelonPos.transform.position, 1f);
        yield return new WaitForSeconds(1f);
        isMelon = true;
        isWatermelon = true;
    }

    private void Update()
    {
        if(isMelon == true)
        {
            melon.transform.position = Vector2.Lerp(melon.transform.position, melonPos2.transform.position, 0.01f);
        }
        if(isWatermelon == true)
        {
            watermelon.transform.position = Vector2.Lerp(watermelon.transform.position, watermelonPos2.transform.position, 0.01f);
        }
    }
}
