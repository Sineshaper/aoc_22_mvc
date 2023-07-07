namespace d1.Models
{
    public class Elf
    {
        public int Id { get; set; }
        public List<Food> FoodContainer { get; set; } = new List<Food>();
        public int CalorieSum { get; set; }
        public bool isFoodContainerEmpty { get; set; } = true;
    }
}
