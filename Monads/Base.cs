namespace DesignPatterns
{
    public class Base
    {
        public override bool Equals(object obj) => 
            ToString().Equals(obj.ToString());
    }
}