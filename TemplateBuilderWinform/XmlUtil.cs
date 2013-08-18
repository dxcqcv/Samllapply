//-----------------------------------------------------------------------
// <copyright file="XmlManager.cs" company="YGSoft Corp">
//     Copyright (c) YGSoft Corp. All rights reserved.
// </copyright>
// <summary>XmlManager description</summary>
// <author>wuyongbo 2009-11-09</author>
//-----------------------------------------------------------------------
namespace TemplateBuilderWinform
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using System.IO;

    /// <summary>
    /// XML 文件读写帮助类
    /// 包括对节点的读写 属性的读写 保存  是否存在某个节点
    /// 节点定位采用xpath，包含命名空间xpath的需要特殊处理
    /// </summary>
    public class XmlUtil
    {
        #region 全局变量
        /// <summary>
        /// xmlDocument 变量
        /// </summary>
        private XmlDocument xml = null;

        /// <summary>
        /// XML 命名控件管理变量
        /// </summary>
        private XmlNamespaceManager xmlNS = null;

        /// <summary>
        /// 命名空间的前缀 自定义的一个变量
        /// </summary>
        string prefix = string.Empty;

        /// <summary>
        /// 命名控件的URI
        /// </summary>
        string nsUri = string.Empty;

        private string xmlFile = string.Empty;
        #endregion

        #region 构造函数

        public XmlUtil()
        {
        }
        /// <summary>
        /// 构造函数 传递一个xml 文件
        /// </summary>
        /// <param name="sXmlFileName">包含xml文件的完整路径  eg: d:\config\YGFinanceConfig.xml</param>
        public XmlUtil(string sXmlFileName)
        {
            if (!string.IsNullOrEmpty(sXmlFileName))
            {
                this.xmlFile = sXmlFileName;
                this.xml = LoadXmlFromFile(sXmlFileName);
                this.addPrefixToXMLNameSpace();
            }
        }

        /// <summary>
        /// 构造函数 传递一个xml 文件
        /// </summary>
        /// <param name="sXmlFileName">包含xml文件的完整路径  eg: d:\config\YGFinanceConfig.xml</param>
        /// <param name="encoding">XML文件的编码格式</param>
        public XmlUtil(string sXmlFileName, Encoding encoding)
        {
            if (!string.IsNullOrEmpty(sXmlFileName))
            {
                this.xmlFile = sXmlFileName;
                this.xml = LoadXmlFromFileByEncoding(sXmlFileName, encoding);
                this.addPrefixToXMLNameSpace();
            }
        }

        /// <summary>
        /// 构造函数 传递一个XmlDocument 变量
        /// </summary>
        /// <param name="xmlDoc"></param>
        public XmlUtil(XmlDocument xmlDoc)
        {
            if (xmlDoc != null)
            {
                this.xml = xmlDoc;
                this.addPrefixToXMLNameSpace();
            }
        }
        #endregion

        #region 属性
        /// <summary>
        /// xmlDocument 变量
        /// </summary>
        public XmlDocument xmlDoc
        {
            get { return xml; }
        }

        /// <summary>
        /// 前缀变量
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
        }
        #endregion

        #region 读取xml文件
        /// <summary>
        /// 加载XML文件为一个XMLDocument变量
        /// </summary>
        /// <param name="sXmlFileName"></param>
        /// <returns></returns>
        public XmlDocument LoadXmlFromFile(string sXmlFileName)
        {
            try
            {
                StreamReader sr = new StreamReader(sXmlFileName);
                string sxml = sr.ReadToEnd();
                sr.Close();
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(sxml);
                return xd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 加载XML文件为一个XMLDocument变量
        /// 根据编码来读取XML文件
        /// </summary>
        /// <param name="sXmlFileName"></param>
        /// <param name="encoding">文件的编码</param>
        /// <returns></returns>
        public XmlDocument LoadXmlFromFileByEncoding(string sXmlFileName, Encoding encoding)
        {
            try
            {
                string sxml = File.ReadAllText(sXmlFileName, encoding);
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(sxml);
                return xd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region 获取XMLNode
        /// <summary>
        /// 根据XPath获取XML结点
        /// 如果不存在该节点，则返回Null
        /// </summary>
        /// <param name="xPath">xml path路径</param>
        /// <returns>xml node</returns>
        public XmlNode GetExistNode(string xPath)
        {
            XmlNode result = null;
            if (string.IsNullOrEmpty(nsUri))
            {
                result = xml.SelectSingleNode(xPath);
            }
            else
            {
                result = xml.SelectSingleNode(xPath, xmlNS);
            }

            return result;
        }

        /// <summary>
        /// 获取一个xmlnode ,如果不存在，则创建该node
        /// </summary>
        /// <param name="xPath">xmlpath</param>
        /// <returns>xml node</returns>
        public XmlNode GetNode(string xPath)
        {
            XmlNode result = this.GetExistNode(xPath);
            if (result == null)
            {
                string[] paths = xPath.Split(new char[1] { '/' });
                if (paths.Length > 1)
                {
                    string parentPath = string.Join("/", paths, 0, paths.Length - 1);
                    XmlNode node = GetNode(parentPath);
                    result = xml.CreateElement(paths[paths.Length - 1]);
                    result = node.AppendChild(result);
                }
                else
                {
                    result = xml.CreateElement(xPath);
                    result = xml.AppendChild(result);
                }
            }

            return result;
        }

        #endregion

        #region 设置节点的值
        /// <summary>
        /// 设置结点的属性值 
        /// 如果节点不存在，则返回，
        /// 如果属性不存在，则添加属性
        /// </summary>
        /// <param name="xPath">xml path 路径</param>
        /// <param name="attributeName">属性的名称</param>
        /// <param name="value">属性的值</param>
        public void SetAttributeValue(string xPath, string attributeName, object value)
        {
            XmlNode node = GetExistNode(xPath);
            if (node == null)
                return;
            if (node.Attributes[attributeName] == null)
            {
                XmlAttribute attr = xml.CreateAttribute(attributeName);
                attr.Value = value.ToString();
                node.Attributes.Append(attr);
            }
            else
            {
                if (value == null)
                    node.Attributes[attributeName].Value = string.Empty;
                else
                    node.Attributes[attributeName].Value = value.ToString();
            }
        }

        /// <summary>
        /// 设置一个节点的属性值,
        /// 如果节点不存在，则创建节点 ，如果属性不存在，则创建属性
        /// </summary>
        /// <param name="node">一个xmlnode的节点</param>
        /// <param name="attributeName">属性名称</param>
        /// <param name="value">属性值</param>
        public void SetNodeAttrValue(string xpath, string attributeName, object value)
        {
            XmlNode node = this.GetNode(xpath);
            if (node == null)
                return;
            if (node.Attributes[attributeName] == null)
            {
                XmlAttribute attr = xml.CreateAttribute(attributeName);
                attr.Value = value.ToString();
                node.Attributes.Append(attr);
            }
            else
            {
                if (value == null)
                    node.Attributes[attributeName].Value = "";
                else
                    node.Attributes[attributeName].Value = value.ToString();
            }
        }
        #endregion

        #region 删除XMLNode
        /// <summary>
        /// 根据XPath获取XML结点
        /// 如果存在该节点，删除该节点
        /// </summary>
        /// <param name="xPath">xml path路径</param>
        public void RemoveNode(string xPath)
        {
            XmlNode node = this.GetExistNode(xPath);
            if (node != null)
            {
                node.ParentNode.RemoveChild(node);
              //  this.xml.RemoveChild(node);
            }
        }
        #endregion

        /// <summary>
        /// 得到一个节点  xmlnode
        /// </summary>
        /// <param name="xpath">节点的xmlpath</param>
        /// <param name="index">节点的序号</param>
        /// <returns>返回xmlnode</returns>
        public XmlNode LoadValue(string xpath, int index)
        {
            XmlNodeList nl = xml.SelectNodes(xpath);
            return nl.Item(index);
        }

        #region 设置 获取一个节点的值
        /// <summary>
        /// 设置一个节点的值 
        /// </summary>
        /// <param name="xpath">节点的xmlpath</param>
        /// <param name="value">节点的值</param>
        public void SetNodeInnerText(string xpath, object value)
        {
            XmlNode node = GetExistNode(xpath);
            if (node == null)
                return;

            if (value == null)
                node.InnerText = "";
            else
                node.InnerText = value.ToString();
        }

        /// <summary>
        /// 设置一个节点的内部xml值
        /// </summary>
        /// <param name="xpath">节点的xmlpath</param>
        /// <param name="value">xml值</param>
        public void SetNodeInnerXml(string xpath, object value)
        {
            XmlNode node = this.GetNode(xpath);
            node.InnerXml = value.ToString();
        }


        /// <summary>
        /// 得到整个节点的值
        /// </summary>
        /// <param name="xpath">节点的xmlpath</param>
        /// <returns>node.InnterText</returns>
        public string GetNodeValue(string xpath)
        {
            XmlNode nd = null;
            if (string.IsNullOrEmpty(nsUri))
            {
                nd = xml.SelectSingleNode(xpath);
            }
            else
            {
                nd = xml.SelectSingleNode(xpath, xmlNS);
            }

            return nd.InnerText;
        }
        #endregion

        #region 读取属性值

        /// <summary>
        /// 得到某个节点的某个属性的值
        /// 如果节点不存在，返回默认值
        /// 如果节点的属性不存在，返回默认值
        /// </summary>
        /// <param name="xpath">xml path</param>
        /// <param name="attributeName">属性名称</param>
        /// <param name="defaultValue">节点的默认值</param>
        /// <returns>属性的值 string 类型</returns>
        public string GetAttributeValue(string xpath, string attributeName, string defaultValue)
        {
            XmlNode nd = null;
            if (string.IsNullOrEmpty(nsUri))
            {
                nd = xml.SelectSingleNode(xpath);
            }
            else
            {
                nd = xml.SelectSingleNode(xpath, xmlNS);
            }

            if (nd == null)
            {
                return defaultValue;
            }

            if (nd.Attributes[attributeName] != null)
            {
                return nd.Attributes[attributeName].Value;
            }

            return defaultValue;
        }

        /// <summary>
        /// 获取XML 节点的属性
        /// </summary>
        /// <param name="node">XmlNode 变量</param>
        /// <param name="attributeName">属性名称</param>
        /// <param name="defaultValue">如果node = null || node.Attributes[attributeName] = Null 时的默认值</param>
        /// <returns>属性值 string 类型</returns>
        private string GetAttributeValue(XmlNode node, string attributeName, string defaultValue)
        {
            if (node == null)
            {
                return defaultValue;
            }

            if (node.Attributes[attributeName] != null)
            {
                return node.Attributes[attributeName].Value;
            }
            else
            {
                return defaultValue;
            }
        }
        #endregion

        /// <summary>
        /// 是否存在一个节点
        /// </summary>
        /// <param name="xpath">xml path路径</param>
        /// <returns></returns>
        public bool IsExistNode(string xpath)
        {
            XmlNode node = null;
            if (string.IsNullOrEmpty(nsUri))
            {
                node = xml.SelectSingleNode(xpath);
            }
            else
            {
                node = xml.SelectSingleNode(xpath, xmlNS);
            }

            if (node == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 保存配置到XML文件
        /// </summary>
        /// <param name="sXmlFile"></param>
        public void SaveXml(string sXmlFile)
        {
            xml.Save(sXmlFile);
        }

        /// <summary>
        /// 保存配置到构造函数传递的xml文件
        /// </summary>
        public void Save()
        {
            this.xml.Save(this.xmlFile);
        }

        /// <summary>
        /// 添加命名空间前缀
        /// </summary>
        private void addPrefixToXMLNameSpace()
        {
            this.nsUri = this.xml.DocumentElement.NamespaceURI;    //得到xml的命名空间
            if (!string.IsNullOrEmpty(this.nsUri))
            {
                this.xmlNS = new XmlNamespaceManager(this.xml.NameTable);
                this.xmlNS.AddNamespace("ab", this.nsUri);
                this.prefix = "ab";
            }
        }

    }
}
