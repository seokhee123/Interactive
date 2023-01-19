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

    public GameObject milk;
    public GameObject milkPos;
    bool isMilk = false;
    public GameObject juice;
    public GameObject juicePos;
    bool isJuice = false;

    public GameObject[] food;

    public GameObject dirtyGround;
    public GameObject clearSky;

    public GameObject bowlWater;

    public GameObject rabbit;
    bool isRabbit = false;
    public GameObject rabbitPos1;
    public GameObject rabbitPos2;
    public GameObject rabbitPos3;

    [SerializeField]
    public AnimationCurve curve1;
    public AnimationCurve curve2;

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
        yield return new WaitForSeconds(1f);
        isMilk = true;
        isJuice = true;
        yield return new WaitForSeconds(1f);
        StartCoroutine("Food");
    }

    IEnumerator Food()
    {
        for(int i = 0; i < food.Length; i++)
        {
            for (float f = 0f; f < 1; f += 0.02f)
            {
                Color c = food[i].GetComponent<SpriteRenderer>().color;
                c.a = f;
                food[i].GetComponent<SpriteRenderer>().color = c;
                yield return null;
            }
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine("Window");
    }

    IEnumerator Window()
    {
        for (float f = 0f; f < 1; f += 0.01f)
        {
            Color c = clearSky.GetComponent<SpriteRenderer>().color;
            c.a = f;
            clearSky.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine("Window2");
    }

    IEnumerator Window2() { 
        for (float t = 1f; t > 0; t -= 0.01f)
        {
            Color cc = dirtyGround.GetComponent<SpriteRenderer>().color;
            cc.a = t;
            dirtyGround.GetComponent<SpriteRenderer>().color = cc;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine("Bowl");
    }

    IEnumerator Bowl()
    {
        for (float t = 1f; t > 0; t -= 0.01f)
        {
            Color cc = bowlWater.GetComponent<SpriteRenderer>().color;
            cc.a = t;
            bowlWater.GetComponent<SpriteRenderer>().color = cc;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine("Rabbit");
    }

    IEnumerator Rabbit()
    {
        float duration = 1f;
        float time = 0.0f;
        Vector2 start = rabbit.transform.position;
        Vector2 end = rabbitPos1.transform.position;

        while (time < duration)
        {
            time += Time.deltaTime;
            float linearT = time / duration;
            float heightT = curve1.Evaluate(linearT);

            float height = Mathf.Lerp(0.0f, 2, heightT);

            rabbit.transform.position = Vector2.Lerp(start, end, linearT) + new Vector2(0.0f, height);

            yield return null;
        }
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
        if(isMilk == true)
        {
            milk.transform.position = Vector2.Lerp(milk.transform.position, milkPos.transform.position, 0.01f);
        }
        if (isJuice == true)
        {
            juice.transform.position = Vector2.Lerp(juice.transform.position, juicePos.transform.position, 0.01f);
        }
        if(isRabbit == true)
        {
            //rabbit.transform.position = Vector2.Lerp(rabbit.transform.position, rabbitPos1.transform.position, 0.01f);
        }
    }
}
