using System.Web.Mvc;
using AutoMapper;
using CoinMonitoringPortal.Data.Data.Account;
using CoinMonitoringPortal.Data.Messages.Action;
using CoinMonitoringPortal.Interfaces;
using CoinMonitoringPortal.Portal.Attributes;
using CoinMonitoringPortal.Portal.ViewModels.Account;

namespace CoinMonitoringPortal.Portal.Controllers
{
    public class AccountController : BaseController
    {
	    private readonly IAccountFacade _accountFacade;

	    public AccountController(IAccountFacade accountFacade)
	    {
		    _accountFacade = accountFacade;
	    }

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

		[HttpPost]
	    public ActionResult Login(LoginViewModel model)
		{
			if(_accountFacade.Login(Mapper.Map<LoginData>(model)))
			{
				return RedirectToRoute("Home");
			}

			model.ErrorMessage = "Incorrect username or password";
			return View(model);
		}

		public ActionResult Register()
		{
			return View(new RegisterViewModel());
		}

		[HttpPost]
	    public ActionResult Register(RegisterViewModel model)
		{
			RegisterResult result = _accountFacade.Register(Mapper.Map<RegisterData>(model));

			if (result.Success)
			{
				return RedirectToRoute("RegisterSuccess");
			}
			
			model.ErrorMessage = result.ErrorMessage;
		    return View(model);
	    }

		[Secured]
	    public ActionResult UserProfile()
		{
			UserProfileViewModel model = new UserProfileViewModel
			{
				AuthKeys = _accountFacade.GetAuthKeys()
			};

			return View(model);
	    }

	    [Secured]
		[HttpPost]
		public ActionResult UserUserProfile(UserProfileViewModel model)
	    {
		    _accountFacade.UpdateUser(model.UpdateUser);
		    return RedirectToRoute("UserProfile");
	    }
		
	    [HttpPost]
	    [Secured]
	    public ActionResult ChangePassword(UserProfileViewModel model)
	    {
		    _accountFacade.ChangeUserPassword(model.ChangeUserPassword);
		    return RedirectToRoute("UserProfile");
		}

	    [HttpPost]
	    [Secured]
	    public JsonResult CreateAuthKey(CreateAuthKeyData data)
	    {
		    _accountFacade.CreateAuthKey(data);
		    return Json("Ok");
	    }

	    [HttpPost]
	    [Secured]
	    public JsonResult DeleteKey(DeleteAuthKeyRequest deleteAuthKey)
	    {
		    _accountFacade.DeleteAuthKey(deleteAuthKey);
		    return Json("Ok");
	    }

		public ActionResult RegisterSuccess()
	    {
		    return View();
	    }

		public ActionResult Logout()
	    {
		    return RedirectToRoute("Login");
	    }
	}
}