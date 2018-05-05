using InterviewTests.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace InterviewTests.Domain
{
    public class QuestionSerializer : IQuestionSerializer<IQuestion> 
    {
        readonly string _filePath;

        public QuestionSerializer(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<IQuestion> readQuestions()
        {
            return new List<IQuestion>();
        }

        public bool writeQuestion(IQuestion q)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Question));

            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, q);
            }

            return true;
        }
    }
}
