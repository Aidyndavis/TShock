using System;
using System.Collections.Generic;
using System.Linq;
using TShock.Hooks;
using Terraria;

namespace TShock
{
	public abstract class Plugin : IDisposable
	{
		public abstract string Name { get; }
		public abstract Version Version { get; }
		public abstract Version ApiVersion { get; }
		public abstract string Author { get; }
		public abstract string Description { get; }
		public abstract bool Enabled { get; set; }
		public int Order {get; set; }
		public IHooks Hooks { get; set; }
		public IGame Game { get; set; }

		protected Plugin()
		{
			this.Order = 1;
		}
		~Plugin()
		{
			this.Dispose(false);
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
		}

		/// <summary>
		/// Return a list of interfaces this plugin exposes.
		/// </summary>
		/// <returns></returns>
		public virtual IEnumerable<object> CreateInterfaces()
		{
			return new List<object>();
		}
		/// <summary>
		/// Called before initialize passing all the interfaces gathered from plugins
		/// </summary>
		/// <param name="interfaces"></param>
		public virtual void SetInterfaces(IEnumerable<object> interfaces)
		{
			if (interfaces != null)
			{
				Hooks = GetInterface<IHooks>(interfaces);
				Game = GetInterface<IGame>(interfaces);
			}
		}

		/// <summary>
		/// Gets the T interface from the collection. Returns null if its not found.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="interfaces"></param>
		/// <returns></returns>
		protected T GetInterface<T>(IEnumerable<object> interfaces) where T : class
		{
			return interfaces.FirstOrDefault(o => o is T) as T;
		}
		
		public abstract void Initialize();
	}
}
