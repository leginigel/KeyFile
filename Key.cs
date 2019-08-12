using System;
using System.Collections.Generic;

namespace KeyFile
{
    public class Key{
        string type;
        string index;
        string key;
        string id;

        string crc;

        public Key(string type, string index, string key, string id){
            this.type = type;
            this.index = index;
            this.key = key;
            this.id = id;
        }
        public string getKey(){ return key; }

        public void toString(){
            System.Console.WriteLine(
            this.index + '\t' +
            this.key + '\t' +
            this.id);
        }
    }
}