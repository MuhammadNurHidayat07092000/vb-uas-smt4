Imports MySql.Data.MySqlClient
Public Class Form3

    Dim status As String = "simpan"

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampildata()
        DataGridView1.DataSource = DS.Tables("tbl_panjualan")
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtNomorTransaksi.Text = "" And txtNamaKonsumen.Text = "" And txtNamaBarang.Text = "" And txtHargaSatuan.Text = "" And txtJumlah.Text = "" And txtDiskon.Text = "" Then
            MsgBox("Harap Isi Data dengan Lengkap")
        Else
            If status = "simpan" Then
                Call simpandata(txtNomorTransaksi.Text, txtTanggal.Text, txtNamaKonsumen.Text, txtNamaBarang.Text, txtHargaSatuan.Text, txtJumlah.Text, txtDiskon.Text)
            ElseIf status = "update" Then
                Call updatedata(txtNomorTransaksi.Text, txtTanggal.Text, txtNamaKonsumen.Text, txtNamaBarang.Text, txtHargaSatuan.Text, txtJumlah.Text, txtDiskon.Text)
                status = "update"
                btnSimpan.Text = "Save"
                txtNomorTransaksi.ReadOnly = False
            End If
            Call tampildata()
            DataGridView1.DataSource = DS.Tables("tbl_panjualan")
            DataGridView1.ReadOnly = True
            clear()
        End If
    End Sub

    Sub clear()
        txtNomorTransaksi.Text = ""
        txtTanggal.Text = ""
        txtNamaKonsumen.Text = ""
        txtNamaBarang.Text = ""
        txtHargaSatuan.Text = ""
        txtJumlah.Text = ""
        txtDiskon.Text = ""
        txtNomorTransaksi.ReadOnly = False
    End Sub

    Sub getdata()
        Call koneksi()
        Dim tampil As String = " select * from tbl_panjualan where nomor_transaksi = '" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        CMD = New MysqlCommand(tampil, CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            txtNomorTransaksi.Text = RD.Item("nomor_transaksi")
            txtTanggal.Text = RD.Item("tanggal")
            txtNamaKonsumen.Text = RD.Item("nama_konsumen")
            txtNamaBarang.Text = RD.Item("nama_barang")
            txtHargaSatuan.Text = RD.Item("harga_satuan")
            txtJumlah.Text = RD.Item("jumlah_barang")
            txtDiskon.Text = RD.Item("diskon")
        End If
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        Call getdata()
        status = "update"
        txtNomorTransaksi.ReadOnly = True

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure , you want to delete this data?", MsgBoxStyle.YesNo, "konfirmasi") = MsgBoxResult.No Then Exit Sub

        Call delete(DataGridView1.CurrentRow.Cells(0).Value)
        Call tampildata()
        DataGridView1.DataSource = DS.Tables("tbl_panjualan")
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class