using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StartUpCore : MonoBehaviour
{
    public FileControllor Controller;//文件信息库
    public Text NameShower, PathShower, ButtonTxt;//姓名显示、路径显示、按钮文本
    public Button MainButton;
    public string[] name;//姓名数组
    private bool[] used;//去重数组
    private string namefilepath;//文件路径
    private int usednames, length;//已抽选次数、姓名数
    private bool fileloaded = false;
    
    void Start()
    {
        ButtonTxt.text = "等待读取";
        MainButton.enabled = false;
        usednames = 0;
    }

    public void ReadName()
    {
        namefilepath = Controller.filepath;//设置相关文件参数
        name = File.ReadAllLines(namefilepath);//读取txt文件
        PathShower.text = namefilepath;//显示文件路径
        length = name.Length;//读取姓名个数
        used = new bool[length];
        for (int i = 0; i < length; i++)
        {
            used[i] = false;//初始化去重数组
        }
        ButtonTxt.text = "抽选";
        MainButton.enabled = true;
        fileloaded = true;
    }
    
    void GenerateName()
    {
        int id = Random.Range(0, length);//生成随机id
        while (used[id] == true)
        {
            id = Random.Range(0, length);//若重复了就重新生成随机id，直到未重复
        }
        NameShower.text = name[id];//显示抽选的姓名
        usednames++;//抽选次数加一
        used[id] = true;//添加重复标记
        if (usednames >= length) ButtonTxt.text = "重置";
    }

    public void Reset()
    {
        for (int i = 0; i < length; i++)
        {
            used[i] = false;//重置去重数组
        }
        if (fileloaded) ButtonTxt.text = "抽选";
        if (fileloaded) NameShower.text = "已重置";
        usednames = 0;
    }

    public void Click()
    {
        if (usednames >= length) Reset();//若所有人都抽过了就重置去重数组
        else GenerateName();//否则进行抽选
    }
}
