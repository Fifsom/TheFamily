using TheFamily.Entities;

namespace TheFamily.Data
{
    public class DataSeeding
    {
        public static void seedData(FamilyDbContext context)
        {
            if (context.player.Any())
            {
                return;
            }

            var player = new Player[]
            {
                new Player{Name="Osman", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Pappa", Wins=0, Loses=0},
                new Player{Name="Safiyo", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Mamma", Wins=0, Loses=0},
                new Player{Name="Mohamed", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Mohamed", Wins=0, Loses=0},
                new Player{Name="Mina", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Mina", Wins=0, Loses=0},
                new Player{Name="Omar", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Omar", Wins=0, Loses=0},
                new Player{Name="Shukri", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Shukri", Wins=0, Loses=0},
                new Player{Name="Abdullahi", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Abdullahi", Wins=0, Loses=0},
                new Player{Name="Sumaia", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Sumaia", Wins=0, Loses=0},
                new Player{Name="Ali", FavFood="Steakt spagetti med mycket vitlök.", ImgName="Ali", Wins=0, Loses=0}
            };

            context.player.AddRange(player);
            context.SaveChanges();
        }
    }
}
