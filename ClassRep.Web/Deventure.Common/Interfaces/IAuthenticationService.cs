using System.Collections.Generic;

namespace Deventure.Core.Interfaces
{
	public interface IAuthenticationService
	{
		IDictionary<string, string> ComputeAuthenticationHeaders();
	}
}
