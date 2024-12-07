using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace QLVanChuyen_App.controllers
{
    internal class XuatFile
    {
        private string data = ""; 
        private PrintDocument printDocument = new PrintDocument();

        public void InData(string _data)
        {
            data = _data;
            printDocument.PrintPage += PrintDocument_PrintPage; // Đăng ký sự kiện in
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Xác định font chữ, màu sắc, và vị trí in
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            float x = 10, y = 10; // Vị trí bắt đầu in

            foreach (var line in data.Split('\n'))
            {
                e.Graphics.DrawString(line, font, brush, x, y);
                y += 20;
            }
        }
        public void In_DataTable_To_Excel(DataGridView dataGridView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "ExportedData.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Tạo file Excel
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Tạo worksheet
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                        // Thêm tiêu đề cột
                        for (int col = 0; col < dataGridView.Columns.Count; col++)
                        {
                            worksheet.Cells[1, col + 1].Value = dataGridView.Columns[col].HeaderText;
                            worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                            worksheet.Cells[1, col + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells[1, col + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        // Thêm dữ liệu từ DataGridView
                        for (int row = 0; row < dataGridView.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataGridView.Columns.Count; col++)
                            {
                                var value = dataGridView.Rows[row].Cells[col].Value;
                                worksheet.Cells[row + 2, col + 1].Value = value;
                            }
                        }

                        // Tự động điều chỉnh kích thước cột
                        worksheet.Cells.AutoFitColumns();

                        // Lưu file Excel
                        FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                        excelPackage.SaveAs(fileInfo);

                        MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
