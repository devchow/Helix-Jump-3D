using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    private int selectCharacters;

    void Start()
    {
        foreach(GameObject ch in characters)
        {
            ch.SetActive(false);
        }
        characters[selectCharacters].SetActive(true);
    }

}
