using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    private int selectCharacter;

    void Start()
    {
        foreach(GameObject ch in characters)
        {
            ch.SetActive(false);
        }
        characters[selectCharacter].SetActive(true);
    }

    public void ChangeCharacter(int newCharacter)
    {
        // Disabling Current Selected Character
        characters[selectCharacter].SetActive(false);

        // Enabling the new character
        characters[newCharacter].SetActive(true);

        selectCharacter = newCharacter;
    }

}
