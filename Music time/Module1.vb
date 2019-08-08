Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO

Module Module1
    Public Declare Function GetWindowDC Lib "user32" (ByVal hwnd As Long) As Long '获得整个屏幕绘制
    Public Declare Function GetDesktopWindow Lib "user32" () As Long '获得整个桌面绘制
    Public list As New List(Of String) From {"你来骂我啊", "傻逼看啥说的就是你", "束手无策吧", "你就只有bb的份", "嘿嘿嘿嘿"} '集合的表示方法
    Public list2 As New List(Of Brush) From {Brushes.White, Brushes.Yellow, Brushes.Red, Brushes.Pink, Brushes.Green}
    Public list3 As New List(Of FontStyle) From {FontStyle.Regular, FontStyle.Italic, FontStyle.Bold, FontStyle.Underline, FontStyle.Strikeout}
    Public Random As New Random '定义取随机值函数(性能比rnd好，函数不消耗CPU)
    Sub Main()
        Dim screen As Graphics = Graphics.FromHdc(GetWindowDC(GetDesktopWindow()))
        Do
            Dim msg As String = list.Item(Random.Next(list.Count - 1)）
            Dim color As Brush = list2.Item(Random.Next(list2.Count - 1))
            Dim fontsyle As FontStyle = list3.Item(Random.Next(list3.Count - 1))
            Threading.Thread.Sleep(100)
            Dim rect As Rectangle = Windows.Forms.Screen.PrimaryScreen.WorkingArea '获得屏幕大小
            Dim font As Font = New Font(SystemFonts.MessageBoxFont.FontFamily, Random.Next(1, 25), fontsyle) '设置字体大小取随机值
            screen.DrawString(msg, font, color, New PointF(Random.Next(rect.Width), Random.Next(rect.Height)))
        Loop
    End Sub
End Module