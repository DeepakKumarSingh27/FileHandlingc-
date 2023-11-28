using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FileHandlingInC_
{
   
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            Console.WriteLine("Enter the Number");
            int x = Convert.ToInt32(Console.ReadLine());
            switch (x) 
            {
                case 1:
                    string path = "E:\\javaCodesWithDs\\javacode20-09-2023\\src\\KsirDs\\FileHandling\\note.txt";
                    //string path = "E:\\CSharp\\abc.txt";
                if (File.Exists(path) == true)
                {
                    Console.WriteLine("Yes,There is File:");
                }
                else
                {
                    Console.WriteLine("File Not File");
                }
                break;
                case 2:
                    string path1 = @"E:\\CSharp\data.txt";
                    if (File.Exists(path1))
                    {
                        Console.WriteLine("Yes");
                        string data = File.ReadAllText(path1);
                        Console.WriteLine(data);
                    }
                    else Console.WriteLine("No");
                    break;
                  case 3:
                    string path2 = @"E:\\CSharp\data.txt";
                    string path3 = @"E:\\CSharp\data1.txt";
                    File.Copy(path2, path3, true);
                    Console.WriteLine("Copyed ...");
                    break;
                    case 4:
                    string path4 = @"E:\My Subdir";
                    //string path5 = @"E:\My mydir";
                  //  DirectoryInfo dir = new DirectoryInfo(path4);
                    // dir.Create();
                    // dir.CreateSubdirectory("Another Dir");
                    // dir.MoveTo(path5);
                    // dir.Delete(true);
                    //Console.WriteLine("Subdirectory is Moved Successfully..");
                    string path5 = "E:\\Html";
                    DirectoryInfo dir = new DirectoryInfo(path5);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (var item in dirs)
                    {
                        Console.WriteLine(item.LastAccessTime);
                    }
                    break;
                case 5:
                    string path6 = @"E:\MyFile.txt";
                    using (FileStream file1 = new FileStream(path6, FileMode.Open,FileAccess.Write))
                    {
                        
                        file1.WriteByte(65);
                        Console.WriteLine("File Created");
                    }
                        //file.Close();

                break;
                case 6:
                    string path7 = @"E:\Deepak.txt";
                   using (FileStream file = new FileStream(path7, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(file,Encoding.UTF8))
                        {

                            int[] arr = { 1, 2, 3, 4, 5 };

                            foreach (var item in arr)
                            {
                                writer.Write(item+" ");
                            }
                            //writer.Write("Kumar ");
                            //writer.WriteLine("Deepak kumar singh");
                        }
                        
                    }
                    
                break;
                 case 7:
                    string path8 = @"E:\Deepak.txt";
                   using (FileStream fs = new FileStream(path8,FileMode.Open,FileAccess.Read))
                    {
                        using(StreamReader reader = new StreamReader(fs))
                        {
                            //string line = reader.ReadLine();
                            // Console.WriteLine(line);
                            string line = "";
                            while((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }

                             
                    }

                    break;
                    case 8:
                    string path9 = @"E:\Deepak\sample.pdf";
                    Employee emp = new Employee(1,"Deepak");
                    FileStream stream = new FileStream(path9,FileMode.OpenOrCreate);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream,emp);
                    stream.Close();
                    Console.WriteLine("File Created Successfully -> "+path9);
                    break;
                case 9:
                    string path10 = @"E:\Deepak\sample.pdf";
                    FileStream stream1 = new FileStream(path10, FileMode.OpenOrCreate);
                    BinaryFormatter bf1 = new BinaryFormatter();
                    Employee emp1 = (Employee)bf1.Deserialize(stream1);
                    Console.WriteLine("Id "+emp1.Id+"\n" + emp1.Name);
                    stream1.Close();
                    break;
                case 10:
                    // json
                    string url = "https://my-json-server.typicode.com/typicode/demo/posts";
                    HttpClient httpClient = new HttpClient();
                    try
                    {
                        var httpResponceMessage = await httpClient.GetAsync(url);
                        string jsonResponce = await httpResponceMessage.Content.ReadAsStringAsync();
                         Console.Out.WriteLine(jsonResponce);
                        var myPosts = JsonConvert.DeserializeObject<List<Post>>(jsonResponce);
                        foreach (var item in myPosts)
                        {
                            Console.Out.WriteLine($"{Post.Id} {Post.Title}");

                        }
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.Message);
                    }

                 break;
                    case 11:
                    string filepath = @"C:\Users\bthde\Downloads\addresses.csv";
                    try
                    {
                        using (StreamReader reader2 = new StreamReader(filepath))
                        {
                            string line;
                            while ((line = reader2.ReadLine()) != null)
                            {
                                Console.Out.WriteLine(line);
                            }
                            
                        }
                    } catch(Exception e)
                    {
                        Console.Out.WriteLine(e.Message);
                    }
                    break;
            default: Console.WriteLine("Case don't match");
                        break;

                    }
            Console.ReadLine();
        }
    }
}
