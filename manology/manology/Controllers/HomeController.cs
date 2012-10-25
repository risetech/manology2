using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace manology.Controllers
{
	public class homeController : Controller
	{
		//
		// GET: /Home/

		public ActionResult index()
		{
			return View();
		}

		public ActionResult me()
		{
			return View();
		}

		public ActionResult compare()
		{
			return View();
		}

	}
}
