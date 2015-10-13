using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using EOffice.Questions;
using EOffice.Questions.Dto;
using EOffice.Users;
using NSubstitute;
using Shouldly;
using Xunit;

namespace EOffice.UnitTest.Questions
{
    public class QuestionAppService_Tests : EOfficeUnitTestBase
    {
        [Fact]
        public void Should_Get_All_Questions()
        {
            // Arrange
            var questions = new List<Question>
            {
                new Question {Title = "title1", CreationTime = DateTime.Now.AddDays(1), CreatorUser = new User()},
                new Question {Title = "title2", CreationTime = DateTime.Now.AddDays(2), CreatorUser = new User()},
                new Question {Title = "title3", CreationTime = DateTime.Now.AddDays(3), CreatorUser = new User()}
            };
            var input = new GetQuestionsInput {MaxResultCount = 0, Sorting = "CreationTime DESC"};

            var questionRepository = Substitute.For<IRepository<Question>>();
            var answerRepository = Substitute.For<IRepository<Answer>>();
            var userRepository = Substitute.For<IRepository<User, long>>();
            var questionDomainService = new QuestionDomainService(answerRepository);
            var unitOfWorkManager = Substitute.For<IUnitOfWorkManager>();
            questionRepository.Count().Returns(questions.Count);
            questionRepository.GetAll().Returns(questions.AsQueryable());

            var questionAppService = new QuestionAppService(questionRepository, answerRepository, userRepository,
                questionDomainService, unitOfWorkManager);
            var settingManager = Substitute.For<ISettingManager>();
            settingManager.GetSettingValueAsync(Arg.Any<string>()).Returns(Task.FromResult(questions.Count.ToString()));
            questionAppService.SettingManager = settingManager;

            // Act
            var output = questionAppService.GetQuestions(input);

            // Assert
            output.TotalCount.ShouldBe(questions.Count);
            output.Items.Count.ShouldBe(questions.Count);
            output.Items.ShouldContain(t => t.Title.StartsWith("title"));
            output.Items[0].Title.ShouldBe("title3");
            settingManager.ReceivedWithAnyArgs().GetSettingValueAsync("aa");
        }

        [Fact]
        public void Should_Get_Two_Questions_By_Input()
        {
            // Arrange
            var input = new GetQuestionsInput {MaxResultCount = 2, Sorting = "CreationTime DESC"};
            var questions = new List<Question>
            {
                new Question {Title = "title1", CreationTime = DateTime.Now.AddDays(1), CreatorUser = new User()},
                new Question {Title = "title2", CreationTime = DateTime.Now.AddDays(2), CreatorUser = new User()},
                new Question {Title = "title3", CreationTime = DateTime.Now.AddDays(3), CreatorUser = new User()}
            };
            var questionRepository = Substitute.For<IRepository<Question>>();
            var answerRepository = Substitute.For<IRepository<Answer>>();
            var userRepository = Substitute.For<IRepository<User, long>>();
            var questionDomainService = new QuestionDomainService(answerRepository);
            var unitOfWorkManager = Substitute.For<IUnitOfWorkManager>();
            questionRepository.Count().Returns(2);
            questionRepository.GetAll().Returns(questions.AsQueryable());

            var questionAppService = new QuestionAppService(questionRepository, answerRepository, userRepository,
                questionDomainService, unitOfWorkManager);
            var settingManager = Substitute.For<ISettingManager>();

            // Act
            var output = questionAppService.GetQuestions(input);

            // Assert
            output.TotalCount.ShouldBe(2);
            output.Items.Count.ShouldBe(2);
            output.Items.ShouldContain(t => t.Title.StartsWith("title"));
            settingManager.DidNotReceiveWithAnyArgs().GetSettingValueAsync("aa");
        }

        [Fact]
        public void Should_Get_Two_Questions_By_Setting()
        {
            // Arrange
            var input = new GetQuestionsInput {MaxResultCount = 0, Sorting = "CreationTime DESC"};
            var questions = new List<Question>
            {
                new Question {Title = "title1", CreationTime = DateTime.Now.AddDays(1), CreatorUser = new User()},
                new Question {Title = "title2", CreationTime = DateTime.Now.AddDays(2), CreatorUser = new User()},
                new Question {Title = "title3", CreationTime = DateTime.Now.AddDays(3), CreatorUser = new User()}
            };
            var questionRepository = Substitute.For<IRepository<Question>>();
            var answerRepository = Substitute.For<IRepository<Answer>>();
            var userRepository = Substitute.For<IRepository<User, long>>();
            var questionDomainService = new QuestionDomainService(answerRepository);
            var unitOfWorkManager = Substitute.For<IUnitOfWorkManager>();
            questionRepository.Count().Returns(2);
            questionRepository.GetAll().Returns(questions.AsQueryable());

            var questionAppService = new QuestionAppService(questionRepository, answerRepository, userRepository,
                questionDomainService, unitOfWorkManager);
            var settingManager = Substitute.For<ISettingManager>();
            settingManager.GetSettingValueAsync(Arg.Any<string>()).Returns(Task.FromResult("2"));
            questionAppService.SettingManager = settingManager;

            // Act
            var output = questionAppService.GetQuestions(input);

            // Assert
            output.TotalCount.ShouldBe(2);
            output.Items.Count.ShouldBe(2);
            output.Items.ShouldContain(t => t.Title.StartsWith("title"));
            output.Items[0].Title.ShouldBe("title3");
            settingManager.ReceivedWithAnyArgs().GetSettingValueAsync("aa");
        }

        [Fact]
        public void Should_Create_Question()
        {
            // Arrange
            var input = new CreateQuestionInput();
            var question = new Question
            {
                Title = "title1",
                CreationTime = DateTime.Now.AddDays(1),
                CreatorUser = new User()
            };
            var questionRepository = Substitute.For<IRepository<Question>>();
            questionRepository.InsertAsync(Arg.Any<Question>()).Returns(Task.FromResult(question));

            var answerRepository = Substitute.For<IRepository<Answer>>();
            var userRepository = Substitute.For<IRepository<User, long>>();
            var questionDomainService = new QuestionDomainService(answerRepository);
            var unitOfWorkManager = Substitute.For<IUnitOfWorkManager>();

            var questionAppService = new QuestionAppService(questionRepository, answerRepository, userRepository,
                questionDomainService, unitOfWorkManager);

            // Act
            var output = questionAppService.CreateQuestion(input);

            // Assert
            questionRepository.Received().InsertAsync(Arg.Any<Question>());
        }

        [Fact]
        public async Task Should_Throw_Exception_When_Create_Question_Fail()
        {
            // Arrange
            var input = new CreateQuestionInput();
            var question = new Question
            {
                Title = "title1",
                CreationTime = DateTime.Now.AddDays(1),
                CreatorUser = new User()
            };
            var questionRepository = Substitute.For<IRepository<Question>>();
            questionRepository
                .When(x => x.InsertAsync(Arg.Any<Question>()))
                .Do(x => { throw new Exception(); });
            //.InsertAsync(Arg.Any<Question>())
            //.Returns(question)
            //.AndDoes(x => { throw new Exception(); });

            var answerRepository = Substitute.For<IRepository<Answer>>();
            var userRepository = Substitute.For<IRepository<User, long>>();
            var questionDomainService = new QuestionDomainService(answerRepository);
            var unitOfWorkManager = Substitute.For<IUnitOfWorkManager>();

            var questionAppService = new QuestionAppService(questionRepository, answerRepository, userRepository,
                questionDomainService, unitOfWorkManager);

            // Assert
            await Assert.ThrowsAsync<Exception>(() => questionAppService.CreateQuestion(input));
        }
    }
}