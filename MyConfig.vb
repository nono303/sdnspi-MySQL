Friend Class MyConfig
  Friend dbConnStr As String
  Friend SelectFwd4 As String
  Friend SelectFwd6 As String
  Friend SelectRev4 As String
  Friend SelectRev6 As String

  Public Shared Function Load(ByVal config As String) As MyConfig
    Dim rv As New MyConfig
    Dim doc As New Xml.XmlDocument
    Dim root As Xml.XmlElement = doc.CreateElement("root")
    doc.AppendChild(root)
    root.InnerXml = config
    For Each node As Xml.XmlNode In root.ChildNodes
      If Not TypeOf node Is Xml.XmlElement Then Continue For
      Select Case DirectCast(node, Xml.XmlElement).Name
        Case "DBConnStr"
          rv.dbConnStr = node.InnerText
        Case "SelectFwd4"
          rv.SelectFwd4 = node.InnerText
        Case "SelectFwd6"
          rv.SelectFwd6 = node.InnerText
        Case "SelectRev4"
          rv.SelectRev4 = node.InnerText
        Case "SelectRev6"
          rv.SelectRev6 = node.InnerText
      End Select
    Next
    Return rv
  End Function

  Public Function Save() As String
    Dim doc As New Xml.XmlDocument
    Dim root As Xml.XmlElement = doc.CreateElement("root")
    doc.AppendChild(root)
    Dim elem As Xml.XmlElement

    elem = doc.CreateElement("DBConnStr")
    elem.InnerText = dbConnStr
    root.AppendChild(elem)

    If SelectFwd4.Length > 0 Then
      elem = doc.CreateElement("SelectFwd4")
      elem.InnerText = SelectFwd4
      root.AppendChild(elem)
    End If

    If SelectFwd6.Length > 0 Then
      elem = doc.CreateElement("SelectFwd6")
      elem.InnerText = SelectFwd6
      root.AppendChild(elem)
    End If

    If SelectRev4.Length > 0 Then
      elem = doc.CreateElement("SelectRev4")
      elem.InnerText = SelectRev4
      root.AppendChild(elem)
    End If

    If SelectRev6.Length > 0 Then
      elem = doc.CreateElement("SelectRev6")
      elem.InnerText = SelectRev6
      root.AppendChild(elem)
    End If

    Return root.InnerXml
  End Function

End Class
