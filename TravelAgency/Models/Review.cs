using System.ComponentModel.DataAnnotations;

namespace TravelAgency
{
  public class Review
  {
    public int ReviewId { get; set; }
    [Required]
    public string User {get;set;}
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }
    [Required] 
    public string Text {get;set;}
    public int DestinationId { get; set; }
    public virtual Destination Destination { get; set; }
  }
}