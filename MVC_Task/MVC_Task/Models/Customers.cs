using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVC_Task.Models
{
    public  class CustResult
    {
        public List<Customers> Results { get; set; }
        public Info Info { get; set; }
    }

    public  class Info
    {
        public string Seed { get; set; }
        public long? Results { get; set; }
        public long? Page { get; set; }
        public string Version { get; set; }
    }

    public  class Customers
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public string Email { get; set; }
        public Login Login { get; set; }
        public Dob Dob { get; set; }
        public Dob Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public Id Id { get; set; }
        public string Nat { get; set; }
    }

    public  class Dob
    {
        public DateTimeOffset? Date { get; set; }
        
        public long? Age { get; set; }
    }

    public  class Id
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }



    public  class Login
    {
        public Guid? Uuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
    }

    public  class Name
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }

        public override string ToString()
        {
            if (Title != null)
            {
                Title= char.ToUpper(Title[0]) + Title.Substring(1);
            }
            if (First != null)
            {
                First = char.ToUpper(First[0]) + First.Substring(1);
            }
            if (Last != null)
            {
                Last = char.ToUpper(Last[0]) + Last.Substring(1);
            }
            return $"{Title}. {First} {Last}";

        }
    }




}