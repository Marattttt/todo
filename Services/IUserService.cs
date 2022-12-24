
using System;
using Todo.Models;

namespace Todo.Services
{
	public interface IUserService<T>
	{
		public T GetDispayData (User user);
	}
}

