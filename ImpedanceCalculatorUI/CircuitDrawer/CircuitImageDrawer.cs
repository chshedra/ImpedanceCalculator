#region Using

using System;
using System.Drawing;
using ImpedanceCalculator;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

#endregion

namespace ImpedanceCalculatorUI.CircuitDrawer
{
    /// <summary>
    ///     Класс отрисовки цепи
    /// </summary>
    internal static class CircuitImageDrawer
    {
        #region Public Methods

        /// <summary>
        ///     Метод позволяющий отрисовать(вернуть битмап) эл. цепь.
        /// </summary>
        /// <param name="circuit">Электическая цепь.</param>
        public static Bitmap GetImage(this ISegment circuit)
        {
            if (circuit is SerialCircuit)
                return GetCircuitImage(circuit as SerialCircuit);
            if (circuit is ParallelCircuit)
                return GetCircuitImage(circuit as ParallelCircuit);
            return new Bitmap(0, 0);
        }

        #endregion

        #region Private Members

        /// <summary>
        ///     Процедура рисования элемента.
        /// </summary>
        /// <param name="graphics"></param>
        private delegate void DrawElementProcedure(Graphics graphics);

        /// <summary>
        ///     Стандартная кисть для линий.
        /// </summary>
        private static readonly Pen StandartPen = new Pen(Color.Black);

        /// <summary>
        ///     Размер пустого битмапа.
        /// </summary>
        private static readonly Size EmptyImageSize = new Size(1, 1);

        /// <summary>
        ///     Размер простейшего элемента эл.цепи
        /// </summary>
        private static readonly Size ElementSize = new Size(50, 50);

        /// <summary>
        ///     Длина входной линии.
        /// </summary>
        private const int InputLineLength = 10;

        /// <summary>
        ///     Длина выходной линии.
        /// </summary>
        private const int OutputLineLength = 20;

        /// <summary>
        ///     Делитель изображения. Определяет в какой части будет находится входная и выходная линии.
        /// </summary>
        private const int ImageDellimitterConst = 2;

        /// <summary>
        ///     Определяет где будет находиться выходная вертикальная линий у параллельной цепи.
        /// </summary>
        private const int ParallelConnector = 10;

        #endregion

        #region Private Methods

        #region Circuit Drawers

        /// <summary>
        ///     Метод отрисовывающий последовательную электрическую цепь.
        /// </summary>
        /// <param name="circuit">Электрическая цепь с последовательным соедининением.</param>
        private static Bitmap GetCircuitImage(SerialCircuit circuit)
        {
            var size = GetSize(circuit);

            var bitmap = new Bitmap(size.Width, size.Height);
            var x = 0;
            var y = size.Height / ImageDellimitterConst;

            using (var g = Graphics.FromImage(bitmap))
            {
                foreach (var component in circuit)
                    if (component is IElement)
                    {
                        var elementImage = GetElementImage(component as IElement);
                        g.DrawImage(elementImage, new Point(x, y - elementImage.Height / ImageDellimitterConst));
                        x += GetSize(component as IElement).Width;
                    }
                    else if (component is CircuitBase)
                    {
                        var circuitImage = new Bitmap(EmptyImageSize.Width, EmptyImageSize.Height);
                        if (component is SerialCircuit)
                            circuitImage = GetCircuitImage(component as SerialCircuit);
                        else if (component is ParallelCircuit)
                            circuitImage = GetCircuitImage(component as ParallelCircuit);
                        g.DrawImage(circuitImage, new Point(x, y - circuitImage.Height / ImageDellimitterConst));
                        x += GetSize(component).Width;
                    }
            }
            return bitmap;
        }

        /// <summary>
        ///     Метод отрисовывающий эл. цепь с параллельным соединением.
        /// </summary>
        /// <param name="circuit">Эл. цепь с параллельным соединением.</param>
        private static Bitmap GetCircuitImage(ParallelCircuit circuit)
        {
            var size = GetSize(circuit);
            var bitmap = new Bitmap(size.Width, size.Height);
            var x = InputLineLength;
            var y = 0;
            var firstComponent = circuit.FirstOrDefault();
            var lastElement = circuit.LastOrDefault();
            if (firstComponent == null || lastElement == null)
                return bitmap;
            var firstHeight = GetSize(firstComponent).Height;
            var lastHeight = GetSize(lastElement).Height;

            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawLine(StandartPen, 0, size.Height / ImageDellimitterConst, InputLineLength,
                    size.Height / ImageDellimitterConst);
                g.DrawLine(StandartPen, 0, size.Height / ImageDellimitterConst - 1, InputLineLength,
                    size.Height / ImageDellimitterConst - 1);

                g.DrawLine(StandartPen, x, y + firstHeight / ImageDellimitterConst, x,
                    size.Height - lastHeight / ImageDellimitterConst);
                g.DrawLine(StandartPen, x + 1, y + firstHeight / ImageDellimitterConst, x + 1,
                    size.Height - lastHeight / ImageDellimitterConst);
                foreach (var component in circuit)
                    if (component is IElement)
                    {
                        var elementImage = GetElementImage(component as IElement);
                        g.DrawImage(elementImage, new Point(x, y));
                        g.DrawLine(StandartPen, x + elementImage.Width, y + elementImage.Height / ImageDellimitterConst,
                            bitmap.Width - ParallelConnector, y + elementImage.Height / ImageDellimitterConst);
                        g.DrawLine(StandartPen, x + elementImage.Width,
                            y + elementImage.Height / ImageDellimitterConst - 1, bitmap.Width - ParallelConnector,
                            y + elementImage.Height / ImageDellimitterConst - 1);
                        y += elementImage.Height;
                    }
                    else if (component is CircuitBase)
                    {
                        var circuitImage = new Bitmap(1, 1);
                        if (component is SerialCircuit)
                            circuitImage = GetCircuitImage(component as SerialCircuit);
                        else if (component is ParallelCircuit)
                            circuitImage = GetCircuitImage(component as ParallelCircuit);
                        g.DrawImage(circuitImage, new Point(x, y));
                        g.DrawLine(StandartPen, x + circuitImage.Width, y + circuitImage.Height / ImageDellimitterConst,
                            bitmap.Width - ParallelConnector, y + circuitImage.Height / ImageDellimitterConst);
                        g.DrawLine(StandartPen, x + circuitImage.Width,
                            y + circuitImage.Height / ImageDellimitterConst - 1, bitmap.Width - ParallelConnector,
                            y + circuitImage.Height / ImageDellimitterConst - 1);
                        y += circuitImage.Height;
                    }

                g.DrawLine(StandartPen, bitmap.Width - ParallelConnector, firstHeight / ImageDellimitterConst,
                    bitmap.Width - ParallelConnector, size.Height - lastHeight / ImageDellimitterConst);
                g.DrawLine(StandartPen, bitmap.Width - ParallelConnector - 1, firstHeight / ImageDellimitterConst,
                    bitmap.Width - ParallelConnector - 1, size.Height - lastHeight / ImageDellimitterConst);

                g.DrawLine(StandartPen, bitmap.Width - ParallelConnector, bitmap.Height / ImageDellimitterConst,
                    bitmap.Width, bitmap.Height / ImageDellimitterConst);
                g.DrawLine(StandartPen, bitmap.Width - ParallelConnector,
                    bitmap.Height / ImageDellimitterConst - 1, bitmap.Width, bitmap.Height / ImageDellimitterConst - 1);
            }
            return bitmap;
        }

        #endregion

        #region Get Size Methods

        /// <summary>
        ///     Вычисляет размер любого компонента эл. цепи.
        /// </summary>
        /// <param name="component">Компонент эл. цепи.</param>
        private static Size GetSize(ISegment component)
        {
            if (component is CircuitBase)
                return GetSize(component as CircuitBase);
            if (component is IElement)
                return GetSize(component as IElement);
            return new Size(EmptyImageSize.Width, EmptyImageSize.Height);
        }

        /// <summary>
        ///     Вычисляет размер элемента эл. цепи.
        /// </summary>
        /// <param name="component">Элемент эл. цепи.</param>
        private static Size GetSize(IElement component)
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
                return GetSize(circuit as SerialCircuit);
            if (circuit is ParallelCircuit)
                return GetSize(circuit as ParallelCircuit);
            return new Size(1, 1);
        }

        /// <summary>
        ///     Вычисляет размер рисунка эл. цепи с последовательным соединением.
        /// </summary>
        /// <param name="circuit">Эл. цепь с последовательным соединением.</param>
        private static Size GetSize(SerialCircuit circuit)
        {
            var size = circuit.Count > 0 ? new Size(0, 0) : new Size(EmptyImageSize.Width, EmptyImageSize.Height);
            foreach (var component in circuit)
                if (component is IElement)
                {
                    size.Height = size.Height < GetSize(component as IElement).Height
                        ? GetSize(component as IElement).Height
                        : size.Height;
                    size.Width = size.Width + GetSize(component as IElement).Width;
                }
                else if (component is SerialCircuit)
                {
                    var scSize = GetSize(component as SerialCircuit);
                    size.Height = size.Height < scSize.Height ? scSize.Height : size.Height;
                    size.Width = size.Width + scSize.Width;
                }
                else if (component is ParallelCircuit)
                {
                    var pcSize = GetSize(component as ParallelCircuit);
                    size.Height = size.Height < pcSize.Height ? pcSize.Height : size.Height;
                    size.Width = size.Width + pcSize.Width;
                }
            return size;
        }

        /// <summary>
        ///     Вычисляет размер рисунка эл. цепи с параллельным соединением.
        /// </summary>
        /// <param name="circuit">Эл. цепь с параллельным соединением.</param>
        private static Size GetSize(ParallelCircuit circuit)
        {
            var size = circuit.Count > 0 ? new Size(0, 0) : new Size(EmptyImageSize.Width, EmptyImageSize.Height);
            foreach (var component in circuit)
                if (component is IElement)
                {
                    size.Height = size.Height + GetSize(component as IElement).Height;
                    size.Width = size.Width < GetSize(component as IElement).Width
                        ? GetSize(component as IElement).Width
                        : size.Width;
                }
                else if (component is SerialCircuit)
                {
                    var scSize = GetSize(component as SerialCircuit);
                    size.Width = size.Width < scSize.Width ? scSize.Width : size.Width;
                    size.Height = size.Height + scSize.Height;
                }
                else if (component is ParallelCircuit)
                {
                    var pcSize = GetSize(component as ParallelCircuit);
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
        /// <param name="element">Элемент эл. цепи.</param>
        private static Bitmap GetElementImage(IElement element)
        {
            var drawer = ElementDrawProcedureSelector(element);

            var bitmap = new Bitmap(GetSize(element).Height, GetSize(element).Width);
            using (var g = Graphics.FromImage(bitmap))
            {
                drawer(g);
            }
            return bitmap;
        }

        /// <summary>
        ///     Выбирает метод рисования элемента эл.цепи.
        /// </summary>
        /// <param name="element">Элемент эл. цепи.</param>
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
        ///     Рисует резистор.
        /// </summary>
        /// <param name="graphics">Поверхность рисования.</param>
        private static void DrawResistor(Graphics graphics)
        {
            graphics.DrawRectangle(StandartPen, new Rectangle(10, 17, 30, 16));

            graphics.DrawLine(StandartPen, 0, 24, 10, 24);
            graphics.DrawLine(StandartPen, 0, 25, 10, 25);
            graphics.DrawLine(StandartPen, 40, 24, ElementSize.Width, 24);
            graphics.DrawLine(StandartPen, 40, 25, ElementSize.Width, 25);
        }

        /// <summary>
        ///     Рисует конденсатор.
        /// </summary>
        /// <param name="graphics">Поверхность рисования.</param>
        private static void DrawCapacitor(Graphics graphics)
        {
            graphics.DrawLine(StandartPen, 20, 17, 20, 32);
            graphics.DrawLine(StandartPen, 29, 17, 29, 32);

            graphics.DrawLine(StandartPen, 0, 24, 20, 24);
            graphics.DrawLine(StandartPen, 0, 25, 20, 25);
            graphics.DrawLine(StandartPen, 29, 24, ElementSize.Width, 24);
            graphics.DrawLine(StandartPen, 29, 25, ElementSize.Width, 25);
        }

        /// <summary>
        ///     Рисует катушку индуктивности.
        /// </summary>
        /// <param name="graphics">Поверхность рисования .</param>
        private static void DrawInductor(Graphics graphics)
        {
            graphics.DrawBezier(StandartPen, 20, 24, 20, 20, 24, 20, 24, 24);
            graphics.DrawBezier(StandartPen, 24, 24, 24, 20, 28, 20, 28, 24);
            graphics.DrawBezier(StandartPen, 28, 24, 28, 20, 32, 20, 32, 24);
            graphics.DrawBezier(StandartPen, 32, 24, 32, 20, 36, 20, 36, 24);
            graphics.DrawBezier(StandartPen, 36, 24, 36, 20, 40, 20, 40, 24);

            graphics.DrawLine(StandartPen, 0, 24, 20, 24);
            graphics.DrawLine(StandartPen, 0, 25, 20, 25);
            graphics.DrawLine(StandartPen, 40, 24, ElementSize.Width, 24);
            graphics.DrawLine(StandartPen, 40, 25, ElementSize.Width, 25);
        }

        #endregion

        #endregion
    }
}