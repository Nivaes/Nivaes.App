namespace Nivaes.Test
{
    using System;
    using ProtoBuf;
    using System.Runtime.Serialization;

    /// <summary>Implement a <see cref="Nivaes.Center.DataModel"/> for test.</summary>
    [ProtoContract(Name = "TestDataModel01", ImplicitFields = ImplicitFields.AllPublic, ImplicitFirstTag = 100)]
    [DataContract(IsReference = false, Name = "TestDataModel01", Namespace = "http://test.crm")]
    public class TestDataModel01
        : DataModel
    {
        #region TestDataModel01Id
        [ProtoMember(1, Name = "TestDataModel01Id")]
        [DataMember(Name = "TestDataModel01Id")]
        public Guid TestDataModel01Id { get; set; }
        #endregion

        #region StringValueReadOnly
        /// <summary>Stirng test value.</summary>
        private string mStringValueReadOnly = string.Empty;

        /// <summary>String test value.</summary>
        [ProtoMember(2, Name = "StringValueReadOnly")]
        [DataMember(Name = "StringValueReadOnly")]
        public string StringValueReadOnly
        {
            get => mStringValueReadOnly;
            set => base.SetProperty(ref mStringValueReadOnly, value);
        }
        #endregion

        #region StringValue
        /// <summary>Stirng test value.</summary>
        private string mStringValue = string.Empty;

        [ProtoMember(3, Name = "StringValue")]
        [DataMember(Name = "StringValue")]
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
        [ProtoMember(4, Name = "IntValue")]
        [DataMember(Name = "IntValue")]
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
        [ProtoMember(5, Name = "DoubleValue")]
        [DataMember(Name = "DoubleValue")]
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
        [ProtoMember(6, Name = "Telephone")]
        [DataMember(Name = "Telephone")]
        public string Telephone
        {
            get => mTelephone;
            set => base.SetProperty(ref mTelephone, value);
        }
        #endregion
    }
}
