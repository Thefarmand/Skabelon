using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.Model
{
    public class Cars
    {
        public int car_id { get; set; }
        public string car_model { get; set; }
        public string car_type { get; set; }
        public int car_year { get; set; }
        public int car_price { get; set; }

        //public Cars(string model, string type, int year, int price)
        //{
        //    _model = model;
        //    _type = type;
        //    _year = year;
        //    _price = price;
        //}

        //public Cars()
        //{
        //}

        //public string Model
        //{
        //    get => _model;
        //    set => _model = value;
        //}

        //public string Type
        //{
        //    get => _type;
        //    set => _type = value;
        //}

        //public int Year
        //{
        //    get => _year;
        //    set => _year = value;
        //}

        //public int Price
        //{
        //    get => _price;
        //    set => _price = value;
        //}

        public override string ToString()
        {
            return ($"{nameof(car_id)}:{car_id}, {nameof(car_model)}:{car_model}, {nameof(car_type)}:{car_type}, {nameof(car_year)}:{car_year}, {nameof(car_price)}:{car_price}");
        }
    }
}
