using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Application.Intefaces;
using WMSMVC.Application.ViewModels.Category;
using WMSMVC.Domain.Intefaces;
using WMSMVC.Web.Models;

namespace WMSMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public int AddCategory(CategoryVM category)
        {
            var cat = _mapper.Map<Category>(category);
            var id = _categoryRepository.AddCategory(cat);
            return id;
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.RemoveCategory(id);
        }

        public ListCategories GetCategories()
        {
            var categories = _categoryRepository.GetCategories().ProjectTo<CategoryVM>(_mapper.ConfigurationProvider).ToList();
            var catVM = new ListCategories()
            {
                Categories = categories,
                Count = categories.Count
            };
            return catVM;
        }

        public CategoryVM GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            var categoryVM = _mapper.Map<CategoryVM>(category);
            return categoryVM;
        }

        public void UpdateCategory(CategoryVM category)
        {
            var categoryVM = _mapper.Map<Category>(category);
            _categoryRepository.UpdateCategory(categoryVM);
        }
    }
}
