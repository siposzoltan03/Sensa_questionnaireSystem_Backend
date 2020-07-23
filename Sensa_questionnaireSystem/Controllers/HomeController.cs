using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Sensa_questionnaireSystem.Model;
using Sensa_questionnaireSystem.Context;
using Sensa_questionnaireSystem.Logic.Helpers;

namespace Sensa_questionnaireSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly QuestionnaireSystemContext _context;
        private readonly HomeHelperFunctions _helperFunctions;


        public HomeController(QuestionnaireSystemContext context, HomeHelperFunctions helperFunctions)
        {
            _context = context;
            _helperFunctions = helperFunctions;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questionnaires>>> GetQuestionnaires()
        {
            var questionnaires = await _context.Questionnaires.ToListAsync();
            if (questionnaires == null)
            {
                return NotFound();
            }

            var result = _helperFunctions.FilterActiveQuestionnaires(questionnaires);

            return result;
        }
    }
}