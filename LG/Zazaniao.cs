using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Zazaniao
{
    

    public class ZazaniaoDll
    {
        [DllImport("ZazaniaoHalconDll.dll")]
        //        public static extern void GetDirectoryEx(StringBuilder Path);
        //         [DllImport("ZazaniaoHalconDll.dll")]
        public static extern string GetDirectoryEx();


        // 延时time毫秒
        //        [DllImport("ZazaniaoHalconDll.dll")]
        //	    public static extern void  DelayEx(uint time);

        // 目录是否存在的检查
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern bool FolderExistEx(string strPath);

        //某个硬盘分区是否存在.分区必须大写
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern bool DiskExistEx(string stDiskName);

        //         [DllImport("ZazaniaoHalconDll.dll")]
        // 	public static extern void  CreateFolderEx(string szDirPath) ;

        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern void CreateAllDirectoryEx(string szPath);
        //Get Current Time 
        [DllImport("ZazaniaoHalconDll.dll")]
        //       public static extern void GetCurrentTimeAsStringEx(StringBuilder szTime);
        public static extern string GetCurrentTimeAsStringEx();
        // 文件存在
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern bool FileExistEx(string FileName);
        // 删除目录
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern bool DeleteDirectoryEx(string DirName);



        //save log file
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern void LogEx(string szPath, string szText, bool bWriteFirstLine, string szFirstLineText);

        // 	void  Find_Keyword_File(char * strPath, char * &PathFull,char * KeyWord);

        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern double RadEx(double dAngle);
        [DllImport("ZazaniaoHalconDll.dll")]
        public static extern double DegEx(double dAngle);
        //         [DllImport("ZazaniaoHalconDll.dll")]
        //         public static extern double GetPrivateProfileDoubleEx(
        //             string lpAppName,
        //             string lpKeyName,
        //             double dDefault,
        //             string lpFileName);
        //         [DllImport("ZazaniaoHalconDll.dll")]
        //         public static extern void GetPrivateProfileStringEx(
        //             string lpAppName,
        //             string lpKeyName,
        //             string lpDefault,
        //             string lpFileName, StringBuilder Value);
        //         //         [DllImport("ZazaniaoHalconDll.dll")]
        //         //         public static extern bool CopyDirEx(string strSrcPath, string strDstPath);
        //         //         [DllImport("ZazaniaoHalconDll.dll")]
        //         //         public static extern bool CopyFileAndFolderEx(string strSrcPath, string strDstPath);


        #region ini 文件读写函数

        /// <summary>
        /// 读取INI文件中指定的Key的值
        /// </summary>
        /// <param name="lpAppName">节点名称。如果为null,则读取INI中所有节点名称,每个节点名称之间用\0分隔</param>
        /// <param name="lpKeyName">Key名称。如果为null,则读取INI中指定节点中的所有KEY,每个KEY之间用\0分隔</param>
        /// <param name="lpDefault">读取失败时的默认值</param>
        /// <param name="lpReturnedString">读取的内容缓冲区，读取之后，多余的地方使用\0填充</param>
        /// <param name="nSize">内容缓冲区的长度</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>实际读取到的长度</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, uint nSize, string lpFileName);

        //另一种声明方式,使用 StringBuilder 作为缓冲区类型的缺点是不能接受\0字符，会将\0及其后的字符截断,
        //所以对于lpAppName或lpKeyName为null的情况就不适用
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        //再一种声明，使用string作为缓冲区的类型同char[]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnedString, uint nSize, string lpFileName);

        /// <summary>
        /// 将指定的键和值写到指定的节点，如果已经存在则替换
        /// </summary>
        /// <param name="lpAppName">节点名称</param>
        /// <param name="lpKeyName">键名称。如果为null，则删除指定的节点及其所有的项目</param>
        /// <param name="lpString">值内容。如果为null，则删除指定节点中指定的键。</param>
        /// <param name="lpFileName">INI文件</param>
        /// <returns>操作是否成功</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);


        #endregion

    }
}
