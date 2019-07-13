namespace Deventure.Core.Interfaces
{
	public interface INetworkService
	{
		void SignalNoInternetConnection();
		bool DeviceHasInternetConnectivity();
		void SignalServerConnectionDown();
	}
}