using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public static class RentalConstraint
    {
     
		public static int MaxMoviesUserCanRent
		{
			get { return 4; }
		}

	}
}