using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer
{
	public static class IS4Configuration
	{
		public static IEnumerable<IdentityResource> GetIdentityResources() => 
			new List<IdentityResource>{
			
			new IdentityResources.OpenId(),
			new IdentityResources.Profile()
			
			};

		public static IEnumerable<Client> GetClients() =>
			new List<Client> {
			new Client{
				ClientId = "client_id",
				ClientSecrets = { new Secret("client_secret".ToSha256()) },
				
				AllowedGrantTypes = GrantTypes.Code,


				AllowedScopes = {
					IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
				 IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
				 
				
				},
				RequireConsent = false,
				
			}
			};
	}
}
