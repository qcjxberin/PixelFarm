﻿//2014 BSD,WinterDev

//MatterHackers: BSD
// Much of the ui to the drawing functions still needs to be C#'ed and cleaned up.  A lot of
// it still follows the originall agg function names.  I have been cleaning these up over time
// and intend to do much more refactoring of these things over the long term.

using System;

using MatterHackers.Agg.Image;
using MatterHackers.Agg.VertexSource;
using MatterHackers.Agg.Font;
using MatterHackers.VectorMath;
using MatterHackers.Agg.Transform;
 

using Mini;
namespace MatterHackers.Agg.Sample_Draw
{
   
    [Info(OrderCode = "01")]
    [Info("from MatterHackers' Agg DrawAndSave")]
    public class DrawSample01 : DemoBase
    {
        public override void Init()
        {

        }
        public override void Draw(Graphics2D g)
        {
            //1.
            // clear the image to white
            {
                g.Clear(ColorRGBA.White);
                // draw a circle
                g.Circle(50, 50, 30, ColorRGBA.Blue);
                // draw a line
                g.Line(10, 100, 520, 50, new ColorRGBA(20, 200, 200));
                // draw a filled box
                g.FillRectangle(60, 260, 200, 280, ColorRGBA.Yellow);

                // and an outline around it
                g.Rectangle(60, 260, 200, 280, ColorRGBA.Magenta);



                // draw some text
                g.DrawString("A Simple Example", 300, 400, 20);

                g.DrawString2("A Simple Example2", 300, 350, 20, drawFromHintedCache: true);

                g.DrawString2("A Simple Example3", 300, 300, 20);

                g.DrawString2("A Simple Example4", 300, 250, 20);
                //---------------------------------------------------

            }
        }
    }


    [Info(OrderCode = "01")]
    [Info("from MatterHackers' Agg DrawAndSave")]
    public class DrawSample02 : DemoBase
    {
        public override void Init()
        {

        }
        public override void Draw(Graphics2D g)
        {
            int width = 800;
            int height = 600;

            //clear the image to white
            g.Clear(ColorRGBA.White);
            // draw a circle
            Ellipse ellipseTest = new Ellipse(0, 0, 100, 50);
            for (double angleDegrees = 0; angleDegrees < 180; angleDegrees += 22.5)
            {

                VertexSourceApplyTransform rotatedTransform = new VertexSourceApplyTransform(
                    ellipseTest, 
                    Affine.NewRotation(MathHelper.DegreesToRadians(angleDegrees)));
                VertexSourceApplyTransform rotatedAndTranslatedTransform = new VertexSourceApplyTransform(
                    rotatedTransform, Affine.NewTranslation(width / 2, 150));

                g.Render(rotatedAndTranslatedTransform, ColorRGBA.Yellow);
                Stroke ellipseOutline = new Stroke(rotatedAndTranslatedTransform, 3);
                g.Render(ellipseOutline, ColorRGBA.Blue);
            }

            // and a little polygon
            PathStorage littlePoly = new PathStorage();
            littlePoly.MoveTo(50, 50);
            littlePoly.LineTo(150, 50);
            littlePoly.LineTo(200, 200);
            littlePoly.LineTo(50, 150);
            littlePoly.LineTo(50, 50);
            g.Render(littlePoly, ColorRGBA.Cyan);

            // draw some text

            var textPrinter = new TypeFacePrinter("Printing from a printer", 30, justification: Justification.Center);

            IVertexSource translatedText = new VertexSourceApplyTransform(textPrinter, Affine.NewTranslation(
                new Vector2(width / 2, height / 4 * 3)));
            g.Render(translatedText, ColorRGBA.Red);
            Stroke strokedText = new Stroke(translatedText);
            g.Render(strokedText, ColorRGBA.Black);

            IVertexSource rotatedText = new VertexSourceApplyTransform(textPrinter, Affine.NewRotation(MathHelper.DegreesToRadians(90)));
            IVertexSource rotatedTranslatedText = new VertexSourceApplyTransform(rotatedText, Affine.NewTranslation(
                new Vector2(40, height / 2)));
            g.Render(rotatedTranslatedText, ColorRGBA.Black);
        }
    }

    //public class SimpleDrawAndSave
    //{
    //    [STAThread]
    //    public static void Main(string[] args)
    //    {
    //        // first we will show how to use the simple drawing functions in graphics 2D
    //        {
    //            ImageBuffer simpleImage = new ImageBuffer(640, 480, 32, new BlenderBGRA());
    //            Graphics2D simpleImageGraphics2D = simpleImage.NewGraphics2D();
    //            // clear the image to white
    //            simpleImageGraphics2D.Clear(RGBA_Bytes.White);
    //            // draw a circle
    //            simpleImageGraphics2D.Circle(50, 50, 30, RGBA_Bytes.Blue);
    //            // draw a line
    //            simpleImageGraphics2D.Line(10, 100, 520, 50, new RGBA_Bytes(20, 200, 200));
    //            // draw a filled box
    //            simpleImageGraphics2D.FillRectangle(60, 260, 200, 280, RGBA_Bytes.Yellow);
    //            // and an outline around it
    //            simpleImageGraphics2D.Rectangle(60, 260, 200, 280, RGBA_Bytes.Magenta);
    //            // draw some text
    //            simpleImageGraphics2D.DrawString("A Simple Example", 300, 400, 20);

    //            // and save this image out
    //            ImageTgaIO.Save(simpleImage, "SimpleDrawAndSave.tga");
    //        }

    //        // now we will we will show how to use the render function to draw more complex things
    //        {
    //            ImageBuffer lessSimpleImage = new ImageBuffer(640, 480, 32, new BlenderBGRA());
    //            Graphics2D lessSimpleImageGraphics2D = lessSimpleImage.NewGraphics2D();
    //            // clear the image to white
    //            lessSimpleImageGraphics2D.Clear(RGBA_Bytes.White);
    //            // draw a circle
    //            Ellipse ellipseTest = new Ellipse(0, 0, 100, 50);
    //            for (double angleDegrees = 0; angleDegrees < 180; angleDegrees += 22.5)
    //            {
    //                VertexSourceApplyTransform rotatedTransform = new VertexSourceApplyTransform(ellipseTest, Affine.NewRotation(MathHelper.DegreesToRadians(angleDegrees)));
    //                VertexSourceApplyTransform rotatedAndTranslatedTransform = new VertexSourceApplyTransform(rotatedTransform, Affine.NewTranslation(lessSimpleImage.Width / 2, 150));
    //                lessSimpleImageGraphics2D.Render(rotatedAndTranslatedTransform, RGBA_Bytes.Yellow);
    //                Stroke ellipseOutline = new Stroke(rotatedAndTranslatedTransform, 3);
    //                lessSimpleImageGraphics2D.Render(ellipseOutline, RGBA_Bytes.Blue);
    //            }

    //            // and a little polygon
    //            PathStorage littlePoly = new PathStorage();
    //            littlePoly.MoveTo(50, 50);
    //            littlePoly.LineTo(150, 50);
    //            littlePoly.LineTo(200, 200);
    //            littlePoly.LineTo(50, 150);
    //            littlePoly.LineTo(50, 50);
    //            lessSimpleImageGraphics2D.Render(littlePoly, RGBA_Bytes.Cyan);

    //            // draw some text
    //            TypeFacePrinter textPrinter = new TypeFacePrinter("Printing from a printer", 30, justification: Justification.Center);
    //            IVertexSource translatedText = new VertexSourceApplyTransform(textPrinter, Affine.NewTranslation(new Vector2(lessSimpleImage.Width / 2, lessSimpleImage.Height / 4 * 3)));
    //            lessSimpleImageGraphics2D.Render(translatedText, RGBA_Bytes.Red);
    //            Stroke strokedText = new Stroke(translatedText);
    //            lessSimpleImageGraphics2D.Render(strokedText, RGBA_Bytes.Black);

    //            IVertexSource rotatedText = new VertexSourceApplyTransform(textPrinter, Affine.NewRotation(MathHelper.DegreesToRadians(90)));
    //            IVertexSource rotatedTranslatedText = new VertexSourceApplyTransform(rotatedText, Affine.NewTranslation(new Vector2(40, lessSimpleImage.Height / 2)));
    //            lessSimpleImageGraphics2D.Render(rotatedTranslatedText, RGBA_Bytes.Black);

    //            // and save this image out
    //            ImageTgaIO.Save(lessSimpleImage, "LessSimpleDrawAndSave.tga");
    //        }
    //    }
    //}
}
