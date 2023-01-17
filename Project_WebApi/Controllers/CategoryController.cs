using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_WebApi.DAL;
using Project_WebApi.DAL.Entities;
using System.Linq;

namespace Project_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Bu ControllerBase'den miras aldığı için api controller oluyor
    //Controller'dan alsa view döndürebilirdi.
    public class CategoryController : ControllerBase
    {

        Context context = new Context();

        [HttpGet] //veriyi çektiğim veri geldiği için HttpGet attribute'unu alır.
        public IActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return Ok(values);  //işlem başarılı ise ok içinde veriyi döner. Ok durum kodu 200success
        }

        //ekleme işlemi için post attribute'u kullanılır ayrıca get e gerek yok zaten swagger ile ekrana getiriyoruz.
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")] //id.ye göre veri getirme, Bu id ile parametredeki aynı olmalı
        public IActionResult CategoryGet(int id)
        {
            var values = context.Categories.Find(id);
            return Ok(values);
        }

        //silme işlemi
        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut] //güncelleme işlemi
        public IActionResult CategoryUpdate(Category category)
        {
            var values = context.Categories.Find(category.CategoryID);
            values.CategoryName = category.CategoryName;
            values.Description = category.Description;
            values.Status = category.Status;
            context.SaveChanges();
            return Ok();
        }
    }
}
