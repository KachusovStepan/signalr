using System;
using System.Linq;
using System.Security.Claims;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsRepository commentsRepository;

        public CommentsController(CommentsRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        // GET
        [HttpGet("api/news/{id}/comments")]
        public ActionResult<CommentsDto> GetCommentsForNews(Guid newsId)
        {
            // TODO
            // throw new NotImplementedException();
            var comments = commentsRepository.GetComments(newsId);
            var commentDtos = comments
                .Select(comment => new CommentDto
                {
                    User = comment.User,
                    Value = comment.Value
                }).ToList();
            var commentsDto = new CommentsDto
            {
                NewsId = newsId,
                Comments = commentDtos
            };
            return commentsDto;
        }
    }
}