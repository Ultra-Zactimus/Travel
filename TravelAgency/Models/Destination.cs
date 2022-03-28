using System.ComponentModel.DataAnnotations;

namespace TravelAgency
{
  public class Destination
  {
    public Destination()
        {
            this.Reviews = new HashSet<Review>();
        }
    public int DestinationId { get; set; }

    [Required]
    public string City { get; set; }
    [Required]
    public string Country { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
  }
}