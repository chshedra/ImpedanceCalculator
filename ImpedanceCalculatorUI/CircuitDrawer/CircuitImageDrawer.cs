using System;
using System.Drawing;
using ImpedanceCalculator;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculatorUI.CircuitDrawer
{
    /// <summary>
    ///     Класс отрисовки цепи
    /// </summary>
    internal static class CircuitImageDrawer
    {
	    #region Private Members

        /// <summary>
        /// Рисование элемента.
        /// </summary>
        /// <param name="graphics"></param>
        private delegate void DrawElementProcedure(Graphics graphics, string elementName);


        /// <summary>
        /// Стандартная кисть для линий.
        /// </summary>
        private static readonly Pen StandartPen = new Pen(Color.Black);

        /// <summary>
        /// Размер пустого битмапа.
        /// </summary>
        private static readonly Size EmptyImageSize = new Size(1, 1);

        /// <summary>
        /// Размер простейшего элемента эл.цепи
        /// </summary>
        private static readonly Size ElementSize = new Size(100, 100);

        /// <summary>
        /// Длина входной линии.
        /// </summary>
        private const int InputLineLength = 20;

        /// <summary>
        /// Длина выходной линии.
        /// </summary>
        private const int OutputLineLength = 40;

        /// <summary>
        ///  Делитель изображения. Определяет в какой части будет находится входная и выходная линии.
        /// </summary>
        private const int ImageDellimitterConst = 2;

        /// <summary>
        /// Определяет где будет находиться выходная вертикальная линий у параллельной цепи.
        /// </summary>
        private const int ParallelConnector = 10;

        #endregion

        #region Methods

        /// <summary>
        ///  Метод, позволяющий отрисовать(вернуть битмап) эл. цепь.
        /// </summary>
        /// <param name="circuit">Электическая цепь.</param>
        public static Bitmap GetImage(ISegment segment)
        {
	        switch (segment)
	        {
		        case SerialCircuit serial:
		        {
			        return GetCircuitImage(serial);
		        }
		        case ParallelCircuit parallel:
		        {
			        return GetCircuitImage(parallel);
		        }
		        default:
		        {
			        return new Bitmap(0, 0);
		        }
	        }
        }


        /// <summary>
        /// Метод отрисовывающий последовательную электрическую цепь.
        /// </summary>
        /// <param name="circuit">Электрическая цепь с последовательным соедининением.</param>
        private static Bitmap GetCircuitImage(SerialCircuit circuit)
        {
            var size = GetSize(circuit);

            var bitmap = new Bitmap(size.Width, size.Height);
            var x = 0;
            var y = size.Height / ImageDellimitterConst;

            var g = Graphics.FromImage(bitmap);
            
                foreach (var segment in circuit)
                    if (segment is IElement)
                    {
                        var elementImage = GetElementImage(segment as ElementBase);
                        g.DrawImage(elementImage, new Point(x, y - elementImage.Height / ImageDellimitterConst));
                        x += GetSize(segment as ElementBase).Width;
                    }
                    else if (segment is CircuitBase)
                    {
                        var circuitImage = new Bitmap(EmptyImageSize.Width, EmptyImageSize.Height);
                        if (segment is SerialCircuit)
                            circuitImage = GetCircuitImage((SerialCircuit)segment);
                        else if (segment is ParallelCircuit)
                            circuitImage = GetCircuitImage((ParallelCircuit)segment);
                        g.DrawImage(circuitImage, new Point(x, y - circuitImage.Height / ImageDellimitterConst));
                        x += GetSize(segment).Width;
                    }
                return bitmap;
        }

        /// <summary>
        /// Метод отрисовывающий цепь с параллельным соединением.
        /// </summary>
        /// <param name="circuit"> цепь с параллельным соединением.</param>
        private static Bitmap GetCircuitImage(ParallelCircuit circuit)
        {
            var size = GetSize(circuit);
            var bitmap = new Bitmap(size.Width, size.Height);
            var x = InputLineLength;
            var y = 0;
            var firstSegment = circuit.FirstOrDefault();
            var lastElement = circuit.LastOrDefault();
            if (firstSegment == null || lastElement == null)
            {
	            return bitmap;
            }
            var firstHeight = GetSize(firstSegment).Height;
            var lastHeight = GetSize(lastElement).Height;

            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(StandartPen, 0, size.Height / ImageDellimitterConst , InputLineLength,
                    size.Height / ImageDellimitterConst);

                g.DrawLine(StandartPen, x, y + firstHeight / ImageDellimitterConst , x,
                    size.Height - lastHeight / ImageDellimitterConst);
               
                foreach (var segment in circuit)
                    if (segment is ElementBase)
                    {
                        var elementImage = GetElementImage(segment as ElementBase);
                        g.DrawImage(elementImage, new Point(x, y));

                        g.DrawLine(StandartPen, x + elementImage.Width,
                            y + elementImage.Height / ImageDellimitterConst , bitmap.Width - ParallelConnector,
                            y + elementImage.Height / ImageDellimitterConst );
                        y += elementImage.Height;
                    }
                    else if (segment is CircuitBase)
                    {
                        var circuitImage = new Bitmap(1, 1);
                        if (segment is SerialCircuit)
                            circuitImage = GetCircuitImage(segment as SerialCircuit);
                        else if (segment is ParallelCircuit)
                            circuitImage = GetCircuitImage(segment as ParallelCircuit);
                        g.DrawImage(circuitImage, new Point(x, y));
                      
                        g.DrawLine(StandartPen, x + circuitImage.Width,
                            y + circuitImage.Height / ImageDellimitterConst, bitmap.Width - ParallelConnector,
                            y + circuitImage.Height / ImageDellimitterConst);
                        y += circuitImage.Height;
                    }

                g.DrawLine(StandartPen, bitmap.Width - ParallelConnector, firstHeight / ImageDellimitterConst,
                    bitmap.Width - ParallelConnector, size.Height - lastHeight / ImageDellimitterConst);
               

                g.DrawLine(StandartPen, bitmap.Width - ParallelConnector, bitmap.Height / ImageDellimitterConst,
                    bitmap.Width, bitmap.Height / ImageDellimitterConst);
              
            }
            return bitmap;
        }

        #endregion

        #region Get Size Methods

        /// <summary>
        ///     Вычисляет размер любого компонента эл. цепи.
        /// </summary>
        /// <param name="segment">Компонент эл. цепи.</param>
        private static Size GetSize(ISegment segment)
        {
            if (segment is CircuitBase)
                return GetSize((CircuitBase)segment);
            if (segment is IElement)
                return GetSize((ElementBase)segment);
            return new Size(EmptyImageSize.Width, EmptyImageSize.Height);
        }

        /// <summary>
        ///     Вычисляет размер элемента эл. цепи.
        /// </summary>
        /// <param name="element">Элемент эл. цепи.</param>
        private static Size GetSize(ElementBase element)
        {
            return new Size(ElementSize.Width, ElementSize.Width);
        }

        /// <summary>
        ///     Вычисляет размер рисунка эл. цепи.
        /// </summary>
        /// <param name="circuit">Эл. цепь.</param>
        private static Size GetSize(CircuitBase circuit)
        {
            if (circuit is SerialCircuit)
                return GetSize((SerialCircuit)circuit);
            if (circuit is ParallelCircuit)
                return GetSize((ParallelCircuit)circuit);
            return new Size(1, 1);
        }

        /// <summary>
        ///     Вычисляет размер рисунка эл. цепи с последовательным соединением.
        /// </summary>
        /// <param name="circuit">Эл. цепь с последовательным соединением.</param>
        private static Size GetSize(SerialCircuit circuit)
        {
            var size = circuit.Count > 0 ? new Size(0, 0) : new Size(EmptyImageSize.Width, EmptyImageSize.Height);
            foreach (var segment in circuit)
                if (segment is ElementBase)
                {
                    size.Height = size.Height < GetSize((ElementBase)segment).Height
                        ? GetSize((ElementBase)segment).Height
                        : size.Height;
                    size.Width = size.Width + GetSize((ElementBase)segment).Width;
                }
                else if (segment is SerialCircuit)
                {
                    var scSize = GetSize(segment as SerialCircuit);
                    size.Height = size.Height < scSize.Height ? scSize.Height : size.Height;
                    size.Width = size.Width + scSize.Width;
                }
                else if (segment is ParallelCircuit)
                {
                    var pcSize = GetSize(segment as ParallelCircuit);
                    size.Height = size.Height < pcSize.Height ? pcSize.Height : size.Height;
                    size.Width = size.Width + pcSize.Width;
                }
            return size;
        }

        /// <summary>
        /// Вычисляет размер рисунка эл. цепи с параллельным соединением.
        /// </summary>
        /// <param name="circuit">Эл. цепь с параллельным соединением.</param>
        private static Size GetSize(ParallelCircuit circuit)
        {
            var size = circuit.Count > 0 ? new Size(0, 0) : new Size(EmptyImageSize.Width, EmptyImageSize.Height);
            foreach (var segment in circuit)
                if (segment is ElementBase)
                {
                    size.Height = size.Height + GetSize((ElementBase)segment).Height;
                    size.Width = size.Width < GetSize((ElementBase) segment).Width
                        ? GetSize((ElementBase)segment).Width
                        : size.Width;
                }
                else if (segment is SerialCircuit)
                {
                    var scSize = GetSize(segment as SerialCircuit);
                    size.Width = size.Width < scSize.Width ? scSize.Width : size.Width;
                    size.Height = size.Height + scSize.Height;
                }
                else if (segment is ParallelCircuit)
                {
                    var pcSize = GetSize(segment as ParallelCircuit);
                    size.Width = size.Width < pcSize.Width ? pcSize.Width : size.Width;
                    size.Height = size.Height + pcSize.Height;
                }
            size.Width += InputLineLength + OutputLineLength;
            return size;
        }

        #endregion

        #region Element Drawers

        /// <summary>
        ///     Рисует элемент электрической цепи.
        /// </summary>
        /// <param name="element"></param>
        private static Bitmap GetElementImage(IElement element)
        {
            var drawer = ElementDrawProcedureSelector(element);

            var bitmap = new Bitmap(GetSize(element).Height, GetSize(element).Width);
            var g = Graphics.FromImage(bitmap);
            
	        drawer(g, element.Name);
            
            return bitmap;
        }

        /// <summary>
        /// Выбирает метод рисования элемента эл.цепи.
        /// </summary>
        /// <param name="element"></param>
        private static DrawElementProcedure ElementDrawProcedureSelector(IElement element)
        {
            if (element is Resistor)
                return DrawResistor;
            if (element is Capacitor)
                return DrawCapacitor;
            if (element is Inductor)
                return DrawInductor;
            throw new NotImplementedException("Unknown element");
        }

        /// <summary>
        /// Рисует резистор.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="resistorName"></param>
        private static void DrawResistor(Graphics graphics, string resistorName)
        {
            graphics.DrawRectangle(StandartPen, new Rectangle(20, 34, 60, 32));

            graphics.DrawLine(StandartPen, 0, 50, 20, 50);
            graphics.DrawLine(StandartPen, 80, 50, ElementSize.Width, 50);

            graphics.DrawString(resistorName, new Font(FontFamily.GenericSansSerif,  
	            10, FontStyle.Regular), new SolidBrush(Color.Black), 40, 10);
        }

        /// <summary>
        /// Рисует конденсатор.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="capacitorName"></param>
        private static void DrawCapacitor(Graphics graphics, string capacitorName)
        {
            graphics.DrawLine(StandartPen, 40, 35, 40, 65);
            graphics.DrawLine(StandartPen, 60, 35, 60, 65);

            graphics.DrawLine(StandartPen, 0, 50, 40, 50);
            graphics.DrawLine(StandartPen, 60, 50, ElementSize.Width, 50);

            graphics.DrawString(capacitorName, new Font(FontFamily.GenericSansSerif,
	            10, FontStyle.Regular), new SolidBrush(Color.Black), 40, 10);
        }

        /// <summary>
        /// Рисует катушку индуктивности.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="inductorName"></param>
        private static void DrawInductor(Graphics graphics, string inductorName)
        {
            graphics.DrawBezier(StandartPen, 40, 50, 40, 40, 48, 40, 48, 50);
            graphics.DrawBezier(StandartPen, 48, 50, 48, 40, 56, 40, 56, 50);
            graphics.DrawBezier(StandartPen, 56, 50, 56, 40, 64, 40, 64, 50);
            graphics.DrawBezier(StandartPen, 64, 50, 64, 40, 72, 40, 72, 50);
            graphics.DrawBezier(StandartPen, 72, 50, 72, 40, 80, 40, 80, 50);

            graphics.DrawLine(StandartPen, 0, 50, 40, 50);
            graphics.DrawLine(StandartPen, 80, 50, ElementSize.Width, 50);

            graphics.DrawString(inductorName, new Font(FontFamily.GenericSansSerif,
	            10, FontStyle.Regular), new SolidBrush(Color.Black), 50, 20);
        }

        #endregion
    }
}