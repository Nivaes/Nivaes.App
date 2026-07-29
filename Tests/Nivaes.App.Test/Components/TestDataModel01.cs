namespace Nivaes.App.Shared.Test
{
    using System;
    using MemoryPack;

    /// <summary>Implement a <see cref="Nivaes.App.DataModel"/> for test.</summary>
    [MemoryPackable]
    [Serializable]
    public partial class TestDataModel01
        : DataModel
    {
        #region TestDataModel01Id
        [MemoryPackInclude()]
        [MemoryPackOrder(1)]
        //[AutoNotify()]
        //[DataMember(Name = "TestDataModel01Id")]
        public Guid TestDataModel01Id { get; set; }
        #endregion

        #region StringValueReadOnly
        /// <summary>Stirng test value.</summary>
        private string mStringValueReadOnly = string.Empty;

        /// <summary>String test value.</summary>
        //[AutoNotify()]
        public string StringValueReadOnly
        {
            get => mStringValueReadOnly;
            set => base.SetProperty(ref mStringValueReadOnly, value);
        }
        #endregion

        #region StringValue
        /// <summary>Stirng test value.</summary>
        private string mStringValue = string.Empty;

        public string StringValue
        {
            get => mStringValue;
            set => base.SetProperty(ref mStringValue, value);
        }
        #endregion

        #region IntValue
        /// <summary>Int test value.</summary>
        private int? mIntValue;

        /// <summary>Int test value.</summary>
        public int? IntValue
        {
            get => mIntValue;
            set => base.SetProperty(ref mIntValue, value);
        }
        #endregion

        #region DoubleValue
        /// <summary>Double test value.</summary>
        private double? mDoubleValue;

        /// <summary>Double test value.</summary>
        public double? DoubleValue
        {
            get => mDoubleValue;
            set => base.SetProperty(ref mDoubleValue, value);
        }
        #endregion

        #region Telephone
        /// <summary>Telephone.</summary>
        private string mTelephone = string.Empty;

        /// <summary>Telephone.</summary>
        public string Telephone
        {
            get => mTelephone;
            set => base.SetProperty(ref mTelephone, value);
        }
        #endregion
    }
}
