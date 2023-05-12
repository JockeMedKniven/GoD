using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOD.Membership.Database.Entities
{
	public class Publisher : IEntity
	{
		public Publisher()
		{
			Games = new HashSet<Game>();
		}

		public int Id { get; set; }
		[MaxLength(50), Required]
		public string? Name { get; set; }

		public virtual ICollection<Game> Games { get; set; }
	}
}
