using System;
using Todo.Models;

namespace Todo.Services
{
	public class AdminService : IUserService<List<Client>>
	{
		public AdminService()
		{
		}

        public List<Client> GetDispayData(User user)
		{
			Admin admin;
            try
			{
				admin = (Admin)user;
			}
			catch(InvalidCastException e)
			{
				Console.WriteLine(e.Message);
				return new List<Client>();
			}

			if (admin.WatchList is null)
				return new List<Client>();

			return admin.WatchList;
		}

    }
}

