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
			mongoDB.SaveViewModel(userId, accessToken, viewModel);
		}
       
		public ActionResult LoadViewModel(int userId)
		{
			MongoWork mongoDB = new MongoWork();
			ViewModel vm = mongoDB.LoadViewModel(userId);
			return Json(vm);
		}

    }
}
