﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Этот исходный текст был создан автоматически: Microsoft.VSDesigner, версия: 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace SSZ.GetOperService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    // CODEGEN: Необязательный элемент расширения WSDL "Policy" из пространства имен "http://schemas.xmlsoap.org/ws/2004/09/policy" не был обработан.
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="YSFC_GET_OPERATIONS_LIST_BIND", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YSFC_GET_OPERATIONS_LIST : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback YsfcGetOperationsListWsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public YSFC_GET_OPERATIONS_LIST() {
            this.Url = global::SSZ.Properties.Settings.Default.SSZ_GetOperService_YSFC_GET_OPERATIONS_LIST;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event YsfcGetOperationsListWsCompletedEventHandler YsfcGetOperationsListWsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:sap-com:document:sap:soap:functions:mc-style:YSFC_GET_OPERATIONS_LIST_WEBS:Ys" +
            "fcGetOperationsListWsRequest", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("YsfcGetOperationsListWsResponse", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
        public YsfcGetOperationsListWsResponse YsfcGetOperationsListWs([System.Xml.Serialization.XmlElementAttribute("YsfcGetOperationsListWs", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")] YsfcGetOperationsListWs YsfcGetOperationsListWs1) {
            object[] results = this.Invoke("YsfcGetOperationsListWs", new object[] {
                        YsfcGetOperationsListWs1});
            return ((YsfcGetOperationsListWsResponse)(results[0]));
        }
        
        /// <remarks/>
        public void YsfcGetOperationsListWsAsync(YsfcGetOperationsListWs YsfcGetOperationsListWs1) {
            this.YsfcGetOperationsListWsAsync(YsfcGetOperationsListWs1, null);
        }
        
        /// <remarks/>
        public void YsfcGetOperationsListWsAsync(YsfcGetOperationsListWs YsfcGetOperationsListWs1, object userState) {
            if ((this.YsfcGetOperationsListWsOperationCompleted == null)) {
                this.YsfcGetOperationsListWsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnYsfcGetOperationsListWsOperationCompleted);
            }
            this.InvokeAsync("YsfcGetOperationsListWs", new object[] {
                        YsfcGetOperationsListWs1}, this.YsfcGetOperationsListWsOperationCompleted, userState);
        }
        
        private void OnYsfcGetOperationsListWsOperationCompleted(object arg) {
            if ((this.YsfcGetOperationsListWsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.YsfcGetOperationsListWsCompleted(this, new YsfcGetOperationsListWsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YsfcGetOperationsListWs {
        
        private string iDiagField;
        
        private string iIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IDiag {
            get {
                return this.iDiagField;
            }
            set {
                this.iDiagField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IId {
            get {
                return this.iIdField;
            }
            set {
                this.iIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YsfcOperListWs {
        
        private string aufnrField;
        
        private string vornrField;
        
        private string uvornField;
        
        private string objnrField;
        
        private string asszlField;
        
        private string plnawField;
        
        private string steusField;
        
        private string ltxaField;
        
        private string werksField;
        
        private string arbplField;
        
        private string arbplTxtField;
        
        private string nprioField;
        
        private string pernrField;
        
        private string pernrFnField;
        
        private string mgvrgField;
        
        private string lmngaField;
        
        private string xmngaField;
        
        private string meinhField;
        
        private string darueField;
        
        private string rstzeField;
        
        private string acti3Field;
        
        private string unit3Field;
        
        private string ism03Field;
        
        private string ile03Field;
        
        private string ssavdField;
        
        private string ssavzField;
        
        private string sseddField;
        
        private string ssedzField;
        
        private string isddField;
        
        private string isdzField;
        
        private string ieddField;
        
        private string iedzField;
        
        private string ssttxtField;
        
        private string usttxtField;
        
        private string matnrField;
        
        private string matnrTxtField;
        
        private string sernpField;
        
        private string anzsnField;
        
        private string qmnumField;
        
        private string maknzField;
        
        private string qmcloField;
        
        private string diacoField;
        
        private string diatyField;
        
        private string diacoTxtField;

        private string[] actsAlwdField;

        private string actsAlwd1Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Aufnr {
            get {
                return this.aufnrField;
            }
            set {
                this.aufnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Vornr {
            get {
                return this.vornrField;
            }
            set {
                this.vornrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Uvorn {
            get {
                return this.uvornField;
            }
            set {
                this.uvornField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Objnr {
            get {
                return this.objnrField;
            }
            set {
                this.objnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Asszl {
            get {
                return this.asszlField;
            }
            set {
                this.asszlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Plnaw {
            get {
                return this.plnawField;
            }
            set {
                this.plnawField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Steus {
            get {
                return this.steusField;
            }
            set {
                this.steusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ltxa {
            get {
                return this.ltxaField;
            }
            set {
                this.ltxaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Werks {
            get {
                return this.werksField;
            }
            set {
                this.werksField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Arbpl {
            get {
                return this.arbplField;
            }
            set {
                this.arbplField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ArbplTxt {
            get {
                return this.arbplTxtField;
            }
            set {
                this.arbplTxtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Nprio {
            get {
                return this.nprioField;
            }
            set {
                this.nprioField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Pernr {
            get {
                return this.pernrField;
            }
            set {
                this.pernrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PernrFn {
            get {
                return this.pernrFnField;
            }
            set {
                this.pernrFnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Mgvrg {
            get {
                return this.mgvrgField;
            }
            set {
                this.mgvrgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Lmnga {
            get {
                return this.lmngaField;
            }
            set {
                this.lmngaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Xmnga {
            get {
                return this.xmngaField;
            }
            set {
                this.xmngaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Meinh {
            get {
                return this.meinhField;
            }
            set {
                this.meinhField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Darue {
            get {
                return this.darueField;
            }
            set {
                this.darueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Rstze {
            get {
                return this.rstzeField;
            }
            set {
                this.rstzeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Acti3 {
            get {
                return this.acti3Field;
            }
            set {
                this.acti3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Unit3 {
            get {
                return this.unit3Field;
            }
            set {
                this.unit3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ism03 {
            get {
                return this.ism03Field;
            }
            set {
                this.ism03Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ile03 {
            get {
                return this.ile03Field;
            }
            set {
                this.ile03Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ssavd {
            get {
                return this.ssavdField;
            }
            set {
                this.ssavdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ssavz {
            get {
                return this.ssavzField;
            }
            set {
                this.ssavzField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ssedd {
            get {
                return this.sseddField;
            }
            set {
                this.sseddField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ssedz {
            get {
                return this.ssedzField;
            }
            set {
                this.ssedzField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Isdd {
            get {
                return this.isddField;
            }
            set {
                this.isddField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Isdz {
            get {
                return this.isdzField;
            }
            set {
                this.isdzField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Iedd {
            get {
                return this.ieddField;
            }
            set {
                this.ieddField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Iedz {
            get {
                return this.iedzField;
            }
            set {
                this.iedzField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ssttxt {
            get {
                return this.ssttxtField;
            }
            set {
                this.ssttxtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Usttxt {
            get {
                return this.usttxtField;
            }
            set {
                this.usttxtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Matnr {
            get {
                return this.matnrField;
            }
            set {
                this.matnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MatnrTxt {
            get {
                return this.matnrTxtField;
            }
            set {
                this.matnrTxtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Sernp {
            get {
                return this.sernpField;
            }
            set {
                this.sernpField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Anzsn {
            get {
                return this.anzsnField;
            }
            set {
                this.anzsnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Qmnum {
            get {
                return this.qmnumField;
            }
            set {
                this.qmnumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Maknz {
            get {
                return this.maknzField;
            }
            set {
                this.maknzField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Qmclo {
            get {
                return this.qmcloField;
            }
            set {
                this.qmcloField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Diaco {
            get {
                return this.diacoField;
            }
            set {
                this.diacoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Diaty {
            get {
                return this.diatyField;
            }
            set {
                this.diatyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DiacoTxt {
            get {
                return this.diacoTxtField;
            }
            set {
                this.diacoTxtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ActsAlwd1
        {
            get
            {
                return this.actsAlwd1Field;
            }
            set
            {
                this.actsAlwd1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public string[] ActsAlwd {
            get {
                return this.actsAlwdField;
            }
            set {
                this.actsAlwdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YsfcGetOperationsListWsResponse {
        
        private YsfcOperListWs[] etOperListWsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public YsfcOperListWs[] EtOperListWs {
            get {
                return this.etOperListWsField;
            }
            set {
                this.etOperListWsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void YsfcGetOperationsListWsCompletedEventHandler(object sender, YsfcGetOperationsListWsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class YsfcGetOperationsListWsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal YsfcGetOperationsListWsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public YsfcGetOperationsListWsResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((YsfcGetOperationsListWsResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591