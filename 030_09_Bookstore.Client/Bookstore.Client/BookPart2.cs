namespace Bookstore.Client
{
    using System;
    using System.Collections.Generic;

    // partial 类
    public partial class Book
    {
        public string Report()
        {
            return $"#{this.ID} Name:{this.Name} Price:{this.Price}";
        }
    }
}
