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

namespace SSZ.ReuseGrid {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="YGUI_REUSE_GRID_VARIANT_BIND", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YGUI_REUSE_GRID_VARIANT : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback YguiReuseGridVariantWsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public YGUI_REUSE_GRID_VARIANT() {
            this.Url = global::SSZ.Properties.Settings.Default.SSZ_ReuseGrid_YGUI_REUSE_GRID_VARIANT;
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
        public event YguiReuseGridVariantWsCompletedEventHandler YguiReuseGridVariantWsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:sap-com:document:sap:soap:functions:mc-style:YGUI_REUSE_GRID_VARIANT_WEBS:Ygu" +
            "iReuseGridVariantWsRequest", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("YguiReuseGridVariantWsResponse", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
        public YguiReuseGridVariantWsResponse YguiReuseGridVariantWs([System.Xml.Serialization.XmlElementAttribute("YguiReuseGridVariantWs", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")] YguiReuseGridVariantWs YguiReuseGridVariantWs1) {
            object[] results = this.Invoke("YguiReuseGridVariantWs", new object[] {
                        YguiReuseGridVariantWs1});
            return ((YguiReuseGridVariantWsResponse)(results[0]));
        }
        
        /// <remarks/>
        public void YguiReuseGridVariantWsAsync(YguiReuseGridVariantWs YguiReuseGridVariantWs1) {
            this.YguiReuseGridVariantWsAsync(YguiReuseGridVariantWs1, null);
        }
        
        /// <remarks/>
        public void YguiReuseGridVariantWsAsync(YguiReuseGridVariantWs YguiReuseGridVariantWs1, object userState) {
            if ((this.YguiReuseGridVariantWsOperationCompleted == null)) {
                this.YguiReuseGridVariantWsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnYguiReuseGridVariantWsOperationCompleted);
            }
            this.InvokeAsync("YguiReuseGridVariantWs", new object[] {
                        YguiReuseGridVariantWs1}, this.YguiReuseGridVariantWsOperationCompleted, userState);
        }
        
        private void OnYguiReuseGridVariantWsOperationCompleted(object arg) {
            if ((this.YguiReuseGridVariantWsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.YguiReuseGridVariantWsCompleted(this, new YguiReuseGridVariantWsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class YguiReuseGridVariantWs {
        
        private string iActionField;
        
        private string iFuncMappedNameField;
        
        private string iHandleField;
        
        private string iIdField;
        
        private string iParamMappedNameField;
        
        private string iSharedField;
        
        private YguiFieldDescWs[] itVariantDescWsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IAction {
            get {
                return this.iActionField;
            }
            set {
                this.iActionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IFuncMappedName {
            get {
                return this.iFuncMappedNameField;
            }
            set {
                this.iFuncMappedNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IHandle {
            get {
                return this.iHandleField;
            }
            set {
                this.iHandleField = value;
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IParamMappedName {
            get {
                return this.iParamMappedNameField;
            }
            set {
                this.iParamMappedNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IShared {
            get {
                return this.iSharedField;
            }
            set {
                this.iSharedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public YguiFieldDescWs[] ItVariantDescWs {
            get {
                return this.itVariantDescWsField;
            }
            set {
                this.itVariantDescWsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YguiFieldDescWs {
        
        private string typenameField;
        
        private string fieldnameField;
        
        private string inttypeField;
        
        private string intlenField;
        
        private string fieldtextField;
        
        private string reptextField;
        
        private string scrtextSField;
        
        private string scrtextMField;
        
        private string scrtextLField;
        
        private string f4availablField;
        
        private string colPosField;
        
        private string noOutField;
        
        private string outputlenField;
        
        private string fontSizeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Typename {
            get {
                return this.typenameField;
            }
            set {
                this.typenameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Fieldname {
            get {
                return this.fieldnameField;
            }
            set {
                this.fieldnameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Inttype {
            get {
                return this.inttypeField;
            }
            set {
                this.inttypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Intlen {
            get {
                return this.intlenField;
            }
            set {
                this.intlenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Fieldtext {
            get {
                return this.fieldtextField;
            }
            set {
                this.fieldtextField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Reptext {
            get {
                return this.reptextField;
            }
            set {
                this.reptextField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ScrtextS {
            get {
                return this.scrtextSField;
            }
            set {
                this.scrtextSField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ScrtextM {
            get {
                return this.scrtextMField;
            }
            set {
                this.scrtextMField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ScrtextL {
            get {
                return this.scrtextLField;
            }
            set {
                this.scrtextLField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string F4availabl {
            get {
                return this.f4availablField;
            }
            set {
                this.f4availablField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ColPos {
            get {
                return this.colPosField;
            }
            set {
                this.colPosField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NoOut {
            get {
                return this.noOutField;
            }
            set {
                this.noOutField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Outputlen {
            get {
                return this.outputlenField;
            }
            set {
                this.outputlenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FontSize {
            get {
                return this.fontSizeField;
            }
            set {
                this.fontSizeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class YguiReuseGridVariantWsResponse {
        
        private string eFoundField;
        
        private YguiFieldDescWs[] etVariantDescWsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EFound {
            get {
                return this.eFoundField;
            }
            set {
                this.eFoundField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public YguiFieldDescWs[] EtVariantDescWs {
            get {
                return this.etVariantDescWsField;
            }
            set {
                this.etVariantDescWsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void YguiReuseGridVariantWsCompletedEventHandler(object sender, YguiReuseGridVariantWsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class YguiReuseGridVariantWsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal YguiReuseGridVariantWsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public YguiReuseGridVariantWsResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((YguiReuseGridVariantWsResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591