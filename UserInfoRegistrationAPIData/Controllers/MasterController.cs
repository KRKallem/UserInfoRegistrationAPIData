using Newtonsoft.Json;
using ServiceDBAccess;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RegistrationAPI.Controllers
{
    public class MasterController : ApiController
    {
        #region Global Declaration
        SampleDBEntities ServiceDB = new SampleDBEntities();
        #endregion

        #region Koteswar        
         //Get the specific userinfo by using userid
        [HttpGet]
        [Route("~/api/Master/GetuserdetailbyID")]
        public HttpResponseMessage GetuserdetailbyID(int id)
        {
            using (ServiceDB)
            {
                try
                {
                    ServiceDB.Configuration.ProxyCreationEnabled = false;
                    var Type = (from x in ServiceDB.Users 
                                where x.id == id
                                select new
                                {
                                    userName = x.userName,
                                    mailID = x.mailID,
                                    phoneNumber = x.phoneNumber,
                                    skillSet = x.skillSet,
                                    hobby = x.hobby
                }).FirstOrDefault();
                    if (Type != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, Type);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data not found");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Data not found");
                }
            }
        }
        //Retrieving user data 
        [HttpGet]
        [Route("~/api/Master/GetUserData")]
        public async Task<HttpResponseMessage> GetUserData()
        {
            using (ServiceDB)
            {
                try
                {
                    using (ServiceDB)
                    {
                        ServiceDB.Configuration.ProxyCreationEnabled = false;
                        var Type = await (from x in ServiceDB.Users
                                          select new
                                          {
                                              ID = x.id,
                                              userName = x.userName.Trim(),
                                          }).ToListAsync();
                        return Request.CreateResponse(HttpStatusCode.OK, Type);
                    }
                }
                catch (Exception )
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Internel Server Error");
                }
            }
        }

        //List of users are stored in the table to get the result
        [HttpGet]
        [Route("~/api/Master/GetAllUserInfo")]
        public async Task<HttpResponseMessage> GetAllUserInfo()
        {
            using (ServiceDB)
            {
                try
                {
                    using (ServiceDB)
                    {
                        ServiceDB.Configuration.ProxyCreationEnabled = false;
                        var Type = await (from x in ServiceDB.Users
                                          select new
                                          {
                                              ID = x.id,
                                              UserName = x.userName.Trim(),
                                              Mail = x.mailID,
                                              PhoneNumber = x.phoneNumber,
                                              SkillSet = x.skillSet,
                                              Hobby = x.hobby
                                          }).ToListAsync();
                        return Request.CreateResponse(HttpStatusCode.OK, Type);
                    }
                }
                catch (Exception )
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Internel Server Error");
                }
            }
        }

        //Saving Data to database based on condition, if user id = 0 then data insertion for new record or user id != 0 then 
        // updating the existing record based on userid
        [HttpPost]
        [Route("~/api/Master/SaveUserData")]
        public Task<HttpResponseMessage> SaveUserData(User userdata)
        {
            using (ServiceDB)
            {
                try
                {
                    if (userdata.id == 0)
                    {
                        ServiceDB.Users.Add(userdata);
                        ServiceDB.SaveChanges();
                    }
                    else
                    {
                        var type = ServiceDB.Users.Where(x => x.id == userdata.id).FirstOrDefault();
                        if (type != null)
                        {
                            type.userName = userdata.userName;
                            type.mailID = userdata.mailID;
                            type.phoneNumber = userdata.phoneNumber;
                            type.skillSet = userdata.skillSet;
                            type.hobby = userdata.hobby;
                            ServiceDB.SaveChanges();
                        }
                        else
                        {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data not found");
                        }
                    }
                    return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, true));
                }
                catch (Exception Ex)
                {
                    return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, "Operation Failed Something Went Wrong :" + Ex.Message));
                }
            }
        }

        //Deleting the specific userinfo by using userid
        [HttpDelete]
        [Route("~/api/Master/DeleteUserByID")]
        public IHttpActionResult DeleteUserByID(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (ServiceDB)
            {
                try
                {            
                    var userid = ServiceDB.Users.Where(s => s.id == id).FirstOrDefault();
                    if(userid !=null)
                    {
                    ServiceDB.Entry(userid).State = System.Data.Entity.EntityState.Deleted;
                    ServiceDB.SaveChanges();
                    }
                    else
                    {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data not found");
                    }
                    return Ok("UserDetails deleted Successful");
                }
                catch (Exception Ex)
                    {
                        return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, "Operation Failed Something Went Wrong :" + Ex.Message));
                    }
            }
        }
        #endregion
    }

}
