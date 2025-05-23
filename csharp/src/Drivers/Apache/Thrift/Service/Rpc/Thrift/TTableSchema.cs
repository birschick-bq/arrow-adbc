/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.21.0)
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


// targeting netstandard 2.x
#if(! NETSTANDARD2_0_OR_GREATER && ! NET6_0_OR_GREATER && ! NET472_OR_GREATER)
#error Unexpected target platform. See 'thrift --help' for details.
#endif

#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE0017  // object init can be simplified
#pragma warning disable IDE0028  // collection init can be simplified
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable CA1822   // empty DeepCopy() methods still non-static
#pragma warning disable CS0618   // silence our own deprecation warnings
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace Apache.Hive.Service.Rpc.Thrift
{

  internal partial class TTableSchema : TBase
  {

    public List<global::Apache.Hive.Service.Rpc.Thrift.TColumnDesc> Columns { get; set; }

    public TTableSchema()
    {
    }

    public TTableSchema(List<global::Apache.Hive.Service.Rpc.Thrift.TColumnDesc> @columns) : this()
    {
      this.Columns = @columns;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        bool isset_columns = false;
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
              if (field.Type == TType.List)
              {
                {
                  var _list63 = await iprot.ReadListBeginAsync(cancellationToken);
                  Columns = new List<global::Apache.Hive.Service.Rpc.Thrift.TColumnDesc>(_list63.Count);
                  for(int _i64 = 0; _i64 < _list63.Count; ++_i64)
                  {
                    global::Apache.Hive.Service.Rpc.Thrift.TColumnDesc _elem65;
                    _elem65 = new global::Apache.Hive.Service.Rpc.Thrift.TColumnDesc();
                    await _elem65.ReadAsync(iprot, cancellationToken);
                    Columns.Add(_elem65);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
                isset_columns = true;
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
        if (!isset_columns)
        {
          throw new TProtocolException(TProtocolException.INVALID_DATA);
        }
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
        var tmp66 = new TStruct("TTableSchema");
        await oprot.WriteStructBeginAsync(tmp66, cancellationToken);
        var tmp67 = new TField();
        if((Columns != null))
        {
          tmp67.Name = "columns";
          tmp67.Type = TType.List;
          tmp67.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp67, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, Columns.Count), cancellationToken);
          foreach (global::Apache.Hive.Service.Rpc.Thrift.TColumnDesc _iter68 in Columns)
          {
            await _iter68.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
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
      if (!(that is TTableSchema other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return TCollections.Equals(Columns, other.Columns);
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if((Columns != null))
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Columns);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp69 = new StringBuilder("TTableSchema(");
      if((Columns != null))
      {
        tmp69.Append(", Columns: ");
        Columns.ToString(tmp69);
      }
      tmp69.Append(')');
      return tmp69.ToString();
    }
  }

}
