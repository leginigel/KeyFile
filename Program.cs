﻿using System;
using System.IO;
using System.Collections.Generic;

namespace KeyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Key key = new Key("","","","");
            Console.WriteLine("Hello World!");
        }

        
        static readonly Dictionary<Category, File> FileParams = 
            new Dictionary<Category, File>(){
            {Category.Hdcp2x, new File("Ejemplo_3101(HDCP2.2).tsv", "3102", "hdcp2xkey")},
            {Category.Hdcp14, new File("ejemplo_1665(HDCP1.4).tsv", "1667", "hdcp14key")}
        };
    }
}
