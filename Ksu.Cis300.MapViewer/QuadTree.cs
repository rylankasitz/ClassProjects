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
    class QuadTree
    {
        private QuadTree _southeastChild;
        private QuadTree _southwestChild;
        private QuadTree _northeastChild;
        private QuadTree _northwestChild;      
        private List<StreetSegment> _streets = new List<StreetSegment>();
        private RectangleF _bounds;

        /// <summary>
        /// Seperates the streets int visible and invisible streets
        /// </summary>
        /// <param name="streetSplit">The streets being checked</param>
        /// <param name="height">The current map height</param>
        /// <param name="visible">The visible streets</param>
        /// <param name="invisible">The invisible streets</param>
        private static void SplitHeights(List<StreetSegment> streetSplit, float height, List<StreetSegment> visible, List<StreetSegment> invisible)
        {
            foreach(StreetSegment s in streetSplit)
            {
                if(s.VisibleLevels > height)
                {
                    visible.Add(s);
                }
                else
                {
                    invisible.Add(s);
                }
            }
        }

        /// <summary>
        /// Spilts the given streets to west and east sides
        /// </summary>
        /// <param name="streetSplit">The list of streets given</param>
        /// <param name="x">The spliting point</param>
        /// <param name="west">The list of west streets</param>
        /// <param name="east">The list of east streets</param>
        private static void SplitEastWest(List<StreetSegment> streetSplit, float x, List<StreetSegment> west, List<StreetSegment> east)
        {
            foreach (StreetSegment s in streetSplit)
            {
                if(s.Start.X <= x && s.End.X <= x)
                {
                    west.Add(s);
                }
                else if(s.Start.X >= x && s.End.X >= x)
                {
                    east.Add(s);
                }
                else
                {
                    float y = ((s.End.Y - s.Start.Y) * (x - s.Start.X) / (s.End.X - s.Start.X)) + s.Start.Y;
                    PointF p = new PointF(x, y);
                    StreetSegment s1 = s;
                    StreetSegment s2 = s;
                    s1.Start = p;
                    s2.End = p;
                    west.Add(s1);
                    east.Add(s2);
                }
            }
        }

        /// <summary>
        /// Spilts the given streets to norht and south sides
        /// </summary>
        /// <param name="streetSplit">The list of streets given</param>
        /// <param name="y">The spliting point</param>
        /// <param name="north">The list of north streets</param>
        /// <param name="south">The list of south streets</param>
        private static void SplitNorthSouth(List<StreetSegment> streetSplit, float y, List<StreetSegment> north, List<StreetSegment> south)
        {
            foreach (StreetSegment s in streetSplit)
            {
                if (s.Start.Y <= y && s.End.Y <= y)
                {
                    south.Add(s);
                }
                else if (s.Start.Y >= y && s.End.Y >= y)
                {
                    north.Add(s);
                }
                else
                {
                    float x = ((s.End.X - s.Start.X) * (y - s.Start.Y) / (s.End.Y - s.Start.Y)) + s.Start.X;
                    PointF p = new PointF(x, y);
                    StreetSegment s1 = s;
                    StreetSegment s2 = s;
                    s1.Start = p;
                    s2.End = p;
                    south.Add(s1);
                    north.Add(s2);
                }
            }
        }

        /// <summary>
        /// Contructs a quad tree recursivley 
        /// </summary>
        /// <param name="streets">The list of streets</param>
        /// <param name="rectangle">Rectagular bounds of the map</param>
        /// <param name="height">Height of the map</param>
        public QuadTree(List<StreetSegment> streets, RectangleF rectangle, int height)
        {         
            _bounds = rectangle;
            if(height == 0)
            {
                _streets = streets; 
            }
            else
            {                
                List<StreetSegment> visible = new List<StreetSegment>();
                List<StreetSegment> invisible = new List<StreetSegment>();
                SplitHeights(streets, height, visible, invisible);
                _streets = visible;

                List<StreetSegment> north = new List<StreetSegment>();
                List<StreetSegment> south = new List<StreetSegment>();
                float x = rectangle.Width / 2 + rectangle.Left;
                float y = rectangle.Height / 2 + rectangle.Top;

                List<StreetSegment> northeast = new List<StreetSegment>();
                List<StreetSegment> southeast = new List<StreetSegment>();
                List<StreetSegment> northwest = new List<StreetSegment>();
                List<StreetSegment> southwest = new List<StreetSegment>();
                SplitNorthSouth(invisible, y, north, south);
                SplitEastWest(north, x, northwest, northeast);
                SplitEastWest(south, x, southwest, southeast);

                _northeastChild = new QuadTree(northeast, new RectangleF(rectangle.Left + rectangle.Width/2, rectangle.Top, rectangle.Width / 2, rectangle.Height / 2), height - 1);
                _northwestChild = new QuadTree(northwest, new RectangleF(rectangle.Left, rectangle.Top, rectangle.Width / 2, rectangle.Height / 2), height - 1);
                _southeastChild = new QuadTree(southeast, new RectangleF(rectangle.Left + rectangle.Width/2, rectangle.Top + rectangle.Height/2, rectangle.Width / 2, rectangle.Height / 2), height - 1);
                _southwestChild = new QuadTree(southwest, new RectangleF(rectangle.Left, rectangle.Top + rectangle.Height / 2, rectangle.Width / 2, rectangle.Height / 2), height - 1);
            }
        }

        /// <summary>
        /// Draws all the streets
        /// </summary>
        /// <param name="graphics">Graphics object to draw</param>
        /// <param name="scaleFactor">Translates map coornates to pixels</param>
        /// <param name="maxDepth">Maximun depth to draw the tree nodes</param>
        public void draw(Graphics graphics, int scaleFactor, int maxDepth)
        {
            foreach (StreetSegment s in _streets)
            {
                s.Draw(graphics, scaleFactor);                                
            }
            if (maxDepth > 0)
            {
                _southeastChild.draw(graphics, scaleFactor, maxDepth - 1);
                _northeastChild.draw(graphics, scaleFactor, maxDepth - 1);
                _southwestChild.draw(graphics, scaleFactor, maxDepth - 1);
                _northwestChild.draw(graphics, scaleFactor, maxDepth - 1);
            }        
        }
    }
}
