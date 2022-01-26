﻿using AutoMapper;
using ShopWebApi.Dtos.ShopDtos;
using ShopWebApi.Models;
using ShopWebApi.Repositories;

namespace ShopWebApi.Services
{
    public class ShopService
    {
        private readonly ShopRepository _shopRepository;
        public readonly IMapper _mapper;

        public ShopService(ShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public List<GetShop> GetAll()
        {
            var shops = _shopRepository.GetAllWithShopItems();
            if (shops == null)
            {
                throw new ArgumentException("No Shops found");
            }

            return _mapper.Map<List<GetShop>>(shops);
        }

        public GetShop GetById(int id)
        {
            var shop = _shopRepository.GetById(id);
            if (shop == null)
            {
                throw new ArgumentException("Shop not found");
            }

            return _mapper.Map<GetShop>(shop);
        }

        public int Create(CreateUpdateShop createShop)
        {
            var mappedShop = _mapper.Map<Shop>(createShop);

            var doesNameExist = _shopRepository.CheckNameExist(mappedShop.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            var model = new Shop()
            {
                Name = createShop.Name
            };

            var modelId = _shopRepository.Create(model);

            return modelId;
        }

        public int Update(int id, CreateUpdateShop updateShop)
        {
            var shop = _shopRepository.GetById(id);

            var doesNameExist = _shopRepository.CheckNameExist(updateShop.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            shop.Name = updateShop.Name;

            _shopRepository.Update(shop);

            return id;
        }

        public void Delete(int id)
        {
            _shopRepository.Delete(id);
        }
    }
}