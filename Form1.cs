using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace GDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Size = new Size(1300, 686);

        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Point Point1 = new Point(100, 100);
            Point Point2 = new Point(200, 200);
            Pen MyPen = new Pen(Color.Red, 3);
            Canvas.CreateGraphics().DrawLine(MyPen, Point1, Point2);
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Rectangle MyBox = new Rectangle(5, 10, 150, 200);
            Pen MyPen = new Pen(Color.Blue, 2);
            Canvas.CreateGraphics().DrawEllipse(MyPen, MyBox);
        }

        private void btnBezier_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Point s1 = new Point(10, 100); // Начальная точка
            Point e1 = new Point(100, 10); // Первая контрольная точка
            Point e2 = new Point(150, 150); // Вторая контрольная точка
            Point s2 = new Point(200, 100); // Конечная точка
            Pen Mypen = new Pen(Color.Black, 3);
            Canvas.CreateGraphics().DrawBezier(Mypen, s1, e1, e2, s2);
        }

        private void btnBeziers_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Point[] MyPoints = new[] { new Point(10, 100), new Point(75, 10),
                new Point(80, 50), new Point(100, 150), new Point(125, 80),
                new Point(175, 200), new Point(200, 80) };
            Pen Mypen = new Pen(Color.Red, 3);
            Canvas.CreateGraphics().DrawBeziers(Mypen, MyPoints);
        }

        private void btnEllipseSepment_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            // Создаем однотонную кисть
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            // указываем расположение и размеры эллипса
            float x = 0.0F;
            float y = 0.0F;
            float width = 150.0F;
            float height = 150.0F;
            // Указываем начальный и конечный углы
            float startAngle = 0.0F;
            float endAngle = 120.0F;
            // Заливаем сегмент
            Canvas.CreateGraphics().FillPie(blueBrush, x, y, width, height, startAngle, endAngle);
        }

        private void btnDiagram_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            SolidBrush brush = new SolidBrush(Color.Honeydew);
            float[] Angles = new float[] { 0, 130, 205, 290, 360 };
            Color[] Colors = new[] { Color.LightGoldenrodYellow, Color.PaleTurquoise, Color.RoyalBlue, Color.Purple };
            Rectangle rect = new Rectangle(10, 50, 250, 150);
            int angle;
            for (angle = 1; angle <= Angles.Length - 1; angle++)
            {
                brush.Color = Colors[angle - 1];
                Canvas.CreateGraphics().FillPie(brush, rect, Angles[angle - 1], Angles[angle] - Angles[angle - 1]);
            }
            Canvas.CreateGraphics().DrawEllipse(Pens.Black, rect);
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            // Определяем штриховую кисть
            HatchBrush hBrush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.DarkGoldenrod, Color.Crimson);
            // Создаем точки, определяющие полигон
            PointF point1 = new PointF(0.0F, 0.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(200.0F, 200.0F);
            PointF point8 = new PointF(130.0F, 230.0F);
            PointF[] curvePoints = new[] { point1, point2, point3, point4, point5, point6, point7, point8 };
            // Определяем режим заливки
            FillMode newFillMode = FillMode.Winding;
            // Заливаем полигон
            Canvas.CreateGraphics().FillPolygon(hBrush, curvePoints, newFillMode);
        }

        private void btnPolygons_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10), new Point(200, 10), Color.DarkOliveGreen, Color.DarkOrchid);
            PointF[] FirstCurvePoints = new[] { new PointF(0.0F, 0.0F), new PointF(100.0F, 50.0F), new PointF(200.0F, 5.0F), new PointF(250.0F, 50.0F) };
            PointF[] SecondCurvePoints = new[] { new PointF(300.0F, 100.0F), new PointF(350.0F, 200.0F), new PointF(200.0F, 200.0F), new PointF(130.0F, 230.0F) };
            // Объявляем путь
            GraphicsPath graphPath = new GraphicsPath();
            // Добавляем к пути первый полигон
            graphPath.AddPolygon(FirstCurvePoints);
            // Добавляем к пути второй полигон
            graphPath.AddPolygon(SecondCurvePoints);
            // Закрашиваем путь градиентной заливкой
            Canvas.CreateGraphics().FillPath(linGrBrush, graphPath);
        }

        private void btnTextPolygon_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            GraphicsPath myGraphicsPath = new GraphicsPath();
            Point[] myPointArray = new[] { new Point(15, 50), new Point(20, 40), new Point(50, 30) };
            FontFamily myFontFamily = new FontFamily("Comic Sans Ms");
            PointF myPointF = new PointF(50, 50);
            StringFormat myStringFormat = new StringFormat();
            myGraphicsPath.AddArc(0, 0, 30, 60, 30, 180);
            myGraphicsPath.AddCurve(myPointArray);
            myGraphicsPath.AddString("О сколько нам открытий...", myFontFamily, 0, 32, myPointF, myStringFormat);
            PointF[] CurvePoints = new[] { new PointF(300.0F, 100.0F), new PointF(350.0F, 200.0F), new PointF(200.0F, 200.0F), new PointF(130.0F, 230.0F) };
            myGraphicsPath.AddPolygon(CurvePoints);

            Pen MyPen = new Pen(Color.Black, 1);
            PathGradientBrush pthGrBrush = new PathGradientBrush(myGraphicsPath);
            pthGrBrush.CenterColor = Color.DarkRed;
            Color[] colors = new[] { Color.DarkViolet };
            pthGrBrush.SurroundColors = colors;
            Canvas.CreateGraphics().FillPath(pthGrBrush, myGraphicsPath);
            Canvas.CreateGraphics().DrawPath(MyPen, myGraphicsPath);
        }

        private void btnGradient_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Rectangle MyRectangle = new Rectangle(0, 0, 200, 200);
            Pen MyPen = new Pen(Color.Red, 2);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(MyRectangle);
            PathGradientBrush pthGrBrush = new PathGradientBrush(path);
            // Центр пути будет красного цвета
            pthGrBrush.CenterColor = Color.FromArgb(255, 255, 0, 0);
            Canvas.CreateGraphics().DrawEllipse(MyPen, MyRectangle);
            Canvas.CreateGraphics().FillPath(pthGrBrush, path);
        }

        private void btnPointsArray_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            // Строим градиент, основанный на массиве точке
            PointF[] myPoints = new[] { new PointF(30, 0), new PointF(60, 0), new PointF(90, 30), new PointF(90, 60), new PointF(60, 90), new PointF(30, 90), new PointF(0, 60), new PointF(0, 30) };
            PathGradientBrush myBrush = new PathGradientBrush(myPoints);
            Color[] colors = new[] { Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 255, 0), Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 0, 255, 0), Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 255, 0), Color.FromArgb(255, 0, 0, 255), Color.FromArgb(255, 255, 0, 0) };
            myBrush.SurroundColors = colors;
            // Центр будет белым
            myBrush.CenterColor = Color.White;
            // Используем градиентную кисть для заливки прямоугольника
            Canvas.CreateGraphics().FillRectangle(myBrush, new Rectangle(0, 0, 200, 200));
        }

        private void btnGradientAlongThePath_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Graphics g = Canvas.CreateGraphics();
            // Создаем путь содержащий отдельный прямоугольник
            GraphicsPath MyPath = new GraphicsPath();
            MyPath.AddRectangle(new Rectangle(0, 0, 200, 100));
            // Создаем градиентную кисть, основанную на пути прямоугольника
            PathGradientBrush myBrush = new PathGradientBrush(MyPath);
            // Цвет за пределами границы будет красным
            // Изменяем имя переменной для цвета
            Color[] redColor = new[] { Color.Red };
            myBrush.SurroundColors = redColor;
            // Цвет центра будет морской волны
            myBrush.CenterColor = Color.Aqua;
            // Используем градиентную ксить для заливки прямоугольника
            g.FillPath(myBrush, MyPath);
            // Устанавливаем масштаб фокуса для градиентной кисти
            myBrush.FocusScales = new PointF(0.2F, 0.5F);
            // Используем градиентную кисть для заливки прямоугольника(снова)
            // Показываем этот залитый прямоугольник справа от первого(залитого) ;
            g.TranslateTransform(0.0F, 150.0F);
            g.FillPath(myBrush, MyPath);
        }

        private void btnInterpolation_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            // Вершины внешнего квадрата
            Point[] myPoints = new[] { new Point(0, 0), new Point(200, 0), new Point(200, 200), new Point(0, 200) };
            // Градиентный путь не используется.
            // Градиентная кисть строится прямо из массива точек
            PathGradientBrush myBrush = new PathGradientBrush(myPoints);
            // Создаем массив цветов
            Color[] colors = new[] { Color.FromArgb(255, 0, 128, 0), Color.FromArgb(255, 128, 0, 255), Color.FromArgb(255, 0, 128, 128) };
            float[] relativePositions = new[] { 0.0F, 0.4F, 1.0F };
            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Colors = colors;
            colorBlend.Positions = relativePositions;
            myBrush.InterpolationColors = colorBlend;
            // Заливаем прямоугольник, больший по размерам, чем квадрат
            Canvas.CreateGraphics().FillRectangle(myBrush, 0, 0, 200, 200);

        }

        private void btnGradientCenterPoint_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            // Создаем путь, содержащий полигон
            GraphicsPath path = new GraphicsPath();
            PointF[] Mypoints = new[] { new PointF(0, 150), new PointF(150, 0), new PointF(300, 150), new PointF(150, 300) };
            path.AddPolygon(Mypoints);
            // Используем путь для создания кисти
            PathGradientBrush pthGrBrush = new PathGradientBrush(path);
            // Размещаем центральную точку,
            // не являющуюся центром полигона
            pthGrBrush.CenterPoint = new PointF(120, 40);
            pthGrBrush.CenterColor = Color.DarkRed;
            Color[] colors = new[] { Color.CornflowerBlue };
            pthGrBrush.SurroundColors = colors;
            Canvas.CreateGraphics().FillPolygon(pthGrBrush, Mypoints);
        }

        private void btnTextureFilling_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Graphics g = Canvas.CreateGraphics();
            Image img;
            img = Image.FromFile("C:\\Users\\ПК\\OneDrive\\Изображения\\cry1.jpg");
            TextureBrush tBrush = new TextureBrush(img);
            Pen texturedPen = new Pen(tBrush, 60);
            g.DrawEllipse(texturedPen, 20, 20, 250, 200);
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            // Создаем путь
            GraphicsPath MyPath = new GraphicsPath();
            Rectangle FirstRectangle = new Rectangle(0, 0, 100, 50);
            Rectangle SecondRectangle = new Rectangle(50, 50, 150, 100);
            // Добавляем к пути эллипс и прямоугольник
            MyPath.AddEllipse(FirstRectangle);
            MyPath.AddRectangle(SecondRectangle);
            // Добавляем путь к области
            Region myRegion = new Region(MyPath);
            SolidBrush MyBrush = new SolidBrush(Color.DarkCyan);
            // Закрашиваем область
            Canvas.CreateGraphics().FillRegion(MyBrush, myRegion);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            // Создаем первый путь
            GraphicsPath FirstPath = new GraphicsPath();
            // Добавляем к первому путиэллипс
            FirstPath.AddEllipse(new Rectangle(0, 0, 200, 100));
            // Добавляем к области первый путь
            Region myRegion = new Region(FirstPath);
            // Создаем второй путь
            GraphicsPath SecondPath = new GraphicsPath();
            SolidBrush myBrush = new SolidBrush(Color.Red);
            // Добавляем прямоугольник ко второму пути
            SecondPath.AddRectangle(new Rectangle(50, 50, 250, 150));
            // Вычитаем второй путь из области
            myRegion.Xor(SecondPath);
            Canvas.CreateGraphics().FillRegion(myBrush, myRegion);
        }

        private void btnComb_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            // Создаем первый путь
            GraphicsPath FirstPath = new GraphicsPath();
            // Добавляем к первому путиэллипс
            FirstPath.AddEllipse(new Rectangle(0, 0, 200, 100));
            // Добавляем к области первый путь
            Region myRegion = new Region(FirstPath);
            // Создаем второй путь
            GraphicsPath SecondPath = new GraphicsPath();
            SolidBrush myBrush = new SolidBrush(Color.Red);
            // Добавляем прямоугольник ко второму пути
            SecondPath.AddRectangle(new Rectangle(50, 50, 250, 150));
            // Объединяем второй путь с областью
            myRegion.Union(SecondPath);
            Canvas.CreateGraphics().FillRegion(myBrush, myRegion);
        }

        private void btnComplement_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            GraphicsPath FirstPath = new GraphicsPath();
            GraphicsPath SecondPath = new GraphicsPath();
            // Создаем эллипс и отображаем его на экране
            // с помощью черного цвета
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            FirstPath.AddEllipse(regionRect);
            Canvas.CreateGraphics().DrawPath(Pens.Black, FirstPath);
            // Создаем второй эллипс, пересекающийся с первым,
            // и отображаем его на экране с помощью красного цвета
            Rectangle complementRect = new Rectangle(90, 30, 100, 100);
            SecondPath.AddEllipse(complementRect);
            Canvas.CreateGraphics().DrawPath(Pens.Red, SecondPath);
            // Создаем две области, используя соответственно
            // первый и второй пути
            Region myRegion = new Region(FirstPath);
            // Возвращаем дополнение первой области
            // при объединении со второй областью
            Region complementRegion = new Region(SecondPath);
            // Выполняем заливку области дополнения
            // синим цветом и изображаем ее на экране
            myRegion.Complement(SecondPath);
            // Заливаем дополнение синим цветом
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            Canvas.CreateGraphics().FillRegion(myBrush, myRegion);
        }

        private void btnExclude_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            GraphicsPath FirstPath = new GraphicsPath();
            GraphicsPath SecondPath = new GraphicsPath();
            // Создаем эллипс и отображаем его
            // на экране с помощью черного цвета
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            FirstPath.AddEllipse(regionRect);
            Canvas.CreateGraphics().DrawPath(Pens.Black, FirstPath);
            // Создаем второй эллипс, пересекающийся с первым,
            // и отображаем его на экране с помощью красного цвета
            RectangleF complementRect = new RectangleF(90, 30, 100, 100);
            SecondPath.AddEllipse(complementRect);
            Canvas.CreateGraphics().DrawPath(Pens.Red, SecondPath);
            // Создаем область, используя первый эллипс
            Region myRegion = new Region(FirstPath);
            // Возвращаем неисключенную часть области
            // при объединении со вторым эллипсом
            myRegion.Exclude(SecondPath);
            // Выполняем заливку неисключенной области
            // синим цветом и изображает ее на экране
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            Canvas.CreateGraphics().FillRegion(myBrush, myRegion);
        }

        private void btnIntersect_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            GraphicsPath FirstPath = new GraphicsPath();
            GraphicsPath SecondPath = new GraphicsPath();
            // Создаем первый эллипс и отображаем
            // его на экране с помощью черного цвета
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            FirstPath.AddEllipse(regionRect);
            Canvas.CreateGraphics().DrawPath(Pens.Black, FirstPath);
            // Создаем второй эллипс и отображаем его
            // на экране с помощью красного цвета
            RectangleF complementRect = new RectangleF(90, 30, 100, 100);
            SecondPath.AddEllipse(complementRect);
            Canvas.CreateGraphics().DrawPath(Pens.Red, SecondPath);
            // Создаем область, используя первый эллипс
            Region myRegion = new Region(FirstPath);
            // Возвращаем для области область пересечения
            // при объединении со вторым эллипсом
            myRegion.Intersect(SecondPath);
            // Выполняем заливку области пересечения
            // синим цветом и отображаем ее на экране
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            Canvas.CreateGraphics().FillRegion(myBrush, myRegion);
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            GraphicsPath FirstPath = new GraphicsPath();
            GraphicsPath SecondPath = new GraphicsPath();
            // Создаем эллипс и отображаем его
            // на экране с помощью синего цвета
            Rectangle regionRect = new Rectangle(150, 50, 100, 200);
            FirstPath.AddEllipse(regionRect);
            Canvas.CreateGraphics().DrawPath(Pens.Blue, FirstPath);
            // Создаем область из эллипса
            Region myRegion = new Region(FirstPath);
            // Создаем матрицу преобразования и
            // устанавливаем ее на 45 градусов
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(45, new PointF(175, 0));
            // Применяем к области преобразование
            myRegion.Transform(transformMatrix);
            // Выполняем заливку преобразованной области
            // красным цветом и отображаем ее на экране
            SolidBrush myBrush = new SolidBrush(Color.Red);
            Canvas.CreateGraphics().FillRegion(myBrush, myRegion);
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Rectangle FirstRectangle = new Rectangle(100, 80, 3, 3);
            Rectangle SecondRectangle = new Rectangle(-60, -30, 120, 60);
            Pen pen = new Pen(Color.Black);
            Graphics g = Canvas.CreateGraphics();
            GraphicsContainer graphicsContainer;
            g.FillEllipse(Brushes.Black, FirstRectangle);
            g.TranslateTransform(100, 80);
            graphicsContainer = g.BeginContainer();
            // Вращение на 45 градусов
            g.RotateTransform(45);
            g.DrawEllipse(pen, SecondRectangle);
            g.EndContainer(graphicsContainer);
            g.DrawEllipse(pen, SecondRectangle);
        }

        private void btnClip_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Graphics graphics = Canvas.CreateGraphics();
            GraphicsContainer graphicsContainer;
            Pen redPen = new Pen(Color.Red, 2);
            Pen bluePen = new Pen(Color.Blue, 2);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            Point[] Mypoints = new[] { new Point(10, 10), new Point(100, 10),
                new Point(200, 200), new Point (100, 400) };
            GraphicsPath MyPath = new GraphicsPath();
            MyPath.AddPolygon(Mypoints);
            graphics.SetClip(MyPath);
            graphics.FillRectangle(redBrush, 20, 20, 150, 150);
            graphicsContainer = graphics.BeginContainer();
            // Создаем путь, содержащий отдельный эллипс
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(30, 30, 150, 100);
            // Создаем область, построенную на пути
            Region region = new Region(path);
            graphics.FillRegion(greenBrush, region);
            graphics.SetClip(region, CombineMode.Replace);
            graphics.DrawLine(redPen, 50, 0, 350, 300);
            graphics.EndContainer(graphicsContainer);
            graphics.DrawLine(bluePen, 70, 0, 370, 300);
        }

        private void btnContainerQuality_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Graphics graphics = Canvas.CreateGraphics();
            GraphicsContainer innerContainer;
            GraphicsContainer outerContainer;
            SolidBrush brush = new SolidBrush(Color.Blue);
            FontFamily fontFamily = new FontFamily("Comic Sans MS");
            Font font = new Font(fontFamily, 24, FontStyle.Regular, GraphicsUnit.Pixel);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            outerContainer = graphics.BeginContainer();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            innerContainer = graphics.BeginContainer();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.DrawString("Внутренний контейнер", font, brush, new PointF(0, 10));
            graphics.EndContainer(innerContainer);
            graphics.DrawString("Внешний контейнер", font, brush, new PointF(0, 40));
            graphics.EndContainer(outerContainer);
            graphics.DrawString("Графический объект", font, brush, new PointF(0, 80));
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            PictureBox MyPictureBox = new PictureBox();
            MyPictureBox.Location = new Point(10, 10);
            MyPictureBox.Size = new Size(750, 409);
            Canvas.Controls.Add(MyPictureBox);
            Image img;
            img = Image.FromFile(@"C:\\Users\\ПК\\OneDrive\\Изображения\\cry2.jpg");
            MyPictureBox.Image = img;
        }

        private void btnDownloadImage_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Stream myStream;
            OpenFileDialog MyopenFileDialog = new OpenFileDialog();
            MyopenFileDialog.InitialDirectory = @"C:\Users\ПК\OneDrive\Изображения";
            MyopenFileDialog.Filter = @"Images|*.GIF;*JPG;*.TIF;*BMP";
            MyopenFileDialog.FilterIndex = 2;
            MyopenFileDialog.RestoreDirectory = true;
            PictureBox MyPictureBox = new PictureBox();
            if (MyopenFileDialog.ShowDialog() == DialogResult.OK)
            {
                myStream = MyopenFileDialog.OpenFile();
                if (!(myStream == null))
                {
                    MyPictureBox.Location = new Point(0, 0);
                    Canvas.Controls.Add(MyPictureBox);
                    int height = Image.FromFile(MyopenFileDialog.FileName).Height;
                    int width = Image.FromFile(MyopenFileDialog.FileName).Width;
                    MyPictureBox.Size = new Size(width, height);
                    MyPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    MyPictureBox.Image = Image.FromFile(MyopenFileDialog.FileName);
                    myStream.Close();
                }
            }
        }

        private void btnRotateFlip_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            PictureBox MyPictureBox = new PictureBox();
            MyPictureBox.Location = new Point(10, 10);
            MyPictureBox.Size = new Size(750, 409);
            Image img;
            img = Image.FromFile(@"C:\\Users\\ПК\\OneDrive\\Изображения\\cry2.jpg");
            MyPictureBox.Image = img;
            MyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Canvas.Controls.Add(MyPictureBox);
        }

        private void btnPlacement_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Image img;
            img = Image.FromFile(@"C:\\Users\\ПК\\OneDrive\\Изображения\\cry2.jpg");
            Point Point1 = new Point(50, 50);
            Graphics g = Canvas.CreateGraphics();
            g.DrawImage(img, Point1);
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            PointF[] Mypoints = new[] { new PointF(0, 0), new PointF(100, 10), new PointF(200, 200), new PointF(100, 400) };
            GraphicsPath MyPath = new GraphicsPath();
            MyPath.AddPolygon(Mypoints);
            Graphics g = Canvas.CreateGraphics();
            RectangleF clipRect = new RectangleF(0, 0, 300, 300);
            g.SetClip(MyPath);
            g.DrawImage(Image.FromFile("C:\\Users\\ПК\\OneDrive\\Изображения\\cry2.jpg"), 0, 0);
        }

        private void btnVectorImage_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Graphics g = Canvas.CreateGraphics();
            g.Clear(Color.White);
            System.Drawing.Imaging.Metafile myBitmap = new System.Drawing.Imaging.Metafile("C:\\Users\\ПК\\OneDrive\\Изображения\\monke.wmf");
            g.DrawImage(myBitmap, 10, 10);
        }

        private void btnColorModel_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            Color newColor = Color.FromArgb(128, 128, 128);
            Canvas.BackColor = newColor;
        }

        private void btnWaterMark_Click(object sender, EventArgs e)
        {
            Canvas.BackColor = Color.White;
            Canvas.Controls.Clear();
            Canvas.Refresh();
            PictureBox MyPictureBox = new PictureBox();
            MyPictureBox.Location = new Point(10, 10);
            MyPictureBox.Size = new Size(400, 218);
            Canvas.Controls.Add(MyPictureBox);
            Font WMfont = new Font("Comic Sans MS", 40, FontStyle.Bold);
            SolidBrush WMBrush = new SolidBrush(Color.FromArgb(122, 9, 97, 18));
            Image img;
            img = Image.FromFile(@"C:\\Users\\ПК\\OneDrive\\Изображения\\cry2.jpg");
            MyPictureBox.Image = img;
            Graphics g = Graphics.FromImage(MyPictureBox.Image);
            g.DrawString("паучок", WMfont, WMBrush, 100, 30);
        }

        private void btnColorInversion_Click(object sender, EventArgs e)
        {
            Canvas.Controls.Clear();
            Canvas.Refresh();
            PictureBox MyPictureBox = new PictureBox();
            MyPictureBox.Location = new Point(10, 10);
            MyPictureBox.Size = new Size(400, 218);
            Canvas.Controls.Add(MyPictureBox);
            MyPictureBox.Image = Image.FromFile("C:\\Users\\ПК\\OneDrive\\Изображения\\cry2.jpg");
            Bitmap bmap = new Bitmap(MyPictureBox.Image);
            MyPictureBox.Image = bmap;
            Bitmap tempbmp = new Bitmap(MyPictureBox.Image);
            int DX = 1;
            int DY = 1;
            int red, green, blue;
            int i, j;
            {
                var withBlock = tempbmp;
                for (i = DX; i <= withBlock.Height - DX - 1; i++)
                {
                    for (j = DY; j <= withBlock.Width - DY - 1; j++)
                    {
                        red = 255 - Convert.ToInt32(Convert.ToInt32(withBlock.GetPixel(j - 1, i - 1).R));
                        green = 255 - Convert.ToInt32(Convert.ToInt32(withBlock.GetPixel(j - 1, i - 1).G));
                        blue = 255 - Convert.ToInt32(Convert.ToInt32(withBlock.GetPixel(j - 1, i - 1).B));

                        red = Math.Min(Math.Max(red, 0), 255);
                        green = Math.Min(Math.Max(green, 0), 255);
                        blue = Math.Min(Math.Max(blue, 0), 255);
                        bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                        if (i % 10 == 0)
                        {
                            MyPictureBox.Invalidate();
                            MyPictureBox.Refresh();
                        }

                    }
                }
            }
        }
    }
}
