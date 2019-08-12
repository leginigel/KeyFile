using System;
using System.IO;
using System.Collections.Generic;

namespace KeyFile
{

    enum Category{
        Hdcp2x, Hdcp14, Tvid, Nfxesn, Nfxkey, Widevine
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

    class FileInput{
        
        private File FileParams;
        public List<Key> ReadFile(File fileparams){
            int counter = 0;
            string line;
            
            string filename = fileparams.path;
            string index = fileparams.index;
            var KeyList = new List<Key>();
            StreamReader file =
                new StreamReader(@".\" + filename);
            // System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
            // file may not exist
            try{
                while((line = file.ReadLine()) != null){
                    // System.Console.WriteLine(line);
                    // if line is data
                    if(line[0] == 'D'){
                        string [] sp;
                        sp = line.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                        // sp = line.Split(new String[]{"\t"}, StringSplitOptions.None);
                        /* foreach(string s in sp){
                            if(s != null)
                                System.Console.WriteLine(s);
                        } */
                        
                        // if index is drm key which we have to get
                        if(index == sp[1]){
                            // type, index, key, id
                            Key k = new Key(fileparams.key_name, sp[1], sp[2], sp[3]);
                            KeyList.Add(k);
                            // RearrangeKey(k);
                            // System.Console.WriteLine(sp.Length);
                            // k.toString();
                            /* foreach (var key in KeyList){
                                key.toString();
                            } */
                            // System.Console.ReadLine();
                        }
                    }
                    counter++;
                }
            }
            catch(System.IO.IOException e){
                Console.WriteLine("Error reading from {0}. Message = {1}", filename, e.Message);
            }
            finally{
                if(file!=null){
                    file.Close();
                    System.Console.WriteLine($"In file: " + filename);
                    System.Console.WriteLine("There were {0} lines.", counter);
                    System.Console.WriteLine($"There were {KeyList.Count} {fileparams.key_name}s.");
                }
            }
            return KeyList;
        }
        
        public void OutputFile(string keyname, List<Key> list){

            // Set a variable to the Documents path.
            string docPath = "./";
                // Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file. true to append data to file
            using (StreamWriter outputFile = 
                new StreamWriter(Path.Combine(docPath, "WriteLines.txt"), true))
            {
                foreach (Key k in list){
                    outputFile.WriteLine($"{keyname} hex crc a7ec '");
                    outputFile.WriteLine(RearrangeKey(k));
                    outputFile.WriteLine("'");
                }
            }
        }

        private string RearrangeKey(Key key){
            string k = key.getKey();
            int loop = k.Length / 2 - 1;
            for(int i = 0, lf = 15; i < loop;i++){
                int index = 2 * (i+1) + i;
                if(i == lf){
                    k = k.Insert( index,"\n");
                    lf += 16;
                }
                else{
                    k = k.Insert( index,"@");
                }
            }
            return k;
            // System.Console.WriteLine(k);
        }

        public void setFileStructure(string path, string index, string key_name){
            this.FileParams = new File(path, index, key_name);
        }
    }

    class FileOutput{
        List<Key> list;
    }
}