using System.Net.Http;

namespace Deventure.Core.Interfaces
{
	public interface IHttpClientService
	{
	    HttpClient GetNativeHttpClientInstance();
	}
}