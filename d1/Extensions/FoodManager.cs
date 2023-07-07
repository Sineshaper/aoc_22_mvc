using d1.Models;
using System.Collections.Generic;

namespace d1.Extensions
{
    public class FoodManager
    {
        public int CalculateCaloriesPerElf (List<Food> foodContainer)
        {
            int sum = 0;
            foreach (var item in foodContainer)
            {
                sum = item.Calories + sum;
            }
            return sum;
        }

        public List<Elf> DistributeFoodToElves(List<string> expeditionSupply)
        {
            List<Elf> elvesWithDistributedFoodContainer = new List<Elf>();
            Elf currentElf = new Elf();
            int currentId = 1;
            int currentFoodId = 1;
            foreach (var food in expeditionSupply)
            {
                if (food.Contains("\r\n") || food.Equals(""))
                {
                    if (!elvesWithDistributedFoodContainer.Contains(currentElf))
                    {
                        currentElf.isFoodContainerEmpty = false;
                        currentElf.CalorieSum = CalculateCaloriesPerElf(currentElf.FoodContainer);
                        currentElf.Id = currentId;
                        elvesWithDistributedFoodContainer.Add(currentElf);
                        currentElf = new Elf();
                        currentId = currentId + 1;
                    }
                }
                else
                {
                    Food f = new Food(Convert.ToInt32(food));
                    f.Id = currentFoodId;
                    currentElf.FoodContainer.Add(f);
                    currentFoodId = currentFoodId + 1;
                }
                
            }

            return elvesWithDistributedFoodContainer;        
        }

        public Elf GetElfWithTheMostSupply(List<Elf> elves)
        {
            int currentHighestSupply = 0; 
            Elf mvpElf = new Elf();
            foreach (var elf in elves)
            {
                if (elf.CalorieSum > currentHighestSupply)
                {
                    currentHighestSupply = elf.CalorieSum;
                    mvpElf = elf;
                }
            }
            return mvpElf;
        }


        public List<Elf> GetTopThreeElvesWithTheHighestCalories(List<Elf> elves)
        {
            var top3 = (from e in elves
                        orderby e.CalorieSum descending
                        select e).Take(3).ToList();

            return top3;
        }
    }
}
