using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class WorkConfirmModel
    {
        public string currentOperation { get; set; }
        public string currentOperationTerm { get; set; }
        public string tabelNumber { get; set; }
        public string workerSurname { get; set; }
        public string workerName { get; set; }
        public string dateTimeConfirmation { get; set; }
    }
}