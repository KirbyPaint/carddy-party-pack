using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarddyPartyBackEnd.Models
{
  public class Player
  {
    public int PlayerID { get; set; }
    [Required]
    public string Name { get; set; }
    public int Points { get; set; }
    public virtual ICollection<Card> Cards { get; set; }

    public Player()
    {
      this.Cards = new HashSet<Card>();
    }
  }
}