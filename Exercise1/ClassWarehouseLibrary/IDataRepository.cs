﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassWarehouseLibrary
{
    interface IDataRepository
    {
        void AddClient(Client client);

        Client GetClient(int id);

        List<Client> GetAllClients();

        void UpdateClient(Client newClientInfo, int id);

        void DeleteClient(Client clientToDelete);

        void AddProduct(Product product, int key);

        Product GetProduct(int key);

        Dictionary<int, Product> GetAllProducts();

        void DeleteProduct(int key);

        void UpdateProduct(int key, Product newproductInfo);

        void AddInventoryStatus(Status inventoryStatus);

        Status GetInventoryStatus(int id);

        List<Status> GetAllInventoryStatuses();

        void DeleteInventoryStatus(Status inventoryStatus);

        void UpdateInventoryStatus(int id, Status newInventoryStatusInfo);

        void AddInvoice(Invoice invoice);

        Invoice GetInvoice(int id);

        ObservableCollection<Invoice> GetAllInvoices();

        void DeleteInvoice(Invoice invoice);

        void UpdateInvoice(int id, Invoice newInvoiceInfo);
    }
}
