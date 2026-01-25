using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Metal_Assay
{
    public static class DesignConfig
    {
        // Detect which config to use
        public static bool Is1600x900 => Screen.PrimaryScreen.Bounds.Width <= 1600;

        // Store all control configurations
        public static Dictionary<string, ControlConfig> GetMainTabConfig()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, ControlConfig>
                {
                    // Labels
                    ["MainFormcodeLabel"] = new ControlConfig { Location = new Point(28, 14), FontSize = 18f },
                    ["MainCustomerLabel"] = new ControlConfig { Location = new Point(295, 14), FontSize = 18f },
                    ["MainDateLabel"] = new ControlConfig { Location = new Point(28, 67), FontSize = 18f },
                    ["MainItemcodeLabel"] = new ControlConfig { Location = new Point(481, 67), FontSize = 18f },
                    ["MainSampleWeightLabel"] = new ControlConfig { Location = new Point(804, 67), FontSize = 18f },

                    // Buttons
                    ["MainNewButton"] = new ControlConfig { Location = new Point(33, 119), Size = new Size(167, 42), FontSize = 15.75f },
                    ["MainNewRoundButton"] = new ControlConfig { Location = new Point(255, 119), Size = new Size(167, 42), FontSize = 15.75f },
                    ["MainDeleteButton"] = new ControlConfig { Location = new Point(477, 119), Size = new Size(167, 42), FontSize = 15.75f },
                    ["MainEditButton"] = new ControlConfig { Location = new Point(699, 119), Size = new Size(167, 42), FontSize = 15.75f },
                    ["MainAddButton"] = new ControlConfig { Location = new Point(921, 119), Size = new Size(167, 42), FontSize = 15.75f },

                    // Panels
                    ["panel1"] = new ControlConfig { Location = new Point(8, 181), Size = new Size(750, 560) },
                    ["panel2"] = new ControlConfig { Location = new Point(773, 175), Size = new Size(798, 560) },

                    // DataGridViews
                    ["MainLeftDataGridView"] = new ControlConfig { Location = new Point(0, 0), Size = new Size(744, 554), FontSize = 18f },
                    ["MainRightDataGridView"] = new ControlConfig { Location = new Point(3, 3), Size = new Size(789, 551), FontSize = 18f }
                };
            }
            else
            {
                // Return your 1920x1080 values here (or null to keep Designer defaults)
                return null;
            }
        }

        public static Dictionary<string, ControlConfig> GetFirstWeightTabConfig()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, ControlConfig>
                {
                    ["FWCustomerLabel"] = new ControlConfig { Location = new Point(17, 15), FontSize = 20.25f },
                    ["FWCustomerContent"] = new ControlConfig { Location = new Point(17, 58), Size = new Size(326, 103), FontSize = 20.25f },
                    ["FWItemcodeLabel"] = new ControlConfig { Location = new Point(17, 176), FontSize = 20.25f },
                    ["FWItemcodeContent"] = new ControlConfig { Location = new Point(17, 216), FontSize = 20.25f },
                    ["FWALabel"] = new ControlConfig { Location = new Point(17, 282), FontSize = 15.75f },
                    ["FWBLabel"] = new ControlConfig { Location = new Point(17, 331), FontSize = 15.75f },
                    ["FWSIlverPctLabel"] = new ControlConfig { Location = new Point(7, 405), FontSize = 15.75f },
                    ["FWATextbox"] = new ControlConfig { Location = new Point(49, 279), Size = new Size(229, 31), FontSize = 15.75f },
                    ["FWBTextbox"] = new ControlConfig { Location = new Point(49, 328), Size = new Size(230, 31), FontSize = 15.75f },
                    ["FWSilverPctCombobox"] = new ControlConfig { Location = new Point(109, 403), Size = new Size(166, 33), FontSize = 15.75f },
                    ["FWSaveButton"] = new ControlConfig { Location = new Point(76, 471), Size = new Size(135, 46), FontSize = 15.75f },
                    ["FWGoToRedoButton"] = new ControlConfig { Location = new Point(57, 45), Size = new Size(155, 46), FontSize = 15.75f },
                    ["FWRedoGroupbox"] = new ControlConfig { Location = new Point(10, 591), Size = new Size(269, 120) },
                    ["panel3"] = new ControlConfig { Location = new Point(349, 15), Size = new Size(1040, 735) },
                    ["FWDataGridView"] = new ControlConfig { Location = new Point(0, 0), Size = new Size(1036, 751), FontSize = 18f }
                };
            }
            return null;
        }

        public static Dictionary<string, ControlConfig> GetLastWeightTabConfig()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, ControlConfig>
                {
                    ["LWCustomerLabel"] = new ControlConfig { Location = new Point(7, 3), FontSize = 15.75f },
                    ["LWCustomerContent"] = new ControlConfig { Location = new Point(7, 28), Size = new Size(492, 68), FontSize = 15.75f },
                    ["LWItemcodeLabel"] = new ControlConfig { Location = new Point(7, 96), FontSize = 15.75f },
                    ["LWItemcodeContent"] = new ControlConfig { Location = new Point(6, 132), FontSize = 15.75f },
                    ["LWGroupbox"] = new ControlConfig { Location = new Point(505, 16), Size = new Size(772, 158) },
                    ["groupBox1"] = new ControlConfig { Location = new Point(1350, 152), Size = new Size(192, 120) },
                    ["LWEditButton"] = new ControlConfig { Location = new Point(1312, 60), Size = new Size(153, 58), FontSize = 15.75f },
                    ["LWGoToRedoButton"] = new ControlConfig { Location = new Point(18, 39), Size = new Size(155, 46), FontSize = 15.75f },
                    ["panel4"] = new ControlConfig { Location = new Point(12, 191), Size = new Size(1332, 560) },
                    ["LWDataGridView"] = new ControlConfig { Location = new Point(0, 0), Size = new Size(1329, 550), FontSize = 18f },
                    // LWGroupbox children
                    ["LWLastWeightATextBox"] = new ControlConfig { Location = new Point(56, 75), Size = new Size(100, 29), FontSize = 14.25f },
                    ["LWLastWeightBTextBox"] = new ControlConfig { Location = new Point(56, 110), Size = new Size(100, 29), FontSize = 14.25f },
                    ["LWFirstWeightATextBox"] = new ControlConfig { Location = new Point(181, 75), Size = new Size(100, 29), FontSize = 14.25f },
                    ["LWFirstWeightBTextBox"] = new ControlConfig { Location = new Point(181, 110), Size = new Size(100, 29), FontSize = 14.25f },
                    ["LWPreresultATextBox"] = new ControlConfig { Location = new Point(312, 75), Size = new Size(100, 29), FontSize = 14.25f },
                    ["LWPreresultBTextBox"] = new ControlConfig { Location = new Point(312, 110), Size = new Size(100, 29), FontSize = 14.25f },
                    ["LWAverageResultTextBox"] = new ControlConfig { Location = new Point(446, 92), Size = new Size(100, 29), FontSize = 14.25f },
                    ["LWFinalResultTextBox"] = new ControlConfig { Location = new Point(649, 92), Size = new Size(100, 29), FontSize = 14.25f }
                };
            }
            return null;
        }

        public static Dictionary<string, ControlConfig> GetSampleReturnTabConfig()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, ControlConfig>
                {
                    ["SampleReturnCustomerLabel"] = new ControlConfig { Location = new Point(8, 31), FontSize = 20.25f },
                    ["SampleReturnCustomerContentLabel"] = new ControlConfig { Location = new Point(8, 74), Size = new Size(349, 103), FontSize = 20.25f },
                    ["SampleReturnItemcodeLabel"] = new ControlConfig { Location = new Point(8, 192), FontSize = 20.25f },
                    ["SampleReturnItemcodeContentLabel"] = new ControlConfig { Location = new Point(8, 232), FontSize = 20.25f },
                    ["SampleReturnResultLabel"] = new ControlConfig { Location = new Point(8, 289), FontSize = 20.25f },
                    ["SampleReturnResultContentLabel"] = new ControlConfig { Location = new Point(8, 329), FontSize = 21.75f },
                    ["SampleReturnSampleWeightLabel"] = new ControlConfig { Location = new Point(9, 398), FontSize = 18f },
                    ["SampleReturnSampleWeightContentLabel"] = new ControlConfig { Location = new Point(228, 398), FontSize = 18f },
                    ["SampleReturnSampleReturnLabel"] = new ControlConfig { Location = new Point(9, 458), FontSize = 18f },
                    ["SampleReturnSampleReturnTextbox"] = new ControlConfig { Location = new Point(224, 455), Size = new Size(90, 35), FontSize = 18f },
                    ["SampleReturnSaveButton"] = new ControlConfig { Location = new Point(87, 518), Size = new Size(135, 46), FontSize = 15.75f },
                    ["SRGoToNonRedoButton"] = new ControlConfig { Location = new Point(58, 43), Size = new Size(197, 46), FontSize = 15.75f },
                    ["groupBox2"] = new ControlConfig { Location = new Point(29, 582), Size = new Size(300, 120) },
                    ["panel5"] = new ControlConfig { Location = new Point(400, 31), Size = new Size(1091, 738) },
                    ["SRDataGridView"] = new ControlConfig { Location = new Point(3, 0), Size = new Size(1086, 731), FontSize = 18f }
                };
            }
            return null;
        }

        public static Dictionary<string, ControlConfig> GetHistoryTabConfig()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, ControlConfig>
                {
                    ["HIstoryCustomerLabel"] = new ControlConfig { Location = new Point(8, 3), FontSize = 20.25f },
                    ["HistoryItemcodeLabel"] = new ControlConfig { Location = new Point(304, 3), FontSize = 20.25f },
                    ["HistoryCustomerTextbox"] = new ControlConfig { Location = new Point(20, 37), Size = new Size(251, 31), FontSize = 15.75f },
                    ["HistoryItemcodeTextbox"] = new ControlConfig { Location = new Point(310, 37), Size = new Size(251, 31), FontSize = 15.75f },
                    ["HistorySearchButton"] = new ControlConfig { Location = new Point(623, 23), Size = new Size(151, 45), FontSize = 15.75f },
                    ["HistorySearchSpoilButton"] = new ControlConfig { Location = new Point(819, 23), Size = new Size(151, 45), FontSize = 15.75f },
                    ["HistoryListbox"] = new ControlConfig { Location = new Point(20, 68), Size = new Size(251, 384) },
                    ["panel6"] = new ControlConfig { Location = new Point(20, 88), Size = new Size(1456, 916) },
                    ["HistoryDataGridView"] = new ControlConfig { Location = new Point(3, 0), Size = new Size(1444, 646), FontSize = 18f }
                };
            }
            return null;
        }

        public static Dictionary<string, ControlConfig> GetCustomerTabConfig()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, ControlConfig>
                {
                    ["CustomerCustomerLabel"] = new ControlConfig { Location = new Point(8, 237), FontSize = 20.25f },
                    ["CustomerCustomerTextbox"] = new ControlConfig { Location = new Point(14, 271), Size = new Size(251, 31), FontSize = 15.75f },
                    ["CustomerNewButton"] = new ControlConfig { Location = new Point(67, 17), Size = new Size(135, 46), FontSize = 15.75f },
                    ["CustomerEditButton"] = new ControlConfig { Location = new Point(67, 84), Size = new Size(135, 46), FontSize = 15.75f },
                    ["CustomerDeleteButton"] = new ControlConfig { Location = new Point(67, 158), Size = new Size(135, 46), FontSize = 15.75f },
                    ["CustomerSearchButton"] = new ControlConfig { Location = new Point(67, 323), Size = new Size(135, 46), FontSize = 15.75f },
                    ["CustomerResetButton"] = new ControlConfig { Location = new Point(67, 401), Size = new Size(135, 46), FontSize = 15.75f },
                    ["CustomerCustomerListbox"] = new ControlConfig { Location = new Point(14, 308), Size = new Size(251, 384) },
                    ["panel7"] = new ControlConfig { Location = new Point(288, 17), Size = new Size(1281, 730) },
                    ["CustomerDataGridView"] = new ControlConfig { Location = new Point(3, 0), Size = new Size(1270, 721), FontSize = 18f }
                };
            }
            return null;
        }

        public static Dictionary<string, ControlConfig> GetCheckingTabConfig()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, ControlConfig>
                {
                    ["CheckingLeftPanel"] = new ControlConfig { Location = new Point(8, 18), Size = new Size(611, 660), FontSize = 20.25f },
                    ["CheckingRightPanel"] = new ControlConfig { Location = new Point(640, 18), Size = new Size(616, 660), FontSize = 20.25f },
                    ["CheckingPrintLeftButton"] = new ControlConfig { Location = new Point(376, 690), Size = new Size(133, 49), FontSize = 20.25f },
                    ["CheckingLeftResetButton"] = new ControlConfig { Location = new Point(181, 690), Size = new Size(133, 49), FontSize = 20.25f },
                    ["CheckingPrintRightButton"] = new ControlConfig { Location = new Point(961, 690), Size = new Size(133, 49), FontSize = 20.25f },
                    ["CheckingRightResetButton"] = new ControlConfig { Location = new Point(788, 690), Size = new Size(133, 49), FontSize = 20.25f }
                };
            }
            return null;
        }

        public static Dictionary<string, ControlConfig> GetLogTabConfig()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, ControlConfig>
                {
                    ["LogPickdateLabel"] = new ControlConfig { Location = new Point(8, 14), FontSize = 20.25f },
                    ["LogSearchLabel"] = new ControlConfig { Location = new Point(450, 14), FontSize = 20.25f },
                    ["LogSearchTextbox"] = new ControlConfig { Location = new Point(554, 14), Size = new Size(315, 35), FontSize = 18f },
                    ["LogDateCombobox"] = new ControlConfig { Location = new Point(153, 11), Size = new Size(256, 39), FontSize = 20.25f },
                    ["LogResetButton"] = new ControlConfig { Location = new Point(1033, 10), Size = new Size(135, 43), FontSize = 18f },
                    ["listBox1"] = new ControlConfig { Location = new Point(14, 71), Size = new Size(1230, 664) }
                };
            }
            return null;
        }

        // DataGridView column widths
        public static Dictionary<string, int[]> GetColumnWidths()
        {
            if (Is1600x900)
            {
                return new Dictionary<string, int[]>
                {
                    ["MainLeftDataGridView"] = new[] { 150, 60, 200, 300 },
                    ["MainRightDataGridView"] = new[] { 150, 200, 140, 140, 130 },
                    ["FWDataGridView"] = new[] { 500, 200, 100, 100, 100 },
                    ["LWDataGridView"] = new[] { 500, 200, 100, 100, 100, 100, 100, 100 },
                    ["SRDataGridView"] = new[] { 410, 130, 170, 100, 125, 125 },
                    ["HistoryDataGridView"] = new[] { 280, 130, 150, 150, 90, 90, 90, 90, 100, 125, 125 },
                    ["CustomerDataGridView"] = new[] { 360, 130, 170, 100, 110, 110, 110, 150 }
                };
            }
            return null;
        }
    }

    public class ControlConfig
    {
        public Point? Location { get; set; }
        public Size? Size { get; set; }
        public float? FontSize { get; set; }
    }
}