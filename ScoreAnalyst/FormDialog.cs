using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ScoreAnalyst
{
    public partial class FormDialog : Form
    {
        public event ValueChangedEventHandle ValueChanded;
        private ValueChangedType _valueChangedType;
        string _attributeValue, _attributeName;
        public FormDialog()
        {
            InitializeComponent();
            this.Text = "新建";

            this.tbName.Clear();
            this.tbValue.Clear();
            _valueChangedType = ValueChangedType.CREATE;
        }
        public FormDialog(string attributeName,string attributeValue,ValueChangedType valueChangedType) 
        {
            InitializeComponent();
            _valueChangedType = valueChangedType;
            _attributeName = attributeName;
            _attributeValue = attributeValue;
            this.tbName.Text = attributeName;
            this.tbValue.Text = attributeValue;
            switch (_valueChangedType)
            {
                case ValueChangedType.EDIT:
                    {
                        this.tbName.Enabled = false;
                        break;
                    }
                case ValueChangedType.RENAME:
                    {
                        this.tbValue.Enabled = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
        }




        private void btnEnter_Click(object sender, EventArgs e)
        {
                if (!CheckTextValid())
                return;
                if (ValueChanded != null)
                {
                    ValueChanded(new ValueChangedEventArgs(tbName.Text, tbValue.Text,_attributeName,_attributeValue,_valueChangedType));
                }
        }

        private bool  CheckTextValid()
        {
            if (tbName.Text.Length == 0)
            {
                MessageBox.Show("属性的名字不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbValue.Text.Length == 0)
            {
                MessageBox.Show("属性的值不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }

    public delegate void ValueChangedEventHandle(ValueChangedEventArgs vce);
    public class ValueChangedEventArgs : System.EventArgs
    {
        public ValueChangedType ChangedType { get; set; }
        public string OrignalAttributeName { set; get; }
        public string OrignalAttributeValue { get; set; }
        public string AttributeName { set; get; }
        public string AttributeValue { set; get; }
        public ValueChangedEventArgs(string attributeName, string attributeValue,string orignalAttributeName,string orignalAttributeValue,ValueChangedType changedType)
        {
            AttributeName = attributeName;
            AttributeValue = attributeValue;
            OrignalAttributeName = orignalAttributeName;
            OrignalAttributeValue = orignalAttributeValue;
            ChangedType = changedType;
        }
    }
    public enum ValueChangedType
    { 
        NONE=0,
        EDIT,
        DELETE,
        CREATE,
        RENAME
    }
}
