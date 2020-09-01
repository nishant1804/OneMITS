using Microsoft.EntityFrameworkCore;
using EtherealMade.Data;
using EtherealMade.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherealMade.InterfaceImplementation
{
    public class QuestionImplementation : IQuestion
    {
        private readonly ApplicationDbContext _context;

        public QuestionImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }
        public async Task AddView(int id)
        {
            var question = GetById(id);
            question.NumberViews += 1; 
            await _context.SaveChangesAsync();
        }

        public async Task AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
        }
        public async Task AddLike(LikeQuestion likeQuestion)
        {
            _context.LikeQuestions.Add(likeQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task  Delete(int Questionid)
        {
            var question = GetById(Questionid);
            _context.RemoveRange(question.Answers);
            _context.Remove(question);
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAnswer(int Answerid)
        {
            var answer = GetAnswerById(Answerid);
            _context.Remove(answer);
            await _context.SaveChangesAsync();
        }

        public Task EditQuestionContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions
                 .Include(question => question.User)
                 .Include(question => question.Answers).ThenInclude(answer => answer.User)
                 .Include(question => question.Category);
        }

        public Question GetById(int id)
        {
            return _context.Questions.Where(question => question.QuestionId == id)
               .Include(question => question.User)
               .Include(question => question.LikeQuestions)
               .Include(question => question.Answers).ThenInclude(answer => answer.User)
               .Include(Question => Question.Category)
               .First();
        }

        public Answer GetAnswerById(int id)
        {
            return _context.Answers.Where(answer => answer.AnswerId == id)
                .Include(answer => answer.User)
                .Include(answer => answer.LikeAnswers)
                .Include(answer => answer.Question)
                .First();
        }

        public IEnumerable<Question> GetFilteredQuestions(Category category)
        {
            return category.Questions;
        }

        public IEnumerable<Question> GetFilteredQuestions(string searchQuery)
        {
            return GetAll().Where(post => post.QuestionTitle.Contains(searchQuery) || post.QuestionContent.Contains(searchQuery));
        }

        public IEnumerable<Question> GetLatestQuestions(int n)
        {
            return GetAll().OrderByDescending(question => question.QuestionCreated).Take(n);
        }

        public IEnumerable<Question> GetPopularQuestions(int n)
        {
            return GetAll().OrderByDescending(question => question.NumberViews).Take(n);
        }

        public IEnumerable<Question> GetMostResponseQuestions(int n)
        {
            return GetAll().OrderByDescending(question => question.Answers.Count()).Take(n);
        }

        public IEnumerable<Question> GetPriorityQuestions(int n)
        {
            return GetAll().OrderByDescending(question => question.QuestionCreated).Take(n);
        }

        public IEnumerable<Question> GetQuestionsByCategory(int id)
        {
            return _context.Categories
                .Where(category => category.CategoryId == id).First()
                .Questions;
        }

        public async Task AddAnswerLike(LikeAnswer likeAnswer)
        {
            _context.LikeAnswers.Add(likeAnswer);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Answer> GetAllAnswers()
        {
            return _context.Answers;
        }

        public async Task AddReportQuestion(ReportQuestion reportQuestion)
        {
            _context.ReportQuestion.Add(reportQuestion);
            await _context.SaveChangesAsync();
        }
        public async Task AddReportAnswer(ReportAnswer reportAnswer)
        {
            _context.ReportAnswer.Add(reportAnswer);
            await _context.SaveChangesAsync();
        }
        public async Task AddReportCount(Question question)
        {
            question.ReportCount += 1;
            await _context.SaveChangesAsync();
        }
        public async Task AddReportCountAnswer(Answer answer)
        {
            answer.ReportCount += 1;
            await _context.SaveChangesAsync();
        }
        public ReportQuestion GetAllReportByQuestion(ReportQuestion reportQuestion)
        {
            return _context.ReportQuestion.Where(report => report.User == reportQuestion.User && report.Question == reportQuestion.Question)
                .Include(report => report.Question)
                .Include(report => report.User)
                .FirstOrDefault();
        }

        public ReportAnswer GetAllReportByAnswer(ReportAnswer reportAnswer)
        {
            return _context.ReportAnswer.Where(report => report.User == reportAnswer.User && report.Answer == reportAnswer.Answer)
                .Include(report => report.Answer)
                .Include(report => report.User)
                .FirstOrDefault();
        }

        
    }
}
