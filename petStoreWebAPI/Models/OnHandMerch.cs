﻿using System;
using System.ComponentModel.DataAnnotations;

namespace petStoreWebAPI.Models
{
    public class OnHandMerch
    {
        public int OnHandMerchId { get; set; } //the primary key for the database

        [Required]
        public int ItemId { get; set; }
        [Required]
        public int QuantityonHand { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }
    }
}