using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharCustom : MonoBehaviour
{
    public Renderer character;

    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();

    public int skinIndex, hairIndex, mouthIndex, eyeindex;
    public int skinMax, hairMax, mouthMax, eyeMax;

    public string charName = "Weinstein";

    void Start ()
    {
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();

        for(int i = 0; i < skinMax; i++)
        {
            Texture2D texureTemp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            skin.Add(texureTemp);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D texureTemp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            hair.Add(texureTemp);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D texureTemp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            mouth.Add(texureTemp);
        }
        for (int i = 0; i < eyeMax; i++)
        {
            Texture2D texureTemp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            eyes.Add(texureTemp);
        }
        SetTexure("Skin",0);
        SetTexure("Hair",0);
        SetTexure("Mouth",0);
        SetTexure("Eyes",0);
    }
    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        GUI.Box(new Rect(2 * scrW, 1 * scrH, 2 * scrW, 1 * scrH), "Skin");
        GUI.Box(new Rect(2 * scrW, 3 * scrH, 2 * scrW, 1 * scrH), "Hair");
        GUI.Box(new Rect(2 * scrW, 5 * scrH, 2 * scrW, 1 * scrH), "Mouth");
        GUI.Box(new Rect(2 * scrW, 7 * scrH, 2 * scrW, 1 * scrH), "Eyes");

        if (GUI.Button(new Rect(1 * scrW, 1 * scrH, 1 * scrW, 1 * scrH), "<"))
        {
            SetTexure("Skin", -1);
        }
        if (GUI.Button(new Rect(4 * scrW, 1 * scrH, 1 * scrW, 1 * scrH), ">"))
        {
            SetTexure("Skin", 1);
        }
        if (GUI.Button(new Rect(1 * scrW, 3 * scrH, 1 * scrW, 1 * scrH), "<"))
        {
            SetTexure("Hair", -1);
        }
        if (GUI.Button(new Rect(4 * scrW, 3 * scrH, 1 * scrW, 1 * scrH), ">"))
        {
            SetTexure("Hair", 1);
        }
        if (GUI.Button(new Rect(1 * scrW, 5 * scrH, 1 * scrW, 1 * scrH), "<"))
        {
            SetTexure("Mouth", -1);
        }
        if (GUI.Button(new Rect(4 * scrW, 5 * scrH, 1 * scrW, 1 * scrH), ">"))
        {
            SetTexure("Mouth", 1);
        }
        if (GUI.Button(new Rect(1 * scrW, 7 * scrH, 1 * scrW, 1 * scrH), "<"))
        {
            SetTexure("Eyes", -1);
        }
        if (GUI.Button(new Rect(4 * scrW, 7 * scrH, 1 * scrW, 1 * scrH), ">"))
        {
            SetTexure("Eyes", 1);
        }
        if(GUI.Button(new Rect(12 * scrW, 1 * scrH, 2 * scrW, 1 * scrH), "Random"))
        {
            SetTexure("Skin",Random.Range(0,skinMax - 1));
            SetTexure("Hair",Random.Range(0,hairMax - 1));
            SetTexure("Mouth",Random.Range(0,mouthMax - 1));
            SetTexure("Eyes",Random.Range(0,eyeMax -1 ));
        }
        if (GUI.Button(new Rect(12 * scrW, 7 * scrH, 3 * scrW, 1 * scrH), "Create N Play"))
        {
            Save();
            SceneManager.LoadScene(1);
        }
        GUI.Box(new Rect(6 * scrW, 7 * scrH, 3 * scrW, 0.5f * scrH), "Character Name");
        charName = GUI.TextField(new Rect(6 * scrW, 7.5f * scrH, 3 * scrW, 0.5f * scrH ),charName,15);
    }
    void Save()
    {
        PlayerPrefs.SetInt("SkinIndex",skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex",mouthIndex);
        PlayerPrefs.SetInt("EyeIndex", eyeindex);
        PlayerPrefs.SetString("PlayerName", charName);
    }
    void SetTexure(string type,int dir)
    {
        int index = 0, max = 0;
        Texture2D[] texures = new Texture2D[0];
        int matIndex = 0;
        switch(type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                texures = skin.ToArray();
                matIndex = 1;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                texures = hair.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                texures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Eyes":
                index = eyeindex;
                max = eyeMax;
                texures = eyes.ToArray();
                matIndex = 4;
                break;
        }
        index += dir;
        if(index < 0)
        {
            index = max - 1;
        }
        if(index > max - 1)
        {
            index = 0;
        }
        Material[] mat = character.materials;
        mat[matIndex].mainTexture = texures[index];
        character.materials = mat;
        switch(type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyeindex = index;
                break;
        }
    }
}
