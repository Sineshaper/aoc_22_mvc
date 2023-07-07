namespace d1.Models
{
    public class Food
    {
        public int Id { get; set; }
        public int Calories{ get; set; }
        public Food(int calories)
        {
            Calories = calories;
        }
    }
}
