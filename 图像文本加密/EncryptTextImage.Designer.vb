<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EncryptTextImage
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意:  以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EncryptTextImage))
        Me.txt_TextBox = New System.Windows.Forms.TextBox()
        Me.pic_PictureBox = New System.Windows.Forms.PictureBox()
        Me.btn_Decrypt = New System.Windows.Forms.Button()
        Me.btn_Encrypt = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Key = New System.Windows.Forms.TextBox()
        Me.btn_SaveImage = New System.Windows.Forms.Button()
        Me.btn_LoadImage = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.pic_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_TextBox
        '
        Me.txt_TextBox.Location = New System.Drawing.Point(12, 12)
        Me.txt_TextBox.Multiline = True
        Me.txt_TextBox.Name = "txt_TextBox"
        Me.txt_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_TextBox.Size = New System.Drawing.Size(413, 85)
        Me.txt_TextBox.TabIndex = 0
        Me.txt_TextBox.Text = "1234567890" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ABCDEFGHIJKLMNOPQRSTUVWXYZ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "abcdefghijklmnopqrstuvwxyz" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "小眼软件 软贱你的生活" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "~！@#￥%……&*（）--+=-·【】、{}|[]\';:""；‘""：，。、《》？,./<>?"
        '
        'pic_PictureBox
        '
        Me.pic_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pic_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_PictureBox.Location = New System.Drawing.Point(12, 103)
        Me.pic_PictureBox.Name = "pic_PictureBox"
        Me.pic_PictureBox.Size = New System.Drawing.Size(413, 324)
        Me.pic_PictureBox.TabIndex = 1
        Me.pic_PictureBox.TabStop = False
        '
        'btn_Decrypt
        '
        Me.btn_Decrypt.Location = New System.Drawing.Point(431, 103)
        Me.btn_Decrypt.Name = "btn_Decrypt"
        Me.btn_Decrypt.Size = New System.Drawing.Size(75, 30)
        Me.btn_Decrypt.TabIndex = 3
        Me.btn_Decrypt.Text = "Decrypt"
        Me.btn_Decrypt.UseVisualStyleBackColor = True
        '
        'btn_Encrypt
        '
        Me.btn_Encrypt.Location = New System.Drawing.Point(431, 67)
        Me.btn_Encrypt.Name = "btn_Encrypt"
        Me.btn_Encrypt.Size = New System.Drawing.Size(75, 30)
        Me.btn_Encrypt.TabIndex = 4
        Me.btn_Encrypt.Text = "Encrypt"
        Me.btn_Encrypt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(431, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Key:"
        '
        'txt_Key
        '
        Me.txt_Key.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txt_Key.Location = New System.Drawing.Point(431, 30)
        Me.txt_Key.Name = "txt_Key"
        Me.txt_Key.Size = New System.Drawing.Size(75, 23)
        Me.txt_Key.TabIndex = 6
        Me.txt_Key.Text = "9426926"
        Me.txt_Key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_SaveImage
        '
        Me.btn_SaveImage.Location = New System.Drawing.Point(431, 188)
        Me.btn_SaveImage.Name = "btn_SaveImage"
        Me.btn_SaveImage.Size = New System.Drawing.Size(75, 30)
        Me.btn_SaveImage.TabIndex = 7
        Me.btn_SaveImage.Text = "SaveImage"
        Me.btn_SaveImage.UseVisualStyleBackColor = True
        '
        'btn_LoadImage
        '
        Me.btn_LoadImage.Location = New System.Drawing.Point(431, 224)
        Me.btn_LoadImage.Name = "btn_LoadImage"
        Me.btn_LoadImage.Size = New System.Drawing.Size(75, 30)
        Me.btn_LoadImage.TabIndex = 8
        Me.btn_LoadImage.Text = "LoadImage"
        Me.btn_LoadImage.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(429, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 24)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ScalingFactor:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EncryptTextImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 439)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_LoadImage)
        Me.Controls.Add(Me.btn_SaveImage)
        Me.Controls.Add(Me.txt_Key)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Encrypt)
        Me.Controls.Add(Me.btn_Decrypt)
        Me.Controls.Add(Me.pic_PictureBox)
        Me.Controls.Add(Me.txt_TextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EncryptTextImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conversion Between Text And Image"
        CType(Me.pic_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents pic_PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Decrypt As System.Windows.Forms.Button
    Friend WithEvents btn_Encrypt As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Key As System.Windows.Forms.TextBox
    Friend WithEvents btn_SaveImage As System.Windows.Forms.Button
    Friend WithEvents btn_LoadImage As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
