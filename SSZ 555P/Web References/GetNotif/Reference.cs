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

namespace SSZ.GetNotif {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="YSFC_GET_NOTIF_PRO_ITEMS_BIND", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YSFC_GET_NOTIF_PRO_ITEMS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback YsfcGetNotifProItemsWsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public YSFC_GET_NOTIF_PRO_ITEMS() {
            this.Url = global::SSZ.Properties.Settings.Default.SSZ_GetNotif_YSFC_GET_NOTIF_PRO_ITEMS;
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
        public event YsfcGetNotifProItemsWsCompletedEventHandler YsfcGetNotifProItemsWsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:sap-com:document:sap:soap:functions:mc-style:YSFC_GET_NOTIF_PRO_ITEMS_WEBS:Ys" +
            "fcGetNotifProItemsWsRequest", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("YsfcGetNotifProItemsWsResponse", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
        public YsfcGetNotifProItemsWsResponse YsfcGetNotifProItemsWs([System.Xml.Serialization.XmlElementAttribute("YsfcGetNotifProItemsWs", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")] YsfcGetNotifProItemsWs YsfcGetNotifProItemsWs1) {
            object[] results = this.Invoke("YsfcGetNotifProItemsWs", new object[] {
                        YsfcGetNotifProItemsWs1});
            return ((YsfcGetNotifProItemsWsResponse)(results[0]));
        }
        
        /// <remarks/>
        public void YsfcGetNotifProItemsWsAsync(YsfcGetNotifProItemsWs YsfcGetNotifProItemsWs1) {
            this.YsfcGetNotifProItemsWsAsync(YsfcGetNotifProItemsWs1, null);
        }
        
        /// <remarks/>
        public void YsfcGetNotifProItemsWsAsync(YsfcGetNotifProItemsWs YsfcGetNotifProItemsWs1, object userState) {
            if ((this.YsfcGetNotifProItemsWsOperationCompleted == null)) {
                this.YsfcGetNotifProItemsWsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnYsfcGetNotifProItemsWsOperationCompleted);
            }
            this.InvokeAsync("YsfcGetNotifProItemsWs", new object[] {
                        YsfcGetNotifProItemsWs1}, this.YsfcGetNotifProItemsWsOperationCompleted, userState);
        }
        
        private void OnYsfcGetNotifProItemsWsOperationCompleted(object arg) {
            if ((this.YsfcGetNotifProItemsWsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.YsfcGetNotifProItemsWsCompleted(this, new YsfcGetNotifProItemsWsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class YsfcGetNotifProItemsWs {
        
        private string iIdField;
        
        private YsfcOperQnoticeWs iQnoticeDataField;
        
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public YsfcOperQnoticeWs IQnoticeData {
            get {
                return this.iQnoticeDataField;
            }
            set {
                this.iQnoticeDataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YsfcOperQnoticeWs {
        
        private string aufnrField;
        
        private string vornrField;
        
        private string uvornField;
        
        private string objnrField;
        
        private string asszlField;
        
        private string coordField;
        
        private string coordFnField;
        
        private string qmnumField;
        
        private string qmartField;
        
        private string qmkatField;
        
        private string qmgrpField;
        
        private string qmcodField;
        
        private string otkatField;
        
        private string otgrpField;
        
        private string oteilField;
        
        private string rkmngField;
        
        private string mgeinField;
        
        private string textField;
        
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
        public string Coord {
            get {
                return this.coordField;
            }
            set {
                this.coordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CoordFn {
            get {
                return this.coordFnField;
            }
            set {
                this.coordFnField = value;
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
        public string Qmart {
            get {
                return this.qmartField;
            }
            set {
                this.qmartField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Qmkat {
            get {
                return this.qmkatField;
            }
            set {
                this.qmkatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Qmgrp {
            get {
                return this.qmgrpField;
            }
            set {
                this.qmgrpField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Qmcod {
            get {
                return this.qmcodField;
            }
            set {
                this.qmcodField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Otkat {
            get {
                return this.otkatField;
            }
            set {
                this.otkatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Otgrp {
            get {
                return this.otgrpField;
            }
            set {
                this.otgrpField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Oteil {
            get {
                return this.oteilField;
            }
            set {
                this.oteilField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Rkmng {
            get {
                return this.rkmngField;
            }
            set {
                this.rkmngField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Mgein {
            get {
                return this.mgeinField;
            }
            set {
                this.mgeinField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YsfcQnoteItemWs {
        
        private string posnrField;
        
        private string stufeField;
        
        private string wegxxField;
        
        private string vwegxField;
        
        private string bautlField;
        
        private string prueflinrField;
        
        private string anzfehlerField;
        
        private string fmgeigField;
        
        private string fmgeinField;
        
        private string flgMarkField;
        
        private string bautlTxtField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Posnr {
            get {
                return this.posnrField;
            }
            set {
                this.posnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Stufe {
            get {
                return this.stufeField;
            }
            set {
                this.stufeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Wegxx {
            get {
                return this.wegxxField;
            }
            set {
                this.wegxxField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Vwegx {
            get {
                return this.vwegxField;
            }
            set {
                this.vwegxField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Bautl {
            get {
                return this.bautlField;
            }
            set {
                this.bautlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Prueflinr {
            get {
                return this.prueflinrField;
            }
            set {
                this.prueflinrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Anzfehler {
            get {
                return this.anzfehlerField;
            }
            set {
                this.anzfehlerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Fmgeig {
            get {
                return this.fmgeigField;
            }
            set {
                this.fmgeigField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Fmgein {
            get {
                return this.fmgeinField;
            }
            set {
                this.fmgeinField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FlgMark {
            get {
                return this.flgMarkField;
            }
            set {
                this.flgMarkField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BautlTxt {
            get {
                return this.bautlTxtField;
            }
            set {
                this.bautlTxtField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YsfcGetNotifProItemsWsResponse {
        
        private YsfcQnoteItemWs[] etQnoticeItemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public YsfcQnoteItemWs[] EtQnoticeItems {
            get {
                return this.etQnoticeItemsField;
            }
            set {
                this.etQnoticeItemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void YsfcGetNotifProItemsWsCompletedEventHandler(object sender, YsfcGetNotifProItemsWsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class YsfcGetNotifProItemsWsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal YsfcGetNotifProItemsWsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public YsfcGetNotifProItemsWsResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((YsfcGetNotifProItemsWsResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591