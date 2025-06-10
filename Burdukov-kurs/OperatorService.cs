using System;

namespace Burdukov_kurs
{
    public class OperatorService
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        // public Guid? TariffId { get; set; } // Если услуга связана с конкретным тарифом

        public OperatorService(string name, decimal price, string description = "")
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
        }

        // Для возможности редактирования и загрузки из файла
        public OperatorService(Guid id, string name, decimal price, string description = "")
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name} ({Price:C})";
        }
    }
}