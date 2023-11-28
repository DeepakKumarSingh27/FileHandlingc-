using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FileHandlingInC_
{
    public class Post
    {
        [JsonProperty("id")]
        public static int Id {  get; set; }

        [JsonProperty("title")]
        public static string Title {  get; set; }
    }


}
