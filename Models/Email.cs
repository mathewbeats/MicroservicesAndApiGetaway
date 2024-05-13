namespace Microservices.Models
{
    public class Email
    {



        public string value { get; set; }


        public Email()
        {
            
        }


        public Email(string value)
        {

            this.value = value;
            
        }


        public override string ToString()
        {
            return value;
        }


        public static bool operator==(Email a, Email b)
        {

            return a.value == b.value;
        }


        public static bool operator!=(Email a, Email b)
        {
            return !(a == b);
        }


        public override bool Equals(object? obj)
        {
            return obj is Email email && value == email.value;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(value);
        }
    }
}
