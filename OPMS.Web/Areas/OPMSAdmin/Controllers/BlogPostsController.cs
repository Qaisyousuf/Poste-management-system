using OPMS.Data.Interfaces;
using OPMS.Models;
using OPMS.Services;
using OPMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPMS.Web.Areas.OPMSAdmin.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly IUnitOfWork uow;

        public BlogPostsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            //var blogPostFromdb = uow.BlogPostRepository.GetAll("Tags").ToList();

            //List<BlogPostViewModel> viewmodel = new List<BlogPostViewModel>();

            //foreach (var blogpost in blogPostFromdb)
            //{

            //    var tagIds = blogpost.Tags.Select(x => x.Id).ToList();

            //    var tagNams = uow.Context.Tags.Where(x => tagIds.Contains(x.Id)).Select(x => x.Name).ToList();
            //    viewmodel.Add(new BlogPostViewModel
            //    {
            //        Id = blogpost.Id,
            //        Title = blogpost.Title,
            //        Slug = blogpost.Slug,
            //        Content = blogpost.Content,
            //        BlogPostMetaDataOn= blogpost.BlogPostMetaDataOn,
            //        MetaKeywords= blogpost.MetaKeywords,
            //        MetaDescription= blogpost.MetaDescription,
            //        MetaOgImage= blogpost.MetaOgImage,
            //        IsVisibleToSearchEngine= blogpost.IsVisibleToSearchEngine,
            //        TagNames=tagNams
            //    });
                
            //}

            //return View(viewmodel);
            return View();
        }

        public JsonResult GetBlog()
        {
            var blogFromdb = uow.BlogPostRepository.GetAll();
            return Json(new { data = blogFromdb }, JsonRequestBehavior.AllowGet);
        }

        public void GetTags()
        {
            ViewBag.Tags = uow.TagRepository.GetAll();
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetTags();
            return View();
        }
        [HttpPost]
        public ActionResult Create(BlogPostViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetTags();
                return View(viewmodel);
            }
            BlogPost blogPost = new BlogPost();
            blogPost.Title = viewmodel.Title;
            string slug;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);
            if(uow.BlogPostRepository.SlugExists(slug))
            {
                ModelState.AddModelError("", "Le titre ou le slug existe déjà");
                GetTags();
                return View(viewmodel);
            }
            blogPost.Slug = slug;
            blogPost.Content = viewmodel.Content;
            blogPost.BlogPostMetaDataOn = viewmodel.BlogPostMetaDataOn;
            blogPost.MetaDescription = viewmodel.MetaDescription;
            blogPost.MetaKeywords = viewmodel.MetaKeywords;
            blogPost.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            blogPost.MetaOgImage = viewmodel.MetaOgImage;

            foreach (var item in viewmodel.TagIds)
            {
                var tag = uow.TagRepository.GetById(item);
                blogPost.Tags.Add(tag);
            }
            uow.BlogPostRepository.Add(blogPost);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var blogPost = uow.BlogPostRepository.GetBlogPostByTag(id);
            BlogPostViewModel viewmodle = new BlogPostViewModel
            {
                Id=blogPost.Id,
                Title=blogPost.Title,
                Slug=blogPost.Slug,
                Content=blogPost.Content,
                IsVisibleToSearchEngine=blogPost.IsVisibleToSearchEngine,
                MetaKeywords=blogPost.MetaKeywords,
                MetaDescription=blogPost.MetaDescription,
                MetaOgImage=blogPost.MetaOgImage,
            };

            int[] tagIds = blogPost.Tags.Select(x => x.Id).ToArray();
            viewmodle.TagIds = tagIds;
            GetTags();
            return View(viewmodle);
        }
        [HttpPost]
        public ActionResult Edit([Bind
            (Include ="Id,Title,Slug,Content,BlogPostMetaDataOn,MetaKeywords,MetaDescription,MetaOgImage,IsVisibleToSearchEngine")]
        BlogPostViewModel viewmodel,int[] TagIds)
        {
            if(!ModelState.IsValid)
            {
                GetTags();
                return View(viewmodel);
            }

            string slug;
            var blogPost = uow.BlogPostRepository.GetBlogPostByTag(viewmodel.Id);
            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);
            if (uow.BlogPostRepository.SlugExists(viewmodel.Id,slug))
            {
                ModelState.AddModelError("", "Le titre ou le slug existe déjà");
                GetTags();
                return View(viewmodel);
            }
            blogPost.Title = viewmodel.Title;
            blogPost.Slug = slug;
            blogPost.Content = viewmodel.Content;
            blogPost.IsVisibleToSearchEngine = viewmodel.IsVisibleToSearchEngine;
            blogPost.MetaKeywords = viewmodel.MetaKeywords;
            blogPost.MetaDescription = viewmodel.MetaDescription;
            blogPost.BlogPostMetaDataOn = viewmodel.BlogPostMetaDataOn;
            blogPost.MetaOgImage = viewmodel.MetaOgImage;

            var tagsToadd = uow.Context.Tags.Where(x => TagIds.Contains(x.Id)).ToList();
            blogPost.Tags.Clear();

            foreach (var tag in tagsToadd)
            {
                blogPost.Tags.Add(tag);
            }
            uow.BlogPostRepository.Update(blogPost);
            uow.Commit();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var blogPost = uow.BlogPostRepository.GetById(id);
            BlogPostViewModel viewmodle = new BlogPostViewModel
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Slug = blogPost.Slug,
                Content = blogPost.Content,
                IsVisibleToSearchEngine = blogPost.IsVisibleToSearchEngine,
                MetaKeywords = blogPost.MetaKeywords,
                MetaDescription = blogPost.MetaDescription,
                MetaOgImage = blogPost.MetaOgImage,
            };

           
            return View(viewmodle);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var blogPost = uow.BlogPostRepository.GetById(id);
            uow.BlogPostRepository.Remove(blogPost);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}