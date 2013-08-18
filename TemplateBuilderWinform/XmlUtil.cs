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
    /// XML �ļ���д������
    /// �����Խڵ�Ķ�д ���ԵĶ�д ����  �Ƿ����ĳ���ڵ�
    /// �ڵ㶨λ����xpath�����������ռ�xpath����Ҫ���⴦��
    /// </summary>
    public class XmlUtil
    {
        #region ȫ�ֱ���
        /// <summary>
        /// xmlDocument ����
        /// </summary>
        private XmlDocument xml = null;

        /// <summary>
        /// XML �����ؼ��������
        /// </summary>
        private XmlNamespaceManager xmlNS = null;

        /// <summary>
        /// �����ռ��ǰ׺ �Զ����һ������
        /// </summary>
        string prefix = string.Empty;

        /// <summary>
        /// �����ؼ���URI
        /// </summary>
        string nsUri = string.Empty;

        private string xmlFile = string.Empty;
        #endregion

        #region ���캯��

        public XmlUtil()
        {
        }
        /// <summary>
        /// ���캯�� ����һ��xml �ļ�
        /// </summary>
        /// <param name="sXmlFileName">����xml�ļ�������·��  eg: d:\config\YGFinanceConfig.xml</param>
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
        /// ���캯�� ����һ��xml �ļ�
        /// </summary>
        /// <param name="sXmlFileName">����xml�ļ�������·��  eg: d:\config\YGFinanceConfig.xml</param>
        /// <param name="encoding">XML�ļ��ı����ʽ</param>
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
        /// ���캯�� ����һ��XmlDocument ����
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

        #region ����
        /// <summary>
        /// xmlDocument ����
        /// </summary>
        public XmlDocument xmlDoc
        {
            get { return xml; }
        }

        /// <summary>
        /// ǰ׺����
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
        }
        #endregion

        #region ��ȡxml�ļ�
        /// <summary>
        /// ����XML�ļ�Ϊһ��XMLDocument����
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
        /// ����XML�ļ�Ϊһ��XMLDocument����
        /// ���ݱ�������ȡXML�ļ�
        /// </summary>
        /// <param name="sXmlFileName"></param>
        /// <param name="encoding">�ļ��ı���</param>
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

        #region ��ȡXMLNode
        /// <summary>
        /// ����XPath��ȡXML���
        /// ��������ڸýڵ㣬�򷵻�Null
        /// </summary>
        /// <param name="xPath">xml path·��</param>
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
        /// ��ȡһ��xmlnode ,��������ڣ��򴴽���node
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

        #region ���ýڵ��ֵ
        /// <summary>
        /// ���ý�������ֵ 
        /// ����ڵ㲻���ڣ��򷵻أ�
        /// ������Բ����ڣ����������
        /// </summary>
        /// <param name="xPath">xml path ·��</param>
        /// <param name="attributeName">���Ե�����</param>
        /// <param name="value">���Ե�ֵ</param>
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
        /// ����һ���ڵ������ֵ,
        /// ����ڵ㲻���ڣ��򴴽��ڵ� ��������Բ����ڣ��򴴽�����
        /// </summary>
        /// <param name="node">һ��xmlnode�Ľڵ�</param>
        /// <param name="attributeName">��������</param>
        /// <param name="value">����ֵ</param>
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

        #region ɾ��XMLNode
        /// <summary>
        /// ����XPath��ȡXML���
        /// ������ڸýڵ㣬ɾ���ýڵ�
        /// </summary>
        /// <param name="xPath">xml path·��</param>
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
        /// �õ�һ���ڵ�  xmlnode
        /// </summary>
        /// <param name="xpath">�ڵ��xmlpath</param>
        /// <param name="index">�ڵ�����</param>
        /// <returns>����xmlnode</returns>
        public XmlNode LoadValue(string xpath, int index)
        {
            XmlNodeList nl = xml.SelectNodes(xpath);
            return nl.Item(index);
        }

        #region ���� ��ȡһ���ڵ��ֵ
        /// <summary>
        /// ����һ���ڵ��ֵ 
        /// </summary>
        /// <param name="xpath">�ڵ��xmlpath</param>
        /// <param name="value">�ڵ��ֵ</param>
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
        /// ����һ���ڵ���ڲ�xmlֵ
        /// </summary>
        /// <param name="xpath">�ڵ��xmlpath</param>
        /// <param name="value">xmlֵ</param>
        public void SetNodeInnerXml(string xpath, object value)
        {
            XmlNode node = this.GetNode(xpath);
            node.InnerXml = value.ToString();
        }


        /// <summary>
        /// �õ������ڵ��ֵ
        /// </summary>
        /// <param name="xpath">�ڵ��xmlpath</param>
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

        #region ��ȡ����ֵ

        /// <summary>
        /// �õ�ĳ���ڵ��ĳ�����Ե�ֵ
        /// ����ڵ㲻���ڣ�����Ĭ��ֵ
        /// ����ڵ�����Բ����ڣ�����Ĭ��ֵ
        /// </summary>
        /// <param name="xpath">xml path</param>
        /// <param name="attributeName">��������</param>
        /// <param name="defaultValue">�ڵ��Ĭ��ֵ</param>
        /// <returns>���Ե�ֵ string ����</returns>
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
        /// ��ȡXML �ڵ������
        /// </summary>
        /// <param name="node">XmlNode ����</param>
        /// <param name="attributeName">��������</param>
        /// <param name="defaultValue">���node = null || node.Attributes[attributeName] = Null ʱ��Ĭ��ֵ</param>
        /// <returns>����ֵ string ����</returns>
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
        /// �Ƿ����һ���ڵ�
        /// </summary>
        /// <param name="xpath">xml path·��</param>
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
        /// �������õ�XML�ļ�
        /// </summary>
        /// <param name="sXmlFile"></param>
        public void SaveXml(string sXmlFile)
        {
            xml.Save(sXmlFile);
        }

        /// <summary>
        /// �������õ����캯�����ݵ�xml�ļ�
        /// </summary>
        public void Save()
        {
            this.xml.Save(this.xmlFile);
        }

        /// <summary>
        /// ��������ռ�ǰ׺
        /// </summary>
        private void addPrefixToXMLNameSpace()
        {
            this.nsUri = this.xml.DocumentElement.NamespaceURI;    //�õ�xml�������ռ�
            if (!string.IsNullOrEmpty(this.nsUri))
            {
                this.xmlNS = new XmlNamespaceManager(this.xml.NameTable);
                this.xmlNS.AddNamespace("ab", this.nsUri);
                this.prefix = "ab";
            }
        }

    }
}
