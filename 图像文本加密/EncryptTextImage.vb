Imports System.Drawing.Drawing2D

Public Class EncryptTextImage
    'Encrypt  [v.] 加密
    'Decrypt  [v.] 解密
    'PlainText [n.] 明文
    'CipherText [n.] 密文
    'Key [n.] 密匙
    Dim ResultImage As Bitmap

    Private Function EncryptTextToImage(ByVal PlainText As String, ByVal Key As String) As Bitmap
        If PlainText = vbNullString Or Key = vbNullString Then Return Nothing

        '把明文转换成Base64密文
        Dim EncryptByte() As Byte = System.Text.Encoding.Default.GetBytes(PlainText)
        Dim Base64CipherText As String = Convert.ToBase64String(EncryptByte)

        '建立长宽比近似为1:1的位图
        Dim WidthOfImage As Integer = Math.Sqrt(Base64CipherText.Length)
        Dim EncryptImage As Bitmap = New Bitmap(WidthOfImage,
                                                CInt(Math.Ceiling(Base64CipherText.Length / WidthOfImage)))
        '加密时储存数据的变量
        Dim AscOfChar As Int16 = 0  '存放密文单个字符的Asc码
        Dim EncrryptColor As Color   '存放由字符的Asc码计算出的对应的颜色值
        Dim LengthOfKey As Integer = Key.Length '加密密匙的长度
        Dim DataPoint As Int16 '每个像素可以储存三个字节数据，根据密匙确定数据存储的位置

        '遍历Base64密文
        For PointOfChar As Long = 0 To Base64CipherText.Length - 1
            AscOfChar = Asc(Mid(Base64CipherText, PointOfChar + 1, 1)) '逐个获取密文字符串的字符
            VBMath.Randomize() '初始化随机数发生器
            DataPoint = Asc(Mid(Key, PointOfChar Mod LengthOfKey + 1, 1)) Mod 3 '根据密匙确定数据存储位置
            If DataPoint = 0 Then '数据存储于R，剩余两个字节储存进两个随机产生的虚假数据
                EncrryptColor = Color.FromArgb(AscOfChar, CInt(255 * VBMath.Rnd), CInt(255 * VBMath.Rnd))
            ElseIf DataPoint = 1 Then '数据存储于G，剩余两个字节储存进两个随机产生的虚假数据
                EncrryptColor = Color.FromArgb(CInt(255 * VBMath.Rnd), AscOfChar, CInt(255 * VBMath.Rnd))
            ElseIf DataPoint = 2 Then '数据存储于B，剩余两个字节储存进两个随机产生的虚假数据
                EncrryptColor = Color.FromArgb(CInt(255 * VBMath.Rnd), CInt(255 * VBMath.Rnd), AscOfChar)

            End If
            '把储存一个真实数据和两个虚假数据的颜色写入位图
            EncryptImage.SetPixel(PointOfChar Mod WidthOfImage, PointOfChar \ WidthOfImage, EncrryptColor)
        Next

        Return EncryptImage '加密完成，返回图像
    End Function

    Private Function DecryptTextFromImage(ByVal CipherImage As Bitmap, ByVal Key As String) As String
        If CipherImage Is Nothing Or Key = vbNullString Then Return Chr(0)

        Dim Base64CipherText As String = vbNullString '储存从图像读出的Base64密文
        Dim ValueOfColor As Integer = 0 '储存从颜色读取出的数值
        Dim WidthOfImage As Integer = CipherImage.Width '图像宽度，在下方代码用以计算字符标号
        Dim EncrryptColor As Color '加密后的颜色
        Dim LengthOfKey As Integer = Key.Length '密匙长度
        Dim DataPoint As Int16 '同上，数据储存的真实位置
        For PointY As Integer = 0 To CipherImage.Height - 1 '逐行遍历
            For PointX As Integer = 0 To CipherImage.Width - 1 '逐像素遍历
                DataPoint = Asc(Mid(Key, (PointY * WidthOfImage + PointX) Mod LengthOfKey + 1, 1)) Mod 3 '数据位置
                EncrryptColor = CipherImage.GetPixel(PointX, PointY) '从加密后的位图读取颜色
                If DataPoint = 0 Then '密文被储存在了R，忽视另外两个虚假的数据
                    ValueOfColor = EncrryptColor.R
                ElseIf DataPoint = 1 Then '密文被储存在了G，忽视另外两个虚假的数据
                    ValueOfColor = EncrryptColor.G
                ElseIf DataPoint = 2 Then '密文被储存在了B，忽视另外两个虚假的数据
                    ValueOfColor = EncrryptColor.B
                End If
                '遇到结束符（即chr(0)）,退出遍历。chr(0)只会出现在图像最后一行，退出内层循环，外层循环也会结束
                If ValueOfColor = 0 Then Exit For
                Base64CipherText &= Chr(ValueOfColor) '连接Base64密文
            Next
        Next
        Try '当用户用错误的密匙解密时，Base64的解密算法会因为遇到非法的Base-64字符而发生错误
            '解密Base64编码
            Dim DecryptByte() As Byte = Convert.FromBase64String(Base64CipherText)
            Dim Base64PlainText As String = System.Text.Encoding.Default.GetString(DecryptByte)
            Return Base64PlainText '密匙输入正确！返回解密后的文本。好孩子！
        Catch ex As Exception
            Return "您输入的密匙错误，导致解密过程出错！" '输入错误的密匙，解密出错，错误处理。
        End Try
    End Function

    Private Sub btn_Encrypt_Click(sender As Object, e As EventArgs) Handles btn_Encrypt.Click
        '加密
        ResultImage = EncryptTextToImage(txt_TextBox.Text, txt_Key.Text)
        pic_PictureBox.BackgroundImage = ResultImage
    End Sub

    Private Sub btn_Decrypt_Click(sender As Object, e As EventArgs) Handles btn_Decrypt.Click
        '解密
        txt_TextBox.Text = DecryptTextFromImage(ResultImage, txt_Key.Text)
    End Sub

    Private Sub btn_SaveImage_Click(sender As Object, e As EventArgs) Handles btn_SaveImage.Click
        '导出加密后的位图。为了数据稳定，图像建议储存为bmp位图格式
        If pic_PictureBox.BackgroundImage Is Nothing Then Exit Sub

        Dim PathDialog As SaveFileDialog = New SaveFileDialog
        With PathDialog
            .CheckPathExists = True
            .DereferenceLinks = True
            .FileName = Format(Now, " yyyymmddhhmmss")
            .Filter = "BMP高质量位图|*.bmp"
            .Title = "选择加密图像的储存位置："
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                pic_PictureBox.BackgroundImage.Save(.FileName, Imaging.ImageFormat.Bmp)
            End If
        End With
    End Sub

    Private Sub btn_LoadImage_Click(sender As Object, e As EventArgs) Handles btn_LoadImage.Click
        '从存储器导入加密后的位图，以待解密
        Dim PathDialog As OpenFileDialog = New OpenFileDialog
        With PathDialog
            .CheckFileExists = True
            .CheckPathExists = True
            .DereferenceLinks = True
            .Filter = "BMP位图格式|*.bmp|PNG高清图像格式|*.png|JPG压缩格式|*.jpg|所有文件格式|*.*"
            .Multiselect = False
            .Title = "读取储存密文的图像："
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                pic_PictureBox.BackgroundImage = Bitmap.FromFile(.FileName)
            End If
        End With
    End Sub

    Private Sub pic_PictureBox_Click(sender As Object, e As EventArgs) Handles pic_PictureBox.Click
        pic_PictureBox.Focus()
    End Sub

    Private Sub pic_PictureBox_MouseWheel(sender As Object, e As MouseEventArgs) Handles pic_PictureBox.MouseWheel
        If ResultImage Is Nothing Then Exit Sub

        Static ScalingFactor As Single = 1.0
        ScalingFactor += 0.25 * Val(IIf(e.Delta > 0, 1, -1))
        ScalingFactor = Math.Round(ScalingFactor, 2)
        If ScalingFactor < 0.25 Then ScalingFactor = 0.25
        Label2.Text = "ScalingFactor:" & vbCrLf & ScalingFactor

        Dim ShowImage As New Bitmap(CInt(ResultImage.Width * ScalingFactor), CInt(ResultImage.Height * ScalingFactor))
        Dim MyGraphics As Graphics = Graphics.FromImage(ShowImage)
        MyGraphics.SmoothingMode = SmoothingMode.HighSpeed
        MyGraphics.CompositingQuality = CompositingQuality.HighQuality
        MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        MyGraphics.DrawImage(ResultImage, 0, 0, ShowImage.Width, ShowImage.Height)
        'Debug.Print(pic_PictureBox.Padding.Left & pic_PictureBox.Padding.Top)
        'ShowImage.Save("d:\" & ScalingFactor & ".bmp", Imaging.ImageFormat.Bmp)
        pic_PictureBox.BackgroundImage = ShowImage
    End Sub

End Class
