using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OscarAlg
{
    internal class Linkedlist
    {

        // 設定 DLL 檔名，確保 DLL 和 C# 程式在同一個資料夾內
        private const string DLL_NAME = "Mylinkedlist.dll";

        // 使用 DllImport 宣告 C++ 函數
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateLinkedListInt();  // 為 int 類型創建鏈表

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateLinkedListString();  // 為 string 類型創建鏈表

        [DllImport(DLL_NAME, EntryPoint = "AppendInt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Add(IntPtr list, int value);

        [DllImport(DLL_NAME, EntryPoint = "AppendString", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Add(IntPtr list, string _str);

        [DllImport(DLL_NAME, EntryPoint = "GetIntAt", CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetAt(IntPtr list, int index);

        [DllImport(DLL_NAME, EntryPoint = "GetStringCopyAt", CallingConvention = CallingConvention.Cdecl)]
        private static extern string GetCopyAt(IntPtr list, int index);
        //**
        [DllImport(DLL_NAME, EntryPoint = "CreateLinkedListIntFromExisting", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CopyInt(IntPtr list);
        [DllImport(DLL_NAME, EntryPoint = "CreateLinkedListStringFromExisting", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CopyStr(IntPtr list);
        //**
        [DllImport(DLL_NAME, EntryPoint = "PopListInt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PopInt(IntPtr list);

        [DllImport(DLL_NAME, EntryPoint = "PopListstring", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PopStr(IntPtr list);

        [DllImport(DLL_NAME, EntryPoint = "DeleteInt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeleteInt(IntPtr list, int _val, bool IsAll);

        [DllImport(DLL_NAME, EntryPoint = "Deletestring", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeleteStr(IntPtr list, string _val, bool IsAll);

        [DllImport(DLL_NAME, EntryPoint = "InsertInt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void InsertInt(IntPtr list, int _location, int _val);

        [DllImport(DLL_NAME, EntryPoint = "Insertstring", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Insertstr(IntPtr list, int _location, string _str);

        [DllImport(DLL_NAME, EntryPoint = "RemoveAtInt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RemoveIntAt(IntPtr list, int _location);

        [DllImport(DLL_NAME, EntryPoint = "RemoveAtString", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RemoveStrAt(IntPtr list, int _location);

        [DllImport(DLL_NAME, EntryPoint = "PrintAllInt", CallingConvention = CallingConvention.Cdecl)]
        private static extern string PrintAllInt(IntPtr list);

        [DllImport(DLL_NAME, EntryPoint = "PrintAllIstring", CallingConvention = CallingConvention.Cdecl)]
        private static extern string PrintAllIstring(IntPtr list);
        [DllImport(DLL_NAME, EntryPoint = "DeleteLinkedListInt", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeleteLinkedListInt(IntPtr list);

        [DllImport(DLL_NAME, EntryPoint = "DeleteLinkedListString", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeleteLinkedListString(IntPtr list);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetNextNode(IntPtr node); //不能用，node沒包出來
        [DllImport(DLL_NAME, EntryPoint = "FreeString", CallingConvention = CallingConvention.Cdecl)]
        private static extern void FreeString(IntPtr str);  //之前為了讓String釋放，目前不用

        //-------
        // 建立一個鏈表
        public IntPtr List;

        public Linkedlist(bool isStringType = false)
        {
            // 根據傳入的參數選擇創建對應類型的鏈表
            List = isStringType? CreateLinkedListString():CreateLinkedListInt();
        }

        public IntPtr Copy(IntPtr _List)
        {
            return CopyInt(_List);
        }

        public IntPtr CopyString(IntPtr _List)
        {
            return CopyStr(_List);
        }
        // 加入整數到鏈表
        public void Add(int value)
        {
            Add(List, value);
        }

        // 加入整數到鏈表
        public void Add(string value)
        {
            Add(List, value);
        }

        // 取得鏈表指定位置的數值
        public int Get(int index)
        {
            return GetAt(List, index);
        }
        public string GetString(int index)
        {
            return GetCopyAt(List, index);
        }
        public void Pop()
        {
            PopInt(List);
        }
        public void PopString()
        {
            PopStr(List);
        }

        public void Delete(int _val, bool IsAll = true)
        {
            DeleteInt(List, _val,IsAll);
        }
        public void DeleteString(string _val, bool IsAll = true)
        {
            DeleteStr(List, _val, IsAll);
        }

        public void Insert(int _location, int _val)
        {
            InsertInt(List, _location, _val);
        }
        public void InsertString(int _location, string _str)
        {
            Insertstr(List, _location, _str);
        }

        public void RemoveAt(int _location)
        {
            RemoveIntAt(List, _location);
        }
        public void RemoveStringAt(int _location)
        {
            RemoveStrAt(List, _location);
        }

        public string PrintAll()
        {
            return PrintAllInt(List);
        }
        public string PrintAllString()
        {
            return PrintAllIstring(List);
        }

        public void FreeALLInt()
        {
            DeleteLinkedListInt(List);
            if (List != IntPtr.Zero)
            {
                //Marshal.FreeHGlobal(List);  // 釋放記憶體(不知道為什麼會閃退)
                List = IntPtr.Zero;
            }
        }
        public void FreeALLString()
        {
            DeleteLinkedListString(List);
            if (List != IntPtr.Zero)
            {
                //Marshal.FreeHGlobal(List);  // 釋放記憶體(不知道為什麼會閃退)
                List = IntPtr.Zero;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public void Free(IntPtr _str)
        {
            FreeString(_str);
        }
    }
}
