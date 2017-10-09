/*
 * Author: Rylan Kasitz
 */
 
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.MapViewer
{
    public struct StreetSegment
    {
        private PointF _start;
        private PointF _end;
        private Pen _pen;
        private int _visibleLevels;

        /// <summary>
        /// Gets the and sets the starting point
        /// </summary>
        public PointF Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }


        /// <summary>
        /// Gets and sets the end point
        /// </summary>
        public PointF End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        /// <summary>
        /// Gets the visible levels
        /// </summary>
        public int VisibleLevels
        {
            get
            {
                return _visibleLevels;
            }
        }

        /// <summary>
        /// Intializes the parameters
        /// </summary>
        /// <param name="start">Start point of the street</param>
        /// <param name="end">End point of the street</param>
        /// <param name="color">Color of the street</param>
        /// <param name="width">Width of the street</param>
        /// <param name="visibleLevels">Number of zoom levels at which the street is visible</param>
        public StreetSegment(PointF start, PointF end, Color color, float width, int visibleLevels)
        {
            _start = start;
            _end = end;
            _pen = new Pen(color, width);
            _visibleLevels = visibleLevels;
        }

        /// <summary>
        /// Draws the street
        /// </summary>
        /// <param name="graphics">The graphics object which draws the street</param>
        /// <param name="scaleFactor">The scale factor of pixels</param>
        public void Draw(Graphics graphics, int scaleFactor)
        {
            graphics.DrawLine(_pen, _start.X * scaleFactor, _start.Y * scaleFactor, _end.X * scaleFactor, _end.Y * scaleFactor);
        }
    }
}
