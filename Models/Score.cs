namespace WebApplication.Models 
{

    public class Score
    {
        public virtual int Id { get; set; }
        public virtual int Value { get; set; }
        public virtual Player Player { get; set; }
    }

}