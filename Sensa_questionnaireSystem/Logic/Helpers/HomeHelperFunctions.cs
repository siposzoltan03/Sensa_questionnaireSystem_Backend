using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Sensa_questionnaireSystem.Model;

namespace Sensa_questionnaireSystem.Logic.Helpers
{
    public class HomeHelperFunctions
    {
        public HomeHelperFunctions()
        {
        }

        public List<Questionnaires> FilterActiveQuestionnaires(List<Questionnaires> questionnaires)
        {
            var result = questionnaires
                .Where(questionnaire => questionnaire.State == "a" || questionnaire.State == "i");
            return result.ToList();
        }
    }
}