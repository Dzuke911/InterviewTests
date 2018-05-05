using InterviewTests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTests.Domain
{
    public class Question : IQuestion
    {
        public string Answer { get; set ; }
        public string Quest { get; set; }
    }
}
