using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZephyrNetCafe.Controllers.ShopItem
{
    [ApiController]
    [Route("/api/shop")]
    public class ShopItemListController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Models.Item> foundItems;
            try
            {
                foundItems = Models.Item.GetMany();
            }
            catch (SqlException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
            return Ok(foundItems.Where((item) => item.IsDeleted == 0));
        }
    }
}
