//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Real_Estate_Project.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class HouseRoomsMap
    {
        public int Id { get; set; }
        public Nullable<int> HouseId { get; set; }
        public Nullable<int> HouseRoomId { get; set; }
        public Nullable<double> QuantityRoom { get; set; }
    
        public virtual HouseInfomation HouseInfomation { get; set; }
        public virtual HouseRoom HouseRoom { get; set; }
    }
}