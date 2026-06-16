using MirDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Server
{
    public class JsonExporter
    {
        public static void Export<T>(DataGridView grid) where T : DBObject, new()
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new DBObjectArrayConverter<T>(SMain.Session) },
                WriteIndented = true
            };

            JsonExporter.Export<T>(grid, options);
        }

        public static void Export<T>(DataGridView dataGridView, JsonSerializerOptions options) where T : DBObject, new()
        {
            if (!Directory.Exists($"Exports/{typeof(T).Name}"))
            {
                Directory.CreateDirectory($"Exports/{typeof(T).Name}");
            }

            List<T> selectedItems = new();

            if (dataGridView.SelectedRows.Count == 0)
            {
                // No rows selected — export all
                selectedItems.AddRange(SMain.Session.GetCollection<T>().Binding);
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (row.DataBoundItem is T selRow)
                        selectedItems.Add(selRow);
                }
            }

            // Also support cell-selection mode
            if (selectedItems.Count == 0 && dataGridView.SelectedCells.Count > 0)
            {
                HashSet<int> rowIndexes = new HashSet<int>();
                foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    rowIndexes.Add(cell.RowIndex);

                foreach (int idx in rowIndexes)
                {
                    if (dataGridView.Rows[idx].DataBoundItem is T selRow)
                        selectedItems.Add(selRow);
                }
            }

            // Fallback: if still empty, export all
            if (selectedItems.Count == 0)
            {
                selectedItems.AddRange(SMain.Session.GetCollection<T>().Binding);
            }

            if (MessageBox.Show($"You're about to export {selectedItems.Count} rows, are you sure?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            var json = JsonSerializer.Serialize<T[]>(selectedItems.ToArray(), options);

            var time = DateTime.UtcNow;
            var now = $"{time.Year:0000}-{time.Month:00}-{time.Day:00} {time.Hour:00}-{time.Minute:00}-{time.Second:00}";

            var path = $"Exports/{typeof(T).Name}/{typeof(T).Name} - {selectedItems.Count} - {now}.json";

            using StreamWriter file = new(path);

            file.WriteLine(json);

            MessageBox.Show($"All selected rows have been exported to '{path}'.", "Success", MessageBoxButtons.OK);
        }
    }
}
