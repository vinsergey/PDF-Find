using System;

namespace Model
{
    public abstract class PrinterConfiguration
    {
        #region Properties

        public Guid Id { get; set; } = Guid.NewGuid();

        public string PrinterName { get; set; }

        public bool Duplex { get; set; }

        public PaperFormat PaperFormat { get; set; }

        #endregion
    }
}