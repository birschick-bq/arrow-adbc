/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.17.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 * </auto-generated>
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace Apache.Hive.Service.Rpc.Thrift
{

  public partial class TColumn : TBase
  {
    private global::Apache.Hive.Service.Rpc.Thrift.TBoolColumn _boolVal;
    private global::Apache.Hive.Service.Rpc.Thrift.TByteColumn _byteVal;
    private global::Apache.Hive.Service.Rpc.Thrift.TI16Column _i16Val;
    private global::Apache.Hive.Service.Rpc.Thrift.TI32Column _i32Val;
    private global::Apache.Hive.Service.Rpc.Thrift.TI64Column _i64Val;
    private global::Apache.Hive.Service.Rpc.Thrift.TDoubleColumn _doubleVal;
    private global::Apache.Hive.Service.Rpc.Thrift.TStringColumn _stringVal;
    private global::Apache.Hive.Service.Rpc.Thrift.TBinaryColumn _binaryVal;

    public global::Apache.Hive.Service.Rpc.Thrift.TBoolColumn BoolVal
    {
      get
      {
        return _boolVal;
      }
      set
      {
        __isset.boolVal = true;
        this._boolVal = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TByteColumn ByteVal
    {
      get
      {
        return _byteVal;
      }
      set
      {
        __isset.byteVal = true;
        this._byteVal = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TI16Column I16Val
    {
      get
      {
        return _i16Val;
      }
      set
      {
        __isset.i16Val = true;
        this._i16Val = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TI32Column I32Val
    {
      get
      {
        return _i32Val;
      }
      set
      {
        __isset.i32Val = true;
        this._i32Val = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TI64Column I64Val
    {
      get
      {
        return _i64Val;
      }
      set
      {
        __isset.i64Val = true;
        this._i64Val = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TDoubleColumn DoubleVal
    {
      get
      {
        return _doubleVal;
      }
      set
      {
        __isset.doubleVal = true;
        this._doubleVal = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TStringColumn StringVal
    {
      get
      {
        return _stringVal;
      }
      set
      {
        __isset.stringVal = true;
        this._stringVal = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TBinaryColumn BinaryVal
    {
      get
      {
        return _binaryVal;
      }
      set
      {
        __isset.binaryVal = true;
        this._binaryVal = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool boolVal;
      public bool byteVal;
      public bool i16Val;
      public bool i32Val;
      public bool i64Val;
      public bool doubleVal;
      public bool stringVal;
      public bool binaryVal;
    }

    public TColumn()
    {
    }

    public TColumn DeepCopy()
    {
      var tmp204 = new TColumn();
      if ((BoolVal != null) && __isset.boolVal)
      {
        tmp204.BoolVal = (global::Apache.Hive.Service.Rpc.Thrift.TBoolColumn)this.BoolVal.DeepCopy();
      }
      tmp204.__isset.boolVal = this.__isset.boolVal;
      if ((ByteVal != null) && __isset.byteVal)
      {
        tmp204.ByteVal = (global::Apache.Hive.Service.Rpc.Thrift.TByteColumn)this.ByteVal.DeepCopy();
      }
      tmp204.__isset.byteVal = this.__isset.byteVal;
      if ((I16Val != null) && __isset.i16Val)
      {
        tmp204.I16Val = (global::Apache.Hive.Service.Rpc.Thrift.TI16Column)this.I16Val.DeepCopy();
      }
      tmp204.__isset.i16Val = this.__isset.i16Val;
      if ((I32Val != null) && __isset.i32Val)
      {
        tmp204.I32Val = (global::Apache.Hive.Service.Rpc.Thrift.TI32Column)this.I32Val.DeepCopy();
      }
      tmp204.__isset.i32Val = this.__isset.i32Val;
      if ((I64Val != null) && __isset.i64Val)
      {
        tmp204.I64Val = (global::Apache.Hive.Service.Rpc.Thrift.TI64Column)this.I64Val.DeepCopy();
      }
      tmp204.__isset.i64Val = this.__isset.i64Val;
      if ((DoubleVal != null) && __isset.doubleVal)
      {
        tmp204.DoubleVal = (global::Apache.Hive.Service.Rpc.Thrift.TDoubleColumn)this.DoubleVal.DeepCopy();
      }
      tmp204.__isset.doubleVal = this.__isset.doubleVal;
      if ((StringVal != null) && __isset.stringVal)
      {
        tmp204.StringVal = (global::Apache.Hive.Service.Rpc.Thrift.TStringColumn)this.StringVal.DeepCopy();
      }
      tmp204.__isset.stringVal = this.__isset.stringVal;
      if ((BinaryVal != null) && __isset.binaryVal)
      {
        tmp204.BinaryVal = (global::Apache.Hive.Service.Rpc.Thrift.TBinaryColumn)this.BinaryVal.DeepCopy();
      }
      tmp204.__isset.binaryVal = this.__isset.binaryVal;
      return tmp204;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.Struct)
              {
                BoolVal = new global::Apache.Hive.Service.Rpc.Thrift.TBoolColumn();
                await BoolVal.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                ByteVal = new global::Apache.Hive.Service.Rpc.Thrift.TByteColumn();
                await ByteVal.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Struct)
              {
                I16Val = new global::Apache.Hive.Service.Rpc.Thrift.TI16Column();
                await I16Val.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.Struct)
              {
                I32Val = new global::Apache.Hive.Service.Rpc.Thrift.TI32Column();
                await I32Val.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.Struct)
              {
                I64Val = new global::Apache.Hive.Service.Rpc.Thrift.TI64Column();
                await I64Val.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.Struct)
              {
                DoubleVal = new global::Apache.Hive.Service.Rpc.Thrift.TDoubleColumn();
                await DoubleVal.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 7:
              if (field.Type == TType.Struct)
              {
                StringVal = new global::Apache.Hive.Service.Rpc.Thrift.TStringColumn();
                await StringVal.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 8:
              if (field.Type == TType.Struct)
              {
                BinaryVal = new global::Apache.Hive.Service.Rpc.Thrift.TBinaryColumn();
                await BinaryVal.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default:
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var tmp205 = new TStruct("TColumn");
        await oprot.WriteStructBeginAsync(tmp205, cancellationToken);
        var tmp206 = new TField();
        if ((BoolVal != null) && __isset.boolVal)
        {
          tmp206.Name = "boolVal";
          tmp206.Type = TType.Struct;
          tmp206.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp206, cancellationToken);
          await BoolVal.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((ByteVal != null) && __isset.byteVal)
        {
          tmp206.Name = "byteVal";
          tmp206.Type = TType.Struct;
          tmp206.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp206, cancellationToken);
          await ByteVal.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((I16Val != null) && __isset.i16Val)
        {
          tmp206.Name = "i16Val";
          tmp206.Type = TType.Struct;
          tmp206.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp206, cancellationToken);
          await I16Val.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((I32Val != null) && __isset.i32Val)
        {
          tmp206.Name = "i32Val";
          tmp206.Type = TType.Struct;
          tmp206.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp206, cancellationToken);
          await I32Val.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((I64Val != null) && __isset.i64Val)
        {
          tmp206.Name = "i64Val";
          tmp206.Type = TType.Struct;
          tmp206.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp206, cancellationToken);
          await I64Val.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((DoubleVal != null) && __isset.doubleVal)
        {
          tmp206.Name = "doubleVal";
          tmp206.Type = TType.Struct;
          tmp206.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp206, cancellationToken);
          await DoubleVal.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((StringVal != null) && __isset.stringVal)
        {
          tmp206.Name = "stringVal";
          tmp206.Type = TType.Struct;
          tmp206.ID = 7;
          await oprot.WriteFieldBeginAsync(tmp206, cancellationToken);
          await StringVal.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((BinaryVal != null) && __isset.binaryVal)
        {
          tmp206.Name = "binaryVal";
          tmp206.Type = TType.Struct;
          tmp206.ID = 8;
          await oprot.WriteFieldBeginAsync(tmp206, cancellationToken);
          await BinaryVal.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      if (!(that is TColumn other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.boolVal == other.__isset.boolVal) && ((!__isset.boolVal) || (global::System.Object.Equals(BoolVal, other.BoolVal))))
        && ((__isset.byteVal == other.__isset.byteVal) && ((!__isset.byteVal) || (global::System.Object.Equals(ByteVal, other.ByteVal))))
        && ((__isset.i16Val == other.__isset.i16Val) && ((!__isset.i16Val) || (global::System.Object.Equals(I16Val, other.I16Val))))
        && ((__isset.i32Val == other.__isset.i32Val) && ((!__isset.i32Val) || (global::System.Object.Equals(I32Val, other.I32Val))))
        && ((__isset.i64Val == other.__isset.i64Val) && ((!__isset.i64Val) || (global::System.Object.Equals(I64Val, other.I64Val))))
        && ((__isset.doubleVal == other.__isset.doubleVal) && ((!__isset.doubleVal) || (global::System.Object.Equals(DoubleVal, other.DoubleVal))))
        && ((__isset.stringVal == other.__isset.stringVal) && ((!__isset.stringVal) || (global::System.Object.Equals(StringVal, other.StringVal))))
        && ((__isset.binaryVal == other.__isset.binaryVal) && ((!__isset.binaryVal) || (global::System.Object.Equals(BinaryVal, other.BinaryVal))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((BoolVal != null) && __isset.boolVal)
        {
          hashcode = (hashcode * 397) + BoolVal.GetHashCode();
        }
        if ((ByteVal != null) && __isset.byteVal)
        {
          hashcode = (hashcode * 397) + ByteVal.GetHashCode();
        }
        if ((I16Val != null) && __isset.i16Val)
        {
          hashcode = (hashcode * 397) + I16Val.GetHashCode();
        }
        if ((I32Val != null) && __isset.i32Val)
        {
          hashcode = (hashcode * 397) + I32Val.GetHashCode();
        }
        if ((I64Val != null) && __isset.i64Val)
        {
          hashcode = (hashcode * 397) + I64Val.GetHashCode();
        }
        if ((DoubleVal != null) && __isset.doubleVal)
        {
          hashcode = (hashcode * 397) + DoubleVal.GetHashCode();
        }
        if ((StringVal != null) && __isset.stringVal)
        {
          hashcode = (hashcode * 397) + StringVal.GetHashCode();
        }
        if ((BinaryVal != null) && __isset.binaryVal)
        {
          hashcode = (hashcode * 397) + BinaryVal.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp207 = new StringBuilder("TColumn(");
      int tmp208 = 0;
      if ((BoolVal != null) && __isset.boolVal)
      {
        if (0 < tmp208++) { tmp207.Append(", "); }
        tmp207.Append("BoolVal: ");
        BoolVal.ToString(tmp207);
      }
      if ((ByteVal != null) && __isset.byteVal)
      {
        if (0 < tmp208++) { tmp207.Append(", "); }
        tmp207.Append("ByteVal: ");
        ByteVal.ToString(tmp207);
      }
      if ((I16Val != null) && __isset.i16Val)
      {
        if (0 < tmp208++) { tmp207.Append(", "); }
        tmp207.Append("I16Val: ");
        I16Val.ToString(tmp207);
      }
      if ((I32Val != null) && __isset.i32Val)
      {
        if (0 < tmp208++) { tmp207.Append(", "); }
        tmp207.Append("I32Val: ");
        I32Val.ToString(tmp207);
      }
      if ((I64Val != null) && __isset.i64Val)
      {
        if (0 < tmp208++) { tmp207.Append(", "); }
        tmp207.Append("I64Val: ");
        I64Val.ToString(tmp207);
      }
      if ((DoubleVal != null) && __isset.doubleVal)
      {
        if (0 < tmp208++) { tmp207.Append(", "); }
        tmp207.Append("DoubleVal: ");
        DoubleVal.ToString(tmp207);
      }
      if ((StringVal != null) && __isset.stringVal)
      {
        if (0 < tmp208++) { tmp207.Append(", "); }
        tmp207.Append("StringVal: ");
        StringVal.ToString(tmp207);
      }
      if ((BinaryVal != null) && __isset.binaryVal)
      {
        if (0 < tmp208++) { tmp207.Append(", "); }
        tmp207.Append("BinaryVal: ");
        BinaryVal.ToString(tmp207);
      }
      tmp207.Append(')');
      return tmp207.ToString();
    }
  }

}