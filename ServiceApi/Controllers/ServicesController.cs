using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Data;

namespace ServiceApi.Controllers
{
    [EnableCors(origins: "http://localhost:3000",headers:"*",methods:"*")]
    public class ServicesController : ApiController
    {
      
        MyDbModel3 Models;
        ServicesController()
        {
           
            Models = new MyDbModel3();

        }


        // GET api/values
        [HttpGet]
        public IHttpActionResult GetAllServices()
        {

            var returnValue = new { Models.Services, Models.ServiceTypes };
                return Content(HttpStatusCode.OK, returnValue);
                    
            
        }

        [HttpGet]
        // GET api/values/5
        public IHttpActionResult GetServicebyId(int id)
        {
            var selectedService = Models.Services.Where(service => service.ServiceId == id).FirstOrDefault();
            var selectedServiceType = Models.ServiceTypes.Where(servicetype => servicetype.ServiceId == id).FirstOrDefault();
            
            if(selectedService == null)
            {
                return Content(HttpStatusCode.NotFound, string.Format("{0} not created", id));
            }
            return Content(HttpStatusCode.OK, new { selectedService,selectedServiceType });
        }

        [HttpPost]
        // POST api/values
        public IHttpActionResult CreateService([FromBody] AllValueService allservice)
        {
            Service service = new Service();
            service.ServiceId = allservice.ServiceId;
            service.Name = allservice.Name;
            service.Location = allservice.Location;
            ServiceType serviceType = new ServiceType();
            serviceType.ServiceId = allservice.ServiceId;
            serviceType.ServiceType1 = allservice.ServiceType1;
            serviceType.Price = allservice.Price;
            serviceType.AeraToSupport = allservice.AeraToSupport;
            if(service.Name.Length > 100)
            {
                return Content(HttpStatusCode.BadRequest, "Name is too long");
            }
            else
            {
                Models.Services.Add(service);
                Models.ServiceTypes.Add(serviceType);
            }
            
            Models.SaveChanges();
            
            return Content(HttpStatusCode.Created, "");
        }

        [HttpPut]
        // PUT api/values/5
        public IHttpActionResult ReplaceService(int id, [FromBody] AllValueService replaceService)
        {
            var removeService = Models.Services.Where(services => services.ServiceId == id).FirstOrDefault();
            var removeServicetype = Models.ServiceTypes.Where(servicetypes => servicetypes.ServiceId == id).FirstOrDefault();
            Models.Services.Remove(removeService);
            
            Models.ServiceTypes.Remove(removeServicetype);
            
            
            Service service = new Service();
            service.ServiceId = replaceService.ServiceId;
            service.Name = replaceService.Name;
            service.Location = replaceService.Location;
            ServiceType serviceType = new ServiceType();
            serviceType.ServiceId = replaceService.ServiceId;
            serviceType.ServiceType1 = replaceService.ServiceType1;
            serviceType.Price = replaceService.Price;
            serviceType.AeraToSupport = replaceService.AeraToSupport;

            if (service.Name.Length > 100)
            {
                return Content(HttpStatusCode.BadRequest, "Name is too long");
            }

            Models.Services.Add(service);
            Models.ServiceTypes.Add(serviceType);


            Models.SaveChanges();
            return Content(HttpStatusCode.Accepted, "");
        }

        [HttpPatch]
        public IHttpActionResult UpdateService(int id, [FromBody] AllValueService allservice)
        {
            return ReplaceService(id, allservice);
        }

        

        [HttpDelete]
        // DELETE api/values/5
        public IHttpActionResult DeleteService(int id)
        {
            var deleteService = Models.Services.Where(service => service.ServiceId == id).FirstOrDefault();
            var deleteServicetype = Models.ServiceTypes.Where(service => service.ServiceId == id).FirstOrDefault();

            Models.Services.Remove(deleteService);
            Models.ServiceTypes.Remove(deleteServicetype);
            Models.SaveChanges();
            return Content(HttpStatusCode.OK, "");
        }
    }
}
