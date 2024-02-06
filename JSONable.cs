using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Test
{
    public abstract class JSONable
    {
        public abstract string Serial();
        public abstract override string ToString();
        public abstract void Deserial(string jsonString);

    }

    public class PersonItem : JSONable
    {
        public int id { get; set; }
        public string nickname { get; set; }
        public string bdate { get; set; }
        public string track_code { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool can_access_closed { get; set; }
        public bool is_closed { get; set; }

        Dictionary<string, string> month { get; set; } = new Dictionary<string, string>()
        {
            { "1", "january"},
            { "2", "february"},
            { "3", "march"},
            { "4", "april"},
            { "5", "may"},
            { "6", "june"},
            { "7", "july"},
            { "8", "august"},
            { "9", "september"},
            { "10", "october"},
            { "11", "november"},
            { "12", "december"},
        };

        public string flname { get => first_name + " " + last_name;}
        public string birthday { 
            get {
                if (bdate == null) {
                    return "EMPTY DATE";
                } else {
                    List<string> values = bdate.Split(".").ToList();
                    if (values.Count == 2) {
                        return $"Day: {values[0]} Month: {month[values[1]]}";
                    } else if (values.Count == 3) {
                        return $"Day: {values[0]} Month: {month[values[1]]} Year: {values[2]}";
                    }
                    return "EMPTY DATE";
                }
            }
        }
        public override string Serial()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override void Deserial(string jsonString)
        {
            PersonItem r = JsonConvert.DeserializeObject<PersonItem>(jsonString);
            id = r.id;
            nickname = r.nickname;
            bdate = r.bdate;
            track_code = r.track_code;
            first_name = r.first_name;
            last_name = r.last_name;
            can_access_closed = r.can_access_closed;
            is_closed = r.is_closed;
        }
    }

    public class Response : JSONable
    {
        public int count { get; set; }
        public List<PersonItem> items { get; set; }
        public int intro { get; set; }
        public bool obscene_text_filter { get; set; }

        public override string Serial()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public override void Deserial(string jsonString)
        {
            Response r = JsonConvert.DeserializeObject<Response>(jsonString);
            count = r.count;
            items = r.items;
            intro = r.intro;
            obscene_text_filter = r.obscene_text_filter;
        }
    }

    public class Root : JSONable
    {
        public Response response { get; set; }
        public Error error { get; set; }
        public override string Serial()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public override void Deserial(string jsonString)
        {
            Root r = JsonConvert.DeserializeObject<Root>(jsonString);
            response = r.response;
            error = r.error;
        }
    }

    public class Error : JSONable
    {
        public int error_code { get; set; } = 0;
        public string error_msg { get; set; }
        public List<RequestParam> request_params { get; set; }
        public override string Serial()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public override void Deserial(string jsonString)
        {
            Error r = JsonConvert.DeserializeObject<Error>(jsonString);
            error_code = r.error_code;
            error_msg = r.error_msg;
            request_params = r.request_params;
        }
    }

    public class RequestParam : JSONable
    {
        public string key { get; set; }
        public string value { get; set; }
        public override string Serial()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public override void Deserial(string jsonString)
        {
            RequestParam r = JsonConvert.DeserializeObject<RequestParam>(jsonString);
            key = r.key;
            value = r.value;
        }
    }
}
