using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using manology.Code;

namespace manology.Controllers
{
    public class MongoDBController : Controller
    {
        //
        // GET: /MongoDB/
		public void SaveViewModel(int userId, string accessToken, string viewModel)
		{
			MongoWork mongoDB = new MongoWork();
			mongoDB.SaveViewModelMetadata(userId, accessToken, viewModel);
		}
       
		public ActionResult LoadViewModel(int userId)
		{
			MongoWork mongoDB = new MongoWork();
			string vm = mongoDB.LoadViewModelMetadata(userId).MeViewModel;
			return Json(vm);
		}

		public void AddToRecenltyViewed(int userId, string viewedUser)
		{
			MongoWork mongoDB = new MongoWork();
			mongoDB.AddToRecentlyViewed(userId, viewedUser);
		}

		public ActionResult LoadRecentlyViewed(int userId)
		{
			MongoWork mongoDB = new MongoWork();
			List<string> rv = mongoDB.LoadRecentlyViewed(userId);
			return Json(rv);
		}

    }
}
