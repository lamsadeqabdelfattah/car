using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseManager : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {



    }

    public void lose()
    {
        StartCoroutine(losegm());

    }
  IEnumerator losegm()
    {
        FindObjectOfType<RCC_CarControllerV3>().gameObject.GetComponent<RCC_CarControllerV3>().SetEngine(false);
        GameObject[] gate = GameObject.FindGameObjectsWithTag("Gate");
        for(int i=0;i<gate.Length;i++)
        gate[i].SetActive(false);
        SoundManager.instance.Play("fail");
        yield return new WaitForSeconds(1f);
        UiManager.instance.losepanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
