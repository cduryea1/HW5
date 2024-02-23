using System.ComponentModel.DataAnnotations;

namespace a
{
    public class Patient
    {
        [Key]
        public string PID { get; set; } = "";

        public int Age { get; set; } = 0;

        public int AgeLevel { get; set; } = -1;

        public int GetAgeLevel()
        {
            if(this.Age >=65)
            {
                this.AgeLevel = 1;
            }
            else if(this.Age>=40)
            {
                this.AgeLevel = 2;
            }
            else
            {
                this.AgeLevel = 3;
            }
            return this.AgeLevel;
        }
        public override string ToString()
        
          
            {
                return $"ID: {this.PID},Age: {this.Age}, (Level {this.AgeLevel})";
            }
        





    }
}