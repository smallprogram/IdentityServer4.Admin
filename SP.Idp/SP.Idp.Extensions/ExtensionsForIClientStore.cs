using IdentityServer4.Stores;
using System.Threading.Tasks;

namespace SP.Idp.Extensions
{
    public static class ExtensionsForIClientStore
    {
        /// <summary>
        /// 确认客户端的ClientId是否正确
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="client_id">The client identifier.</param>
        /// <returns></returns>
        public static async Task<bool> IsPkceClientAsync(this IClientStore store, string client_id)
        {
            if (!string.IsNullOrWhiteSpace(client_id))
            {
                var client = await store.FindEnabledClientByIdAsync(client_id);
                return client?.RequirePkce == true;
            }

            return false;
        }
    }
}
