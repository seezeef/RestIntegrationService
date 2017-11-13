using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsIntegrationService.Models
{
    public class TransferModel<T>
    {
        private string _onyxActiveNumber;
        private string _onyxProjectNumber;
        private string _codeCostCenter;

        public T Items { get; set; }
        public string DatabaseName { get; set; }
        public int OnyxBranchNumber { get; set; }
        public string OnyxActiveNumber
        {
            get
            {
                return string.IsNullOrEmpty(_onyxActiveNumber) ? "NULL" : _onyxActiveNumber;
            }
            set
            {
                _onyxActiveNumber = value;
            }
        }
        public string OnyxProjectNumber
        {
            get
            {
                return string.IsNullOrEmpty(_onyxProjectNumber) ? "NULL" : _onyxProjectNumber;
            }
            set
            {
                _onyxProjectNumber = value;
            }
        }
        public string CodeCostCenter
        {
            get
            {
                return string.IsNullOrEmpty(_codeCostCenter) ? "NULL" : _codeCostCenter;
            }
            set
            {
                _codeCostCenter = value;
            }
        }
    }
}