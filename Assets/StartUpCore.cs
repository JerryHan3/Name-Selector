using System.Collections;
using System.Collections.Generic;
//using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StartUpCore : MonoBehaviour
{
    public FileControllor Controller;
    public Text NameShower, PathShower;
    public string[] name;
    private string namefilepath;

    public void ReadName()
    {
        namefilepath = Controller.filepath;
        name = File.ReadAllLines(namefilepath);
        PathShower.text = namefilepath;
    }

    public void GenerateName()
    {
        int length = name.Length;
        int id = Random.Range(0, length);
        NameShower.text = name[id];
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
