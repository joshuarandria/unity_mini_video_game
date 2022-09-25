using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoice : MonoBehaviour
{

    string playerChoosen;
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        playerChoosen= PlayerPrefs.GetString("PlayerChoosen");
        player = GameObject.Find("/Player/Player");
        //Debug.Log("playerChoosen = " + playerChoosen);
        ChoosePlayer();
    }
    // Update is called once per frame
    void ChoosePlayer()
    {
        GameObject playerTypeChoose = GameObject.Find("/Player/Player");
        for (int i = 0; i < playerTypeChoose.transform.childCount - 1; i++)
        {
            GameObject child = playerTypeChoose.transform.GetChild(i).gameObject;
            child.SetActive(false);
            string childName = child.name;
            if (childName == playerChoosen)
            {
                child.SetActive(true);
            }


        }
        // weapon.unload();
        // weapon.load();
    }
}
