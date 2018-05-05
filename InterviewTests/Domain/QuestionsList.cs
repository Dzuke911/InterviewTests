using InterviewTests.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTests.Domain
{
    public class QuestionsList<T> where T:IQuestion
    {
        private static QuestionsList<T> instance;
        private List<T> list;

        private QuestionsList(IQuestionSerializer<IQuestion> serializer)
        {
            list = new List<T>();
            foreach(IQuestion q in serializer.readQuestions())
            {
                    list.Add((T)q);
            }
        }

        public static QuestionsList<T> GetInstance(IQuestionSerializer<IQuestion> serializer)
        {
            if( instance == null)
            {
                instance = new QuestionsList<T>(serializer);
            }

            return instance;
        }

        public IEnumerable<T> GetList()
        {
            return list;
        }

        public bool AddQuestion(T question, IQuestionSerializer<IQuestion> serializer)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            if(HasQuestion(question.Quest))
            {
                return false;
            }
            else
            {
                list.Add(question);
                serializer.writeQuestion(question);
                return true;
            }
        }

        private bool HasQuestion(string question)
        {
            return list.Any<T>(q => q.Quest == question);
        }
    }
}
