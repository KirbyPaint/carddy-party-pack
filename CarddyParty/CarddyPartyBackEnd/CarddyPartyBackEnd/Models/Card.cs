using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CarddyPartyBackEnd.Models
{
  public class Card
  {
    public int CardId { get; set; }
    [Required]
    public string Answer { get; set; }
    
    public int PlayerID { get; set; }

  }
  
}