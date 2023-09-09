using AutoMapper;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.Helpers;
using Blog.Core.IServices;
using Blog.Core.Models.Dtos.Blog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class BlogService : IBlogPostService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IBlogPostRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IMapper mapper, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor accessor, IBlogPostRepository blogRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContext = accessor;
            _blogRepository = blogRepository;
            _mapper = mapper;
        }


        public async Task<BlogResponse> AddBlog(AddBlogRequest blog)
        {
            HelpersValidators.ValidateFileUpload(blog.BlogImage);

            var localFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", $"{blog.BlogImage.FileName}");

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await blog.BlogImage.CopyToAsync(stream);

            var urlPath = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}/uploads/{blog.BlogImage.FileName}";

            // convert from model to domain
            var domainModel = new BlogPost()
            {
                BlogImage = urlPath,
                CategoryId = blog.CategoryId,
                Description = blog.Description,
                Title = blog.Title,
                AuthorId = blog.AuthorId,
            };

            // add the domain model to the repository

            await _blogRepository.AddBlog(domainModel);

            return _mapper.Map<BlogResponse>(domainModel);
        }
    }
}
