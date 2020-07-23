using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sensa_questionnaireSystem.Context;
using Sensa_questionnaireSystem.Model;

namespace Sensa_questionnaireSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class QuestionnaireTemplateGroupController : Controller
    {
        private readonly QuestionnaireSystemContext _context;

        public QuestionnaireTemplateGroupController(QuestionnaireSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questiongroups>>> GetQuestionGroups()
        {
            var result = await _context.Questiongroups.ToListAsync();
            if (result == null) return NotFound();

            return new ActionResult<IEnumerable<Questiongroups>>(result.Take(10));
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Questions>>> GetQuestions()
        {
            var result = await _context.Questions.ToListAsync();
            if (result == null) return NotFound();

            return result;
        }
    }
}