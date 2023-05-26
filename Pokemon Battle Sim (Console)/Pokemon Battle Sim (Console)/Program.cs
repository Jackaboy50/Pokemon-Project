using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using Pokemon_Battle_Sim__Console_;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;
using Pokemon_Battle_Sim__Console_.Functionality_Classes;

class Program
{
    static void Main(string[] args)
    {

        StartApplication();
        //Functions.LoadTypeData();
        //FileHandler.WritePokemonToJsonFile();
    }

    static void StartApplication()
    {
        Functions.LoadClassData();
        MenuHandler.MainMenu();
    }
}