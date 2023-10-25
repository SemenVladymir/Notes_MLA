using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using Notes.Models;

namespace Notes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : Controller
    {
        private readonly MobileContext _dbContext;
        public PhoneController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddPhone(Phone phone)
        {
            _dbContext.Phones.Add(phone);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdatePhone(int phoneId, Phone newData)
        {
            if (_dbContext.Phones == null)
                return BadRequest();

            _dbContext.Phones.Update(new Phone { Id = phoneId, Name = newData.Name, Company = newData.Company, Price = newData.Price });
            if (_dbContext.SaveChanges() > 0)
                return Ok();
            else
                return BadRequest();
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult> DeletePhones(int id)
        {
            if (_dbContext.Phones == null)
                return BadRequest();
            Phone phone = _dbContext.Phones.FirstOrDefault(x => x.Id == id);
            _dbContext.Phones.Remove(phone);
            if (_dbContext.SaveChanges() > 0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("ReadAll")]
        public async Task<ActionResult<IEnumerable<Phone>>> GetAllPhones()
        {
            if (_dbContext.Phones == null)
                return BadRequest();

            return _dbContext.Phones.ToList();
        }

        //------------------------
        //IOrderService orderService;
        //public PhoneController(IOrderService serv)
        //{
        //    orderService = serv;
        //}

        //[HttpGet("ReadAll")]
        //public ActionResult Index()
        //{
        //    IEnumerable<PhoneDTO> phoneDtos = orderService.GetPhones();
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhoneDTO, PhoneViewModel>()).CreateMapper();
        //    var phones = mapper.Map<IEnumerable<PhoneDTO>, List<PhoneViewModel>>(phoneDtos);
        //    return View(phones);
        //}

        //[HttpPost("Add order by Id")]
        //public ActionResult MakeOrder(int? id)
        //{
        //    try
        //    {
        //        PhoneDTO phone = orderService.GetPhone(id);
        //        var order = new OrderViewModel { PhoneId = phone.Id };

        //        return View(order);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //}
        //[HttpPost("Add order")]
        //public ActionResult MakeOrder(OrderViewModel order)
        //{
        //    try
        //    {
        //        var orderDto = new OrderDTO { PhoneId = order.PhoneId, Address = order.Address, PhoneNumber = order.PhoneNumber };
        //        orderService.MakeOrder(orderDto);
        //        return Content("<h2>Ваш заказ успешно оформлен</h2>");
        //    }
        //    catch (ValidationException ex)
        //    {
        //        ModelState.AddModelError(ex.Property, ex.Message);
        //    }
        //    return View(order);
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    orderService.Dispose();
        //    base.Dispose(disposing);
        //}

    }
}
