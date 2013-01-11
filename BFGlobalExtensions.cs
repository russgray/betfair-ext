
using BetfairExt.BFGlobal;

namespace BetfairExt
{
    public static class BFGlobalExtensions
    {
        public static LoginResp login(this BFGlobalServiceClient client, string username, string password, int productID)
        {
            return client.Login(username, password, productID);
        }

        public static LoginResp Login(this BFGlobalServiceClient client, string username, string password, int productID)
        {
            return client.login(new LoginReq
            {
                username = username,
                password = password,
                productId = productID,
            });
        }
    }
}
