using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace TravelAgency
{
  public class User
  {
    public User() 
    {
        this.Reviews = new HashSet<Review>();
    }
    public int UserId { get; set; }
    [Required]
    public string Name { get; set; }
    public int ReviewId { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
  }
}