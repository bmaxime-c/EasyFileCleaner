﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Ce code source a été automatiquement généré par xsd, Version=4.8.3928.0.
// 
namespace EasyFileCleanerLib.XML {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/SearchParams.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/SearchParams.xsd", IsNullable=false)]
    public partial class SearchParams {
        
        private Criteria[] criteriasField;
        
        private SearchDir[] searchDirsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Criteria[] Criterias {
            get {
                return this.criteriasField;
            }
            set {
                this.criteriasField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public SearchDir[] SearchDirs {
            get {
                return this.searchDirsField;
            }
            set {
                this.searchDirsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/SearchParams.xsd")]
    public partial class Criteria {
        
        private string filenameField;
        
        private string extensionField;
        
        private int keepField;
        
        private bool keepFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string filename {
            get {
                return this.filenameField;
            }
            set {
                this.filenameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string extension {
            get {
                return this.extensionField;
            }
            set {
                this.extensionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int keep {
            get {
                return this.keepField;
            }
            set {
                this.keepField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool keepSpecified {
            get {
                return this.keepFieldSpecified;
            }
            set {
                this.keepFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/SearchParams.xsd")]
    public partial class SearchDir {
        
        private string pathField;
        
        private bool includeSubfoldersField;
        
        private int keepField;
        
        private bool keepFieldSpecified;
        
        public SearchDir() {
            this.includeSubfoldersField = true;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool includeSubfolders {
            get {
                return this.includeSubfoldersField;
            }
            set {
                this.includeSubfoldersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int keep {
            get {
                return this.keepField;
            }
            set {
                this.keepField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool keepSpecified {
            get {
                return this.keepFieldSpecified;
            }
            set {
                this.keepFieldSpecified = value;
            }
        }
    }
}
