using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Metal_Assay
{
    public static class DesignApplier
    {
        public static void ApplyConfig(Control parent, Dictionary<string, ControlConfig> config)
        {
            if (config == null) return;

            foreach (var kvp in config)
            {
                var control = FindControl(parent, kvp.Key);
                if (control == null) continue;

                var cfg = kvp.Value;

                if (cfg.Location.HasValue)
                    control.Location = cfg.Location.Value;

                if (cfg.Size.HasValue)
                    control.Size = cfg.Size.Value;

                if (cfg.FontSize.HasValue)
                    control.Font = new Font(control.Font.FontFamily, cfg.FontSize.Value, control.Font.Style);
            }
        }

        public static void ApplyColumnWidths(DataGridView dgv, int[] widths)
        {
            if (dgv == null || widths == null) return;

            for (int i = 0; i < widths.Length && i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = widths[i];
            }
        }

        private static Control FindControl(Control parent, string name)
        {
            if (parent.Name == name) return parent;

            foreach (Control child in parent.Controls)
            {
                var found = FindControl(child, name);
                if (found != null) return found;
            }
            return null;
        }
    }
}