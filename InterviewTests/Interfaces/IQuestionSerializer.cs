using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTests.Interfaces
{
    public interface IQuestionSerializer<IQuestion> 
    {
        IEnumerable<IQuestion> readQuestions();
        bool writeQuestion(IQuestion q);
    }
}
