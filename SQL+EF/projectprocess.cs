//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class projectprocess
    {
        public int proID { get; set; }
        public Nullable<long> productionnum { get; set; }
        public string responsibleperson { get; set; }
        public Nullable<System.DateTime> closingdate { get; set; }
        public Nullable<int> design { get; set; }
        public Nullable<int> make { get; set; }
        public Nullable<int> assemble { get; set; }
        public Nullable<int> indebug { get; set; }
        public Nullable<int> incheck { get; set; }
        public Nullable<int> storage { get; set; }
        public Nullable<int> send { get; set; }
        public Nullable<int> build { get; set; }
        public Nullable<int> outdebug { get; set; }
        public Nullable<int> outcheck { get; set; }
        public Nullable<int> service { get; set; }
    }
}
