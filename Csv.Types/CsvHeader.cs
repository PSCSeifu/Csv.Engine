﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv.Types
{
    public class CsvHeader
    {
        public Type DataType { get; set; }
        public string DefaultValue { get; set; }
        public string FieldName { get; set; }
        public bool ForcedDefault { get; set; }
        public bool AllowNull { get; set; }
        public int OrderNo { get; set; } = 0;
        public int MinSize { get; set; } = 0;
        public int MaxSize { get; set; } = 0;

        public CsvHeader()
        {
            this.FieldName = "";
            this.DefaultValue = "";
            this.DataType = typeof(string);
            this.ForcedDefault = false;
            this.AllowNull = true;
        }
        public CsvHeader(string fieldName)
        {
            this.FieldName = fieldName;
            this.DefaultValue = "";
            this.DataType = typeof(string);
            this.ForcedDefault = false;
            this.AllowNull = true;
        }
        public CsvHeader(string fieldName, Type dataType)
        {
            this.FieldName = fieldName;
            this.DefaultValue = "";
            this.DataType = dataType;
            this.ForcedDefault = false;
            this.AllowNull = true;
        }
        public CsvHeader(string fieldName, Type dataType, int orderNo)
        {
            this.FieldName = fieldName;
            this.DefaultValue = "";
            this.DataType = dataType;
            this.ForcedDefault = false;
            this.AllowNull = true;
            this.OrderNo = orderNo;
        }
        public CsvHeader(string fieldName, Type dataType, int orderNo, int maxSize)
        {
            this.FieldName = fieldName;
            this.DefaultValue = "";
            this.DataType = dataType;
            this.ForcedDefault = false;
            this.AllowNull = true;
            this.OrderNo = orderNo;
            this.MaxSize = maxSize;
        }
        public CsvHeader(string fieldName, Type dataType, int orderNo, int maxSize, int minSize)
        {
            this.FieldName = fieldName;
            this.DefaultValue = "";
            this.DataType = dataType;
            this.ForcedDefault = false;
            this.AllowNull = true;
            this.OrderNo = orderNo;
            this.MaxSize = maxSize;
            this.MinSize = MinSize;
        }
    }
}
