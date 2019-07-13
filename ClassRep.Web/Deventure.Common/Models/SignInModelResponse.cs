using System;
using Newtonsoft.Json;

namespace Deventure.Common.Models
{
	public class SignInModelResponse
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty(".expires")]
		public DateTime ExpirationDate { get; set; }

		[JsonProperty("userName")]
		public string UserName { get; set; }

		[JsonProperty(".issued")]
		public DateTime Issued { get; set; }

        [JsonProperty("userData")]
        public string UserData { get; set; }
    }
}
