using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SP.Idp.Core.IdentityCore.IdentityModels.Entites;

namespace SP.Idp.Api.Controller
{
    [SecurityHeaders]
    [AllowAnonymous]
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityServerInteractionService identityServerInteractionService;
        private readonly IClientStore clientStore;
        private readonly IAuthenticationSchemeProvider schemeProvider;
        private readonly IEventService eventService;
        private readonly UserManager<IdpUser> userManager;
        private readonly SignInManager<IdpUser> signInManager;

        public AccountController(
            IIdentityServerInteractionService identityServerInteractionService,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService eventService,
            UserManager<IdpUser> userManager,
            SignInManager<IdpUser> signInManager
            
            )
        {
            this.identityServerInteractionService = identityServerInteractionService;
            this.clientStore = clientStore;
            this.schemeProvider = schemeProvider;
            this.eventService = eventService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



    }
}