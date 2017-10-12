/*
 * Author: Rylan Kasitz
 */
 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.MapViewer
{
    public partial class Map : UserControl
    {
        private const int _maxZoom = 6;
        private int _scale;
        private int _zoom = 0;
        private QuadTree _map;

        /// <summary>
        /// Weather or not the map can zoom in
        /// </summary>
        public bool CanZoomIn
        {
            get
            {
                if(_zoom < _maxZoom)
                {  
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Weather or not the map can zoom out
        /// </summary>
        public bool CanZoomOut
        {
            get
            {
                if (_zoom > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Initializes private variables
        /// Checks if street segments are in the map bounds
        /// </summary>
        /// <param name="streets">Streets segments of the map</param>
        /// <param name="bounds">Bounds of the map</param>
        /// <param name="scaleFactor">The intial scale factor of the map</param>
        public Map(List<StreetSegment> streets, RectangleF bounds, int scaleFactor)
        {          
            int streetNum = -1;
            foreach (StreetSegment s in streets)
            {
                streetNum++;
                if (!IsWithinBounds(s.Start, bounds) || !IsWithinBounds(s.End, bounds))
                {
                    throw new ArgumentException("Street " + streetNum + " is not within the given bounds");
                }
            }                            

            InitializeComponent();

            _map = new QuadTree(streets, bounds, _maxZoom);
            _scale = scaleFactor;
            Size size = new Size(Convert.ToInt32(bounds.Width * scaleFactor), Convert.ToInt32(bounds.Height * scaleFactor));
            Size = size;
        }

        /// <summary>
        /// Checks weather a point is bounded in a rectangle
        /// </summary>
        /// <param name="point">Point being checked</param>
        /// <param name="rectangle">Rectangle being checked</param>
        /// <returns>Weather the point is bounded or not</returns>
        private bool IsWithinBounds(PointF point, RectangleF rectangle)
        {
            float x = point.X;
            float y = point.Y;
            if (x >= rectangle.Left && y >= rectangle.Top && x <= rectangle.Right && y <= rectangle.Bottom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Overrides the OnPaint method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clip = new Region(e.ClipRectangle);
            _map.draw(e.Graphics, _scale, _zoom);
        }

        /// <summary>
        /// Zooms the map in by a factor of 2
        /// </summary>
        public void ZoomIn()
        {
            if(CanZoomIn)
            {
                _zoom++;
                _scale *= 2;
                Size = new Size(Size.Width * 2, Size.Height * 2);
            }
            Invalidate();
        }

        /// <summary>
        /// Zooms the map out by a factor of 2
        /// </summary>
        public void ZoomOut()
        {
            if (CanZoomOut)
            {
                _zoom--;
                _scale /= 2;
                Size = new Size(Size.Width / 2, Size.Height / 2);
            }
            Invalidate();
        }
    }
}
