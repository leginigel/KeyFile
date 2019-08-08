using System;
using System.Collections.Generic;

namespace KeyFile
{

    enum Category{
        Hdcp2x, Hdcp14, Tvid, Nfxesn, Widevine
    }

    struct File
    {
        public string path;
        public string index;
        public string key_name;

        public File(string path, string index, string key_name){
            this.path = path;
            this.index = index;
            this.key_name = key_name;
        }    
    }

}