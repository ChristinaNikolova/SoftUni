namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<CreateOrderItemsViewModel> Items { get; set; }

        public List<CreateOrderEmployeesViewModel> Employees { get; set; }
    }
}
