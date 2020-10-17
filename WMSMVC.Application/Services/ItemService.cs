using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Application.Intefaces;
using WMSMVC.Application.ViewModels.Items;
using WMSMVC.Domain.Intefaces;
using WMSMVC.Web.Models;

namespace WMSMVC.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }
        public int Add(ItemVM item)
        {
            var name = item.Name;
            var it = _itemRepository.GetItemByName(name);
            if (it == null)
            {
                var itemVM = _mapper.Map<Item>(item);
                var id = _itemRepository.AddItem(itemVM);
                return id;
            }
            else
            {
                return 0;
            }
        }

        public void EditPrice(int id)
        {
            _itemRepository.EditPrice(id);
        }

        public void EditQuantity(int id)
        {
            _itemRepository.EditQuantity(id);
        }

        public ItemVM GetItem(int id)
        {
            var item = _itemRepository.GetItem(id);
            var itemVM = _mapper.Map<ItemVM>(item);
            return itemVM;
        }

        public ListItemsVM GetItems()
        {
            var items = _itemRepository.GetItems().ProjectTo<ItemVM>(_mapper.ConfigurationProvider).ToList();
            var listOfItems = new ListItemsVM()
            {
                Items = items,
                Count = items.Count
            };
            return listOfItems;
        }

        public ListItemsVM GetItemsByCategory(int id)
        {
            var items = _itemRepository.GetItemsByCategory(id);
            var itemsVM = _mapper.Map<ListItemsVM>(items);
            return itemsVM;
        }

        public void Remove(int id)
        {
            _itemRepository.RemoveItem(id);
        }

        public void Update(ItemVM item)
        {
            var it = _mapper.Map<Item>(item);
            _itemRepository.UpdateItem(it);
        }
    }
}
