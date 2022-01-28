using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Uow;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Odev4.Jobs;

namespace Odev4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobsController> _logger;
        private IConfiguration _configuration;

        public JobsController(ILogger<JobsController> logger,IUnitOfWork unitOfWork,IConfiguration configuration)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        //Jobların çalışmasını sağlayacak olan endpoint.
        [HttpGet]
        public string StartJobs()
        {
            InsertEntityJob insertEntityJob = new();
            UpdateEntityJob updateEntityJob = new();
            return "Jobs started.";
        }
    }
}
