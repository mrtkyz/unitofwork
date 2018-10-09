using Business;
using DataAccess;
using StackExchange.Redis;
using System.Web.Mvc;
using WebSessionTest3.Cache;

namespace WebSessionTest3.Controllers
{
    public class HomeController : Controller
    {
        private RedisManager _redis;

        public HomeController()
        {
            _redis = new RedisManager();
        }

        public string Index(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;

            if (!string.IsNullOrEmpty(value))
                Session[key] = value;
            
            return $"{key}: {Session[key]}";
        }

        public string Cache()
        {
            using (var unitOfWork = new UnitOfWork(new DataContext("DataContext")))
            {
                unitOfWork.ProductRepository.Add(new Product() { Name = "Test 1" });
                unitOfWork.ProductRepository.Add(new Product() { Name = "Test 2" });
                unitOfWork.ProductRepository.Add(new Product() { Name = "Test 3" });

                unitOfWork.Save();
            }

            return string.Empty;
        }
    }
}