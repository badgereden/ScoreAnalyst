/*
 * 由SharpDevelop创建。
 * 用户： 刘保恩
 * 日期: 2011/11/21
 * 时间: 18:51
 * 主要功能:定义全局使用的结构体.
 * 
 */
using System.Collections.Generic;

namespace ScoreAnalyst
{

    /// <summary>
    /// MyListItem结构体的泛型实现，解决ComboBox绑定时，Index和Text的同步问题。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct MyListItem<T>
    {
        public string DisplayValue { get; set; }
        public T InterValue { get; set; }
        public MyListItem(string displayValue,T interValue):this()
         {
             DisplayValue = displayValue;
             InterValue = interValue;
        }
    }


    
}
