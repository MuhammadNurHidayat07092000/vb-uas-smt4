Module KoneksiDb
    Public DB As New MySql.Data.MySqlClient.MySqlConnection("Server=localhost;User id=root;password=root;database=db_penjualan")
    Public Konek As New MySql.Data.MySqlClient.MySqlCommand
    Public Rikot As MySql.Data.MySqlClient.MySqlDataReader

    Sub FistDB()
        With Konek
            .CommandType = Data.CommandType.Text
            .Connection = DB
            .Connection.Open()
        End With
    End Sub

    Sub LashDB()
        Konek.Connection.Close()
    End Sub
End Module
