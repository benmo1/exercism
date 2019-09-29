using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class RestApi
{
    public class Record
    {
        [JsonProperty(Order = 1)]
        public string name;
        [JsonProperty(Order = 2)]
        public JObject owes = new JObject();
        [JsonProperty(Order = 3)]
        public JObject owed_by = new JObject();
        [JsonProperty(Order = 4)]
        public float balance;
    }

    public class GetUsersPayload
    {
        public string[] users = new string[] {};
    }

    public class PostAddPayload
    {
        public string user = "";
    }

    public class PostIouPayload
    {
        public string lender = "";
        public string borrower = "";
        public float amount = 0.0f;
    }


    protected List<Record> _data = new List<Record> {};

    public RestApi(string database)
    {
        _data = (List<Record>) JsonConvert.DeserializeObject<List<Record>>(database);
    }

    public string Get(string url, string payload = null)
    {
        List<Record> results;

        if (url == "/users" && payload != null) {
            GetUsersPayload p = JsonConvert.DeserializeObject<GetUsersPayload>(payload);
            results = _data.FindAll(r => Array.Exists(p.users, u => u == r.name));
        } else {
            results = _data;
        }

        return JsonConvert.SerializeObject(results);
    }

    public string Post(string url, string payload)
    {
        if (url == "/add") {
            PostAddPayload p = JsonConvert.DeserializeObject<PostAddPayload>(payload);
            CreateRecordIfNotExists(p.user);
            return JsonConvert.SerializeObject(GetRecord(p.user));
        } else { // /iou
            PostIouPayload p = JsonConvert.DeserializeObject<PostIouPayload>(payload);
            CreateRecordIfNotExists(p.lender);
            CreateRecordIfNotExists(p.borrower);
            Transaction(p.lender, p.borrower, p.amount);
            return JsonConvert.SerializeObject(_data.FindAll(r => (r.name == p.lender || r.name == p.borrower)));
        }
    }

    protected void CreateRecordIfNotExists(string user) {
        if (!_data.Exists(r => r.name == user)) {
            Record newRecord = new Record { name = user };
            _data.Add(newRecord);
        }
    }

// Current problem is that owed / owes should be only positive and only have each other user appearing once inside them
    protected void Transaction(string lender, string borrower, float amount) {
        Record lenderRecord = (Record) _data.Find(r => r.name == lender);
        JToken t1;
        float oldAmount1 = lenderRecord.owed_by.TryGetValue(borrower, out t1) ? (float) t1 : 0.0f;
        lenderRecord.owed_by.Add(borrower, oldAmount1 + amount);
        lenderRecord.balance += amount;
        
        Record borrowerRecord = (Record) _data.Find(r => r.name == borrower);
        JToken t2;
        float oldAmount2 = borrowerRecord.owed_by.TryGetValue(lender, out t2) ? (float) t2 : 0.0f;
        borrowerRecord.owes.Add(lender, oldAmount2 + amount);
        borrowerRecord.balance -= amount;
    }

    protected Record GetRecord(string user) {
        return _data.Find(r => r.name == user);
    }
}
