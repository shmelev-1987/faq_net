using System;
using System.Collections.Generic;
using System.Text;

namespace FAQ_Net
{
  class RtfTable
  {
    // Method to create a table format string with data from a DataTable.

    public static String InsertTableInRichTextBox(System.Data.DataTable tbl, int width)
    {
      //Since too much string appending go for string builder
      StringBuilder sringTableRtf = new StringBuilder();

      //beginning of rich text format,dont customize this begining line
      sringTableRtf.Append(@"{\rtf1 ");

      //create 5 rows with 3 cells each
      int cellWidth;

      //Start the Row
      sringTableRtf.Append(@"\trowd");

      //Populate the Table header from DataTable column headings.
      for (int j = 0; j < tbl.Columns.Count; j++)
      {
        //A cell with width 1000.
        sringTableRtf.Append(@"\cellx" + ((j + 1) * width).ToString());

        if (j == 0)
          sringTableRtf.Append(@"\intbl  " + tbl.Columns[j].ColumnName);
        else
          sringTableRtf.Append(@"\cell   " + tbl.Columns[j].ColumnName);
      }

      //Add the table header row
      sringTableRtf.Append(@"\intbl \cell \row");

      //Loop to populate the table cell data from DataTable
      for (int i = 0; i < tbl.Rows.Count; i++)
      {
        //Start the Row
        sringTableRtf.Append(@"\trowd");

        for (int j = 0; j < tbl.Columns.Count; j++)
        {
          cellWidth = (j + 1) * width;

          //A cell with width 1000.
          sringTableRtf.Append(@"\cellx" + cellWidth.ToString());

          if (j == 0)
            sringTableRtf.Append(@"\intbl  " + tbl.Rows[i][j].ToString());
          else
            sringTableRtf.Append(@"\cell   " + tbl.Rows[i][j].ToString());
        }

        //Insert data row
        sringTableRtf.Append(@"\intbl \cell \row");
      }

      sringTableRtf.Append(@"\pard");
      sringTableRtf.Append(@"}");

      //convert the string builder to string
      return sringTableRtf.ToString();
    }
  }
}
