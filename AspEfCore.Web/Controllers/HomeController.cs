using AspEfCore.Data;
using AspEfCore.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspEfCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext myContext;
        public HomeController(MyContext context)
        {
            myContext = context;
        }
        public IActionResult Index()
        {
            var province = new Province
            {
                Name = "背景",
                Population = 2_00_000
            };
            var province2 = new Province
            {
                Name = "上海",
                Population = 4_00_000
            };
            var province3 = new Province
            {
                Name = "广东",
                Population = 5_00_000
            };

            var company = new Company
            {
                Name = "Taoda",
                EstablishDate = new DateTime(1990, 1, 1),
                Person = "Secret Man"
            };

            myContext.AddRangeAsync(province, company);
            using (var context = new MyContext())
            {
                myContext.provinces.AddRange(new List<Province> {
                    province,province2,province3
                });
                //Mycontext追踪 province object
                myContext.SaveChanges();

                return View();
            }
        }

        public IActionResult Select()
        {
            var province = myContext.provinces
                .Where(x => x.Name == "北京")
                .ToList();

            var _param = "北京";
            var provinces2 =
                (from p in myContext.provinces
                 where p.Name == _param
                 select p).ToList();

            var provices2 = myContext.provinces.Where(x => EF.Functions.Like(x.Name, "Bei%")).ToList();
            return View();
        }

        public IActionResult Updata()
        {
            var province = myContext.provinces.FirstOrDefault();

            myContext.provinces.UpdateRange(province);
            myContext.SaveChanges();

            return View();
        }

        public IActionResult Delete()
        {
            var province = myContext.provinces.FirstOrDefault();
            myContext.provinces.Remove(province);
            myContext.SaveChanges();
            return View();
        }
        public IActionResult Delete2()
        {
            var Id = 5;
            var province = myContext.provinces.Find(Id);
            myContext.provinces.Remove(province);
            myContext.SaveChanges();
            return View();
        }

        public IActionResult Delete3()
        {
            myContext.Database.ExecuteSqlCommand("exec");//原始SQL语句使用
            return View();
        }
        /// <summary>
        /// 增加关联数据
        /// </summary>
        /// <returns></returns>
        public IActionResult Add_1()
        {
            var province = myContext.provinces.Single(x => x.Name == "Liaoning");

            province.Citieses.Add(new Cities
            {
                AreaCode = "0412",
                Name = "鞍山"
            });

            myContext.SaveChanges();
            return View();
        }

        public IActionResult Add_2()
        {
            var province = myContext.provinces.Single(x => x.Name == "Liaoning");

            var city = new Cities
            {
                ProvinceId = 12,
                AreaCode = "0412",
                Name = "鞍山"
            };

            myContext.Add(city);
            return View();
        }
        /// <summary>
        /// 查询关联预加载
        /// </summary>
        /// <returns></returns>
        public IActionResult SelectEager () {
            var province = myContext.Cities
                .Include(x => x.AreaCode)
                .ToList();
            return View();
        }


    }
}
