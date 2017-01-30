using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCorePermission.Controllers
{
    public class JQueryPluginTestController : ControllerBase
    {
        private List<string> lstProvince = new List<string>() { "北京市", "天津市", "重庆市", "上海市", "河北省", "山西省", "辽宁省", "吉林省", "黑龙江省", "江苏省", "浙江省", "安徽省", "福建省", "江西省", "山东省", "河南省", "湖北省", "湖南省", "广东省", "海南省", "四川省", "贵州省", "云南省", "陕西省", "甘肃省", "青海省", "台湾省", "内蒙古自治区", "广西壮族自治区", "西藏自治区", "宁夏回族自治区", "新疆维吾尔自治区", "香港特别行政区", "澳门特别行政区" };
        private class Province
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [HttpPost]
        public JsonResult GetProvinces(string q, string page)
        {
            var lstRes = new List<Province>();
            for (var i = 0; i < 30; i++)
            {
                var oProvince = new Province();
                oProvince.Id = i;
                oProvince.Name = lstProvince[i];
                lstRes.Add(oProvince);
            }
            if (!string.IsNullOrWhiteSpace(q?.Trim()))
            {
                lstRes = lstRes.Where(x => x.Name.Contains(q)).ToList();
            }
            var lstCurPageRes = string.IsNullOrEmpty(page) ? lstRes.Take(10) : lstRes.Skip(Convert.ToInt32(page) * 10 - 10).Take(10);
            return Json(new
            {
                items = lstCurPageRes,
                total_count = lstRes.Count
            }, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });
        }

        public IActionResult Select2()
        {
            return View();
        }

        public IActionResult JSTree()
        {
            return View();
        }

        public IActionResult BootstrapTree()
        {
            return View();
        }

        public IActionResult JQueryTimeLine()
        {
            return View();
        }
    }
}
