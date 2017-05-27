using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MyHealthAdviser.Dto
{
   
    [Serializable]
    [DataContract]
    public class UserPesronal
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int age { get; set; }

        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string Locality { get; set; }

    }

    public class UserDetail
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set;}

        [DataMember]
        public double BP { get; set; }

        [DataMember]
        public int HB { get; set; }

        [DataMember]
        public double Glucose { get; set; }

        [DataMember]
        public string Location { get; set; }

    }

}
