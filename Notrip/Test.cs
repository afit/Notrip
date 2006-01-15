
//      private Rectangle myRectangle;
//      private Graphics myGraphic;
//      private Pen mDataPen;

//      private int pMax = 0;
//      private int pMaxValue = 0;
//      private int rndnum = 0;

//      private const int loopCount = 180;

//      public readonly int LeftOffset = 15;
//      public readonly int RightOffset = 5;
//      public readonly int TopOffset = 20;
//      public readonly int BottomOffset = 20;

//      private void initHistogram(){
//         myRectangle = new Rectangle(10, 10, 200, 200);
//         mDataPen = new Pen(Color.Navy, 2);
//         myGraphic = this.CreateGraphics();

//      }

//      private void DrawData(){
//         populateArray2();
//         Point[] pts = new Point[mData.Count];

//         for (int i=0; i < mData.Count; i++){
//            pts[i].X = LeftOffset + ((Point)mData[i]).X;
//            pts[i].Y = myRectangle.Height - (BottomOffset + ((Point)mData[i]).Y);
//         }

//         myGraphic.Clear(System.Drawing.SystemColors.Control);
//         myGraphic.DrawRectangle(Pens.Black, 4, 4, myRectangle.Width - 1, myRectangle.Height - 1);

//         pMaxValue = myRectangle.Height-(BottomOffset + pMax);
//         this.label1.Text = pMax.ToString();
//         this.label1.Location = new Point(10, pMaxValue-25);

//         myGraphic.DrawLine(Pens.Black,10,pMaxValue,180,pMaxValue);
//         myGraphic.DrawCurve(mDataPen, pts);
//      }

//      private void populateArray2(){
//         mData.Clear();

//         for(int i=0;i<loopCount;i=i+trackBar3.Value){
//            if (i < (loopCount/2) - trackBar2.Value || i > (loopCount/2) + trackBar2.Value){
//               rndnum = r.Next(0,10);
//            }else{
//               rndnum = r.Next(trackBar1.Value - trackBar4.Value/2,trackBar1.Value);
//            }

//            mData.Add(new Point(i, rndnum));

//            if (i == 0){
//               pMax = rndnum;
//            }else{
//               if(rndnum > pMax){
//                  pMax = rndnum;
//               }
//            }
//         }
//      }
//   }
//}