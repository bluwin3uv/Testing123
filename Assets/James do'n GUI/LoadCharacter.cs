using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCharacter : MonoBehaviour
{
    public Renderer character;
    public GameObject player;
    public string charName = "ViChink";
    public int skinIndex, hairIndex, mouthIndex, eyeIndex;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        character = player.GetComponentInChildren<SkinnedMeshRenderer>();
        LoadTexure();

    }
	
	

    void LoadTexure()
    {
        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SetTexure("Skin", PlayerPrefs.GetInt("SkinIndex"));
            SetTexure("Hair", PlayerPrefs.GetInt("HairIndex"));
            SetTexure("Mouth", PlayerPrefs.GetInt("MouthIndex"));
            SetTexure("Eyes", PlayerPrefs.GetInt("EyeIndex"));
            player.name = PlayerPrefs.GetString("PlayerName");
        }
    }

    void SetTexure(string type, int dir)
    {
        Texture2D texx = null;
        int matIndex = 0;
        switch(type)
        {
            case "Skin":
                texx = Resources.Load("Character/Skin_" + dir) as Texture2D;
                matIndex = 1;
                break;
            case "Hair":
                texx = Resources.Load("Character/Hair_" + dir) as Texture2D;
                matIndex = 2;
                break;
            case "Mouth":
                texx = Resources.Load("Character/Mouth_" + dir) as Texture2D;
                matIndex = 3;
                break;
            case "Eyes":
                texx = Resources.Load("Character/Eyes_" + dir) as Texture2D;
                matIndex = 4;
                break;
        }
        Material[] mat = character.materials;
        mat[matIndex].mainTexture = texx;
        character.materials = mat;
    }
}
