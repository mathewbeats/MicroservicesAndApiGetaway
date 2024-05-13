namespace Microservices.Models
{
    public class Name
    {


        //public readonly string value;


        public string value { get; set; }



        public Name()
        {
            
        }

        public Name(string value)
        {

            this.value = value;

            
        }


        public override string ToString()
        {
            return value;
        }


        public static bool operator==(Name a, Name b)
        {

            return Equals(a.value, b.value);
        }


        public static bool operator!=(Name a, Name b)
        {

            return !(a == b);
        }


        public override bool Equals(object? obj)
        {
            return obj is Name name && value == name.value;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(value);
        }
    }
}
