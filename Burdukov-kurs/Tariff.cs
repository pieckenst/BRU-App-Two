using System;

namespace Burdukov_kurs
{
    public class Tariff
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public decimal PricePerMinute { get; set; }
        public string Description { get; set; }

        public Tariff(string name, decimal pricePerMinute, string description = "")
        {
            Id = Guid.NewGuid();
            Name = name;
            PricePerMinute = pricePerMinute;
            Description = description;
        }

        // Для возможности редактирования и загрузки из файла, может понадобиться конструктор с Id
        public Tariff(Guid id, string name, decimal pricePerMinute, string description = "")
        {
            Id = id;
            Name = name;
            PricePerMinute = pricePerMinute;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name} ({PricePerMinute:C}/мин)";
        }
    }
}