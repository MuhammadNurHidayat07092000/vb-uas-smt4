Imports MySql.Data.MySqlClient
Module Module1
    Public CONN As MySqlConnection
    Public CMD As MySqlCommand
    Public DS As New DataSet
    Public DA As MySqlDataAdapter
    Public RD As MySqlDataReader

    Public Sub koneksi()
        CONN = New MySqlConnection("server=localhost;uid=root;password=root;database=db_penjualan")
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If
    End Sub

    Sub tampildata()
        Call koneksi()
        DA = New MySqlDataAdapter("SELECT nomor_transaksi,tanggal,nama_konsumen,nama_barang,harga_satuan,jumlah_barang,diskon,(harga_satuan*jumlah_barang)-(harga_satuan*jumlah_barang*(diskon/100)) as total_harga FROM tbl_panjualan", CONN)
        DS = New DataSet
        DA.Fill(DS, "tbl_panjualan")
    End Sub

    Sub simpandata(ByVal nomor_transaksi As Integer, ByVal tanggal As String, ByVal nama_konsumen As String, ByVal nama_barang As String, ByVal harga_satuan As Double, ByVal jumlah_barang As Integer, ByVal diskon As Double)
        Call koneksi()
        Dim simpan As String = "insert into tbl_panjualan values ('" & nomor_transaksi & "','" & tanggal & "','" & nama_konsumen & "','" & nama_barang & "','" & harga_satuan & "','" & jumlah_barang & "','" & diskon & "')"
        CMD = New MySqlCommand(simpan, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Input Data Berhasil")
    End Sub

    Sub updatedata(ByVal nomor_transaksi As Integer, ByVal tanggal As String, ByVal nama_konsumen As String, ByVal nama_barang As String, ByVal harga_satuan As Double, ByVal jumlah_barang As Integer, ByVal diskon As Double)
        Call koneksi()
        Dim update As String = "UPDATE `tbl_panjualan` SET `nomor_transaksi` = '" & nomor_transaksi & "', `tanggal` = '" & tanggal & "', `nama_konsumen` = '" & nama_konsumen & "', `nama_barang` = '" & nama_barang & "', `harga_satuan` = '" & harga_satuan & "', `jumlah_barang` = '" & jumlah_barang & "', `diskon` = '" & diskon & "' WHERE `tbl_panjualan`.`nomor_transaksi` = " & nomor_transaksi & ";"
        CMD = New MySqlCommand(update, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Update Data Berhasil")
    End Sub

    Sub delete(ByVal nomor_transaksi As Integer)
        Call koneksi()
        Dim hapus As String = "delete from tbl_panjualan where nomor_transaksi = " & nomor_transaksi & ""
        CMD = New MySqlCommand(hapus, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Hapus data Berhasil")
    End Sub
End Module
