using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.ComponentModel;

namespace Manga.Services.Identity
{
    public class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";


        //Identity resource 
        //Is a named group of claims that can be requested using a  scoped parameter. 
        //Identity Data like userId , Name 


        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource> { new IdentityResources.OpenId(),
                                                                                                      new IdentityResources.Email(),
                                                                                                      new IdentityResources.Profile()};

        //Identity scope - object of profile iteself 
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        { 
        new ApiScope ("mango", "Mango Server"),
        new ApiScope(name :"read",   displayName: "Read your Data"),
        new ApiScope(name :"write",  displayName: "Write your Data"),
        new ApiScope(name :"delete", displayName: "Delete your Data")
        };

        //client are software that request access using token to the Identity Server either authenticating or authroizing 
        public static IEnumerable<Client> clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = {new Secret("secret".Sha256()) },
                AllowedGrantTypes  = GrantTypes.ClientCredentials,
                AllowedScopes= {"read","write", "profile"  }
            },
            new Client
            {
                ClientId = "mango",
                ClientSecrets = {new Secret("secret".Sha256()) },
                AllowedGrantTypes  = GrantTypes.ClientCredentials,
                RedirectUris = { "https://localhost:44346/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:44346/signout-callback-oidc" },
                AllowedScopes= new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                    "mango" //apiscope
                }
            },
        };
    

}


}
