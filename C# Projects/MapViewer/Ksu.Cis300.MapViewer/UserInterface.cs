/*
 * Author: Rylan Kasitz
 */
     
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.MapViewer
{
    public partial class UserInterface : Form
    {
        private const int _intitalScale = 10;
        private Map _map;

        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads the input file and adds the the street lists and sets bounds
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="bounds">Bounds of the map</param>
        /// <returns>List of streets added from the file</returns>
        private List<StreetSegment> ReadFile(string fileName, out RectangleF bounds)
        {
            List<StreetSegment> streets = new List<StreetSegment>();
            using (StreamReader input = new StreamReader(fileName))
            {
                string[] b = input.ReadLine().Split(',');
                bounds = new RectangleF(0, 0, Convert.ToSingle(b[0]), Convert.ToSingle(b[1]));
                while (!input.EndOfStream)
                {
                    string[] l = input.ReadLine().Split(',');
                    float ex = Convert.ToSingle(l[0]);
                    float ey = Convert.ToSingle(l[1]);
                    float sx = Convert.ToSingle(l[2]);
                    float sy = Convert.ToSingle(l[3]);
                    Color c = Color.FromArgb(Convert.ToInt32(l[4]));
                    float w = Convert.ToSingle(l[5]);
                    int z = Convert.ToInt32(l[6]);
                    PointF s = new PointF(sx, sy);
                    PointF e = new PointF(ex, ey);

                    streets.Add(new StreetSegment(s, e, c, w, z));                 
                }             
            }
            return streets;
        }

        /// <summary>
        /// Opens a map from file and creates a map object and adds it to the GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenMap_Click(object sender, EventArgs e)
        {
            List<StreetSegment> streets = null;
            RectangleF bounds;
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    streets = ReadFile(uxOpenDialog.FileName, out bounds);
                    _map = new Map(streets, bounds, _intitalScale);
                    uxMapContainer.Controls.Clear();
                    uxMapContainer.Controls.Add(_map);
                    uxZoomIn.Enabled = true;
                    uxZoomOut.Enabled = false;
                }
                catch (ArgumentException ex)   
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Zooms in when the zoom in button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxZoomIn_Click(object sender, EventArgs e)
        {
            Point p = new Point(uxMapContainer.AutoScrollPosition.X*-1, uxMapContainer.AutoScrollPosition.Y*-1);
            _map.ZoomIn();
            uxZoomIn.Enabled = _map.CanZoomIn;
            uxZoomOut.Enabled = _map.CanZoomOut;

            uxMapContainer.AutoScrollPosition = new Point(p.X * 2 + uxMapContainer.ClientSize.Width / 2, 
                                                          p.Y * 2 + uxMapContainer.ClientSize.Height / 2);
        }

        /// <summary>
        /// Zooms out when the zoom out button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxZoomOut_Click(object sender, EventArgs e)
        {
            Point p = new Point(uxMapContainer.AutoScrollPosition.X * -1, uxMapContainer.AutoScrollPosition.Y*-1);
            _map.ZoomOut();
            uxZoomIn.Enabled = _map.CanZoomIn;
            uxZoomOut.Enabled = _map.CanZoomOut;

            uxMapContainer.AutoScrollPosition = new Point(p.X / 2 - uxMapContainer.ClientSize.Width / 4,
                                                          p.Y / 2 - uxMapContainer.ClientSize.Height / 4);
        }
    }
}
