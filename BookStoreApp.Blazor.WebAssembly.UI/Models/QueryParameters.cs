﻿namespace BookStoreApp.Blazor.WebAssembly.UI.Models
{
    public class QueryParameters
    {
        private int _pageSize = 5;
        public int StartIndex { get; set; }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
    }
}
