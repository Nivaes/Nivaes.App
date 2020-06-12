namespace Nivaes.UnitTest
{
    using System;
    using System.Runtime.Serialization;
    using ProtoBuf;
    using Xunit;

    [Trait("TestType", "Unit")]
    public class CloneModelUnitTest
    {
        #region TestClass
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
            private string mStringValueReadOnly;

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
            private string mStringValue;

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
            private string mTelephone;

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
        #endregion

        [Fact]
        public void CloneModelTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3
            };

            var testDataModel2 = testDataModel.Clone();

            Assert.Equal(testDataModel.TestDataModel01Id, testDataModel2.TestDataModel01Id);
            Assert.Equal(testDataModel.StringValue, testDataModel2.StringValue);
            Assert.Equal(testDataModel.StringValueReadOnly, testDataModel2.StringValueReadOnly);
            Assert.Equal(testDataModel.DoubleValue, testDataModel2.DoubleValue);
            Assert.Equal(testDataModel.IntValue, testDataModel2.IntValue);
        }

        [Fact]
        public void CloneDataContractTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3
            };

            var testDataModel2 = testDataModel.CloneDataContract();

            Assert.Equal(testDataModel.TestDataModel01Id, testDataModel2.TestDataModel01Id);
            Assert.Equal(testDataModel.StringValue, testDataModel2.StringValue);
            Assert.Equal(testDataModel.StringValueReadOnly, testDataModel2.StringValueReadOnly);
            Assert.Equal(testDataModel.DoubleValue, testDataModel2.DoubleValue);
            Assert.Equal(testDataModel.IntValue, testDataModel2.IntValue);
        }

        [Fact]
        public void CloneModelProtoBufTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3
            };

            var testDataModel2 = testDataModel.CloneProtoBuf();

            Assert.Equal(testDataModel.TestDataModel01Id, testDataModel2.TestDataModel01Id);
            Assert.Equal(testDataModel.StringValue, testDataModel2.StringValue);
            Assert.Equal(testDataModel.StringValueReadOnly, testDataModel2.StringValueReadOnly);
            Assert.Equal(testDataModel.DoubleValue, testDataModel2.DoubleValue);
            Assert.Equal(testDataModel.IntValue, testDataModel2.IntValue);
        }
    }
}
