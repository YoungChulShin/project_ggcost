﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCost.DataModels
{
    public class CostHistoryModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set { selected = value; RaiseProperty(nameof(Selected)); }
        }


        /// <summary>
        /// Grid에서 표현되는 순서 값
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// CostInfo에서 Key ID 값
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 지출 날짜. DAteTime형식
        /// </summary>
        public string CostDate { get; set; }
        /// <summary>
        /// 소비 대 분류
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 소비 소 분류
        /// </summary>
        public string SubCategory { get; set; }
        /// <summary>
        /// 지출 타입. 카드 또는 현금
        /// </summary>
        public string CostType { get; set; }
        /// <summary>
        /// 지출 금액
        /// </summary>
        public string Cost { get; set; }
        /// <summary>
        /// 세부 설명
        /// </summary>
        public string Description { get; set; }
        public string Percentage { get; set; }
    }
}