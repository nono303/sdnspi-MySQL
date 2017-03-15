Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmBuildDBConn

  Friend ConnStr As String

  Friend Sub LoadData(ByVal s As String)
    Dim bldr As MySqlConnectionStringBuilder
    Try
      bldr = New MySqlConnectionStringBuilder(s)
      TextBox1.Text = bldr.Server
      numPort.Value = bldr.Port
      TextBox2.Text = bldr.Database
      TextBox3.Text = bldr.UserID
      TextBox4.Text = bldr.Password
    Catch
    End Try
  End Sub

  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    If TextBox1.Text.Trim.Length = 0 OrElse _
        TextBox2.Text.Trim.Length = 0 OrElse _
        TextBox3.Text.Trim.Length = 0 OrElse _
        TextBox4.Text.Trim.Length = 0 Then
      MessageBox.Show("Please enter a value in all 5 fields", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    Dim bldr As New MySqlConnectionStringBuilder
    bldr.Server = TextBox1.Text.Trim
    bldr.Port = CUInt(numPort.Value)
    bldr.Database = TextBox2.Text.Trim
    bldr.UserID = TextBox3.Text.Trim
    bldr.Password = TextBox4.Text.Trim
    ConnStr = bldr.ConnectionString
    Me.DialogResult = Windows.Forms.DialogResult.OK
  End Sub

End Class