﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class ModifyProductViewModel : IViewModel
    {
        #region Properties

        public ICommand ModifyProductCommand { get; private set; }
        public ICommand BackToMainWindowCommand { get; private set; }
        public Action CloseWindow { get; set; }
        public Product Product { get; set; }
        private ProductRepostiory productRepository;

        public List<bool> Flags { get; set; }
        public List<string> Colors { get; set; }
        public List<string> SizeUnitMeasureCodes { get; set; }
        public List<string> WeightUnitMeasureCodes { get; set; }
        public List<string> ProductLines { get; set; }
        public List<string> Classes { get; set; }
        public List<string> Styles { get; set; }
        public List<string> ProductSubcategories { get; set; }
        public List<string> ProductModels { get; set; }

        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public Int16 SafetyStockLevel { get; set; }
        public Int16 ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ProductSubcategory { get; set; }
        public string ProductModel { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime SellEndDate { get; set; }
        public DateTime DiscontinuedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        #endregion

        public ModifyProductViewModel()
        {
            productRepository = new ProductRepostiory();
            ModifyProductCommand = new MyCommand(ModifyProduct);
            BackToMainWindowCommand = new MyCommand(BackToMainWindow);
            initDates();
            initComboBox();
        }

        public ModifyProductViewModel(Product product) : this()
        {
            Product = product;
            InitModifyProduct();
        }

        #region Private
        private void InitModifyProduct()
        {
            Name = Product.Name;
            ProductNumber = Product.ProductNumber;
            MakeFlag = Product.MakeFlag;
            FinishedGoodsFlag = Product.FinishedGoodsFlag;
            Color = Product.Color;
            //SafetyStockLevel = Product.SafetyStockLevel;
            //ReorderPoint = Product.ReorderPoint;
            //StandardCost = Product.StandardCost;
            //ListPrice = Product.ListPrice;
            //Size = Product.Size;
            //SizeUnitMeasureCode = Product.SizeUnitMeasureCode;
            //WeightUnitMeasureCode = Product.WeightUnitMeasureCode;
            //Weight = Product.Weight.Value;
            //DaysToManufacture = Product.DaysToManufacture;
            //ProductLine = Product.ProductLine;
            //Class = Product.Class;
            //Style = Product.Style;
            //ProductSubcategory = GetProductSubcategoryName(Product.ProductSubcategoryID.Value);
            //ProductModel = GetProductModelName(Product.ProductModelID.Value);
            //SellStartDate = Product.SellStartDate;
            //SellEndDate = Product.SellEndDate.Value;
            //DiscontinuedDate = Product.DiscontinuedDate.Value;
        }

        private void ModifyProduct()
        {
            //TODO

            //Product product = new Product();
            //product.Name = Name;
            //product.ProductNumber = ProductNumber;
            //product.MakeFlag = MakeFlag;
            //product.FinishedGoodsFlag = FinishedGoodsFlag;
            //product.Color = Color;
            //product.SafetyStockLevel = SafetyStockLevel;
            //product.ReorderPoint = ReorderPoint;
            //product.StandardCost = StandardCost;
            //product.ListPrice = ListPrice;
            //product.Size = Size;
            //product.SizeUnitMeasureCode = SizeUnitMeasureCode;
            //product.WeightUnitMeasureCode = WeightUnitMeasureCode;
            //product.Weight = Weight;
            //product.DaysToManufacture = DaysToManufacture;
            //product.ProductLine = ProductLine;
            //product.Class = Class;
            //product.Style = Style;
            //product.ProductSubcategoryID = GetProductSubcategoryID(ProductSubcategory);
            //product.ProductModelID = GetProductModelID(ProductModel);
            //product.SellStartDate = SellStartDate;
            //product.SellEndDate = SellEndDate;
            //product.DiscontinuedDate = DiscontinuedDate;
            //product.ModifiedDate = ModifiedDate;
            //product.rowguid = Guid.NewGuid();

            //if (productRepository.Add(product))
            //{
            //    CloseWindow();
            //}
        }

        private int GetProductSubcategoryID(string productSubcategoryName)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductSubcategoryID != null && product.ProductSubcategory.Name.Equals(productSubcategoryName)
                    select product.ProductSubcategory.ProductSubcategoryID).First();
        }

        private string GetProductSubcategoryName(int index)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductSubcategoryID != null && product.ProductSubcategoryID == index
                    select product.ProductSubcategory.Name).First();
        }

        private int GetProductModelID(string productModelName)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductModelID != null && product.ProductModel.Name.Equals(productModelName)
                    select product.ProductModel.ProductModelID).First();
        }

        private string GetProductModelName(int index)
        {
            List<Product> products = this.productRepository.GetAllProduct();
            return (from product in products
                    where product.ProductModelID != null && product.ProductModelID == index
                    select product.ProductModel.Name).First();
        }

        private void BackToMainWindow()
        {
            CloseWindow();
        }

        private void initDates()
        {
            this.SellStartDate = DateTime.Now;
            this.SellEndDate = DateTime.Now;
            this.DiscontinuedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }

        private void initComboBox()
        {
            List<Product> products = this.productRepository.GetAllProduct();
            this.Flags = new List<bool> { true, false };
            this.Colors = (from product in products
                           select product.Color).Distinct().ToList();

            this.SizeUnitMeasureCodes = (from product in products
                                         where product.SizeUnitMeasureCode != null
                                         select product.SizeUnitMeasureCode).Distinct().ToList();

            this.WeightUnitMeasureCodes = (from product in products
                                           where product.WeightUnitMeasureCode != null
                                           select product.WeightUnitMeasureCode).Distinct().ToList();

            this.ProductLines = (from product in products
                                 where product.ProductLine != null
                                 select product.ProductLine).Distinct().ToList();

            this.Classes = (from product in products
                            where product.Class != null
                            select product.Class).Distinct().ToList();

            this.Styles = (from product in products
                           where product.Style != null
                           select product.Style).Distinct().ToList();

            this.ProductSubcategories = (from product in products
                                         where product.ProductSubcategory != null
                                         select product.ProductSubcategory.Name).Distinct().ToList();

            this.ProductModels = (from product in products
                                  where product.ProductModel != null
                                  select product.ProductModel.Name).Distinct().ToList();
        }
        #endregion
    }
}
