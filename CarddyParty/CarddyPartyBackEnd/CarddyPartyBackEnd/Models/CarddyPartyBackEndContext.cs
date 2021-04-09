using Microsoft.EntityFrameworkCore;

namespace CarddyPartyBackEnd.Models
{
  public class CarddyPartyBackEndContext : DbContext
  {
    public CarddyPartyBackEndContext(DbContextOptions options)
      : base(options)
    {
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //   optionsBuilder.UseLazyLoadingProxies();
    // }
    public DbSet<Player> Players { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Prompt> Prompts { get; set; }

    public DbSet<Select> Selects {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Card>().HasData(
        new Card { CardId = 1, Answer = "", PlayerID = 1 },
        new Card { CardId = 2, Answer = "", PlayerID = 2 },
        new Card { CardId = 3, Answer = "", PlayerID = 1 },
        new Card { CardId = 4, Answer = "", PlayerID = 2 }
      );

      builder.Entity<Player>().HasData(
        new Player { PlayerID = 1, Name = "P1", Points = 0 },
        new Player { PlayerID = 2, Name = "P2", Points = 0 },
        new Player { PlayerID = 3, Name = "P3", Points = 0 },
        new Player { PlayerID = 4, Name = "P4", Points = 0 }
      );

      builder.Entity<Prompt>().HasData(
        new Prompt { PromptId = 1, Description = "Who was the best President?", Theme = "politics"},
        new Prompt { PromptId = 2, Description = "Why did the cat cross the road?", Theme = "jokes"},
        new Prompt { PromptId = 3, Description = "The unintentional best thing about Epicodus is", Theme = "epicodus"},
        new Prompt { PromptId = 4, Description = "Who had the worst scandal?", Theme = "politics"},
        new Prompt { PromptId = 5, Description = "Why did my dad leave me?", Theme = "jokes"},
        new Prompt { PromptId = 6, Description = "Epicodus is terrible at", Theme = "epicodus"},
        new Prompt { PromptId = 7, Description = "Today's stand up at Epicodus was", Theme = "epicodus"},
        new Prompt { PromptId = 8, Description = "My dev group last week was", Theme = "epicodus"},
        new Prompt { PromptId = 9, Description = "It's like Leilani always says: ", Theme = "epicodus"},
        new Prompt { PromptId = 10, Description = "The worst President was", Theme = "politics"},
        new Prompt { PromptId = 11, Description = "If I had the opportunity, I would vote for ___ again", Theme = "politics"},
        new Prompt { PromptId = 12, Description = "The reason flamingos stand on one leg is", Theme = "jokes"},
        new Prompt { PromptId = 13, Description = "A chicken walks into a bar because", Theme = "jokes"},
        new Prompt { PromptId = 14, Description = "6 words or less to make an entire group of people mad", Theme = "situational"},
        new Prompt { PromptId = 15, Description = "The three words I want to hear from any romantic partner", Theme = "situational"},
        new Prompt { PromptId = 16, Description = "And then I told my boss ____ and got fired", Theme = "situational"},
        new Prompt { PromptId = 17, Description = "My mom always told me..", Theme = "situational"},
        new Prompt { PromptId = 18, Description = "Your final words before you're burned as a witch in Salem", Theme = "situational"},
        new Prompt { PromptId = 19, Description = "Fill in the blank: All I want for Christmas is ____", Theme = "blanks"},
        new Prompt { PromptId = 20, Description = "Fill in the blank: Keep the change you filthy _____ ", Theme = "blanks"},
        new Prompt { PromptId = 21, Description = "Fill in the blank: Everywhere the light touches is _____ ", Theme = "blanks"},
        new Prompt { PromptId = 22, Description = "Fill in the blank: I have a feeling we're not ___ anymore ", Theme = "blanks"},
        new Prompt { PromptId = 23, Description = "Fill in the blank: May the ___ be with you ", Theme = "blanks"},
        new Prompt { PromptId = 24, Description = "Fill in the blank: ______, my dear Watson", Theme = "blanks"},
        new Prompt { PromptId = 25, Description = "Fill in the blank: Soylent green is _____", Theme = "blanks"}
      );
      builder.Entity<Select>().HasData(
        new Select { SelectId = 1, selectedcard = 1},
        new Select { SelectId = 2, selectedcard = 1},
        new Select { SelectId = 3, selectedcard = 1},
        new Select { SelectId = 4, selectedcard = 1}
      );
    }
  }
}