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

  public partial class TDBSqlSessionConf : TBase
  {
    private Dictionary<string, string> _confs;
    private List<global::Apache.Hive.Service.Rpc.Thrift.TDBSqlTempView> _tempViews;
    private string _currentDatabase;
    private string _currentCatalog;
    private global::Apache.Hive.Service.Rpc.Thrift.TDBSqlSessionCapabilities _sessionCapabilities;
    private List<global::Apache.Hive.Service.Rpc.Thrift.TExpressionInfo> _expressionsInfos;
    private Dictionary<string, global::Apache.Hive.Service.Rpc.Thrift.TDBSqlConfValue> _internalConfs;

    public Dictionary<string, string> Confs
    {
      get
      {
        return _confs;
      }
      set
      {
        __isset.confs = true;
        this._confs = value;
      }
    }

    public List<global::Apache.Hive.Service.Rpc.Thrift.TDBSqlTempView> TempViews
    {
      get
      {
        return _tempViews;
      }
      set
      {
        __isset.tempViews = true;
        this._tempViews = value;
      }
    }

    public string CurrentDatabase
    {
      get
      {
        return _currentDatabase;
      }
      set
      {
        __isset.currentDatabase = true;
        this._currentDatabase = value;
      }
    }

    public string CurrentCatalog
    {
      get
      {
        return _currentCatalog;
      }
      set
      {
        __isset.currentCatalog = true;
        this._currentCatalog = value;
      }
    }

    public global::Apache.Hive.Service.Rpc.Thrift.TDBSqlSessionCapabilities SessionCapabilities
    {
      get
      {
        return _sessionCapabilities;
      }
      set
      {
        __isset.sessionCapabilities = true;
        this._sessionCapabilities = value;
      }
    }

    public List<global::Apache.Hive.Service.Rpc.Thrift.TExpressionInfo> ExpressionsInfos
    {
      get
      {
        return _expressionsInfos;
      }
      set
      {
        __isset.expressionsInfos = true;
        this._expressionsInfos = value;
      }
    }

    public Dictionary<string, global::Apache.Hive.Service.Rpc.Thrift.TDBSqlConfValue> InternalConfs
    {
      get
      {
        return _internalConfs;
      }
      set
      {
        __isset.internalConfs = true;
        this._internalConfs = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool confs;
      public bool tempViews;
      public bool currentDatabase;
      public bool currentCatalog;
      public bool sessionCapabilities;
      public bool expressionsInfos;
      public bool internalConfs;
    }

    public TDBSqlSessionConf()
    {
    }

    public TDBSqlSessionConf DeepCopy()
    {
      var tmp367 = new TDBSqlSessionConf();
      if ((Confs != null) && __isset.confs)
      {
        tmp367.Confs = this.Confs.DeepCopy();
      }
      tmp367.__isset.confs = this.__isset.confs;
      if ((TempViews != null) && __isset.tempViews)
      {
        tmp367.TempViews = this.TempViews.DeepCopy();
      }
      tmp367.__isset.tempViews = this.__isset.tempViews;
      if ((CurrentDatabase != null) && __isset.currentDatabase)
      {
        tmp367.CurrentDatabase = this.CurrentDatabase;
      }
      tmp367.__isset.currentDatabase = this.__isset.currentDatabase;
      if ((CurrentCatalog != null) && __isset.currentCatalog)
      {
        tmp367.CurrentCatalog = this.CurrentCatalog;
      }
      tmp367.__isset.currentCatalog = this.__isset.currentCatalog;
      if ((SessionCapabilities != null) && __isset.sessionCapabilities)
      {
        tmp367.SessionCapabilities = (global::Apache.Hive.Service.Rpc.Thrift.TDBSqlSessionCapabilities)this.SessionCapabilities.DeepCopy();
      }
      tmp367.__isset.sessionCapabilities = this.__isset.sessionCapabilities;
      if ((ExpressionsInfos != null) && __isset.expressionsInfos)
      {
        tmp367.ExpressionsInfos = this.ExpressionsInfos.DeepCopy();
      }
      tmp367.__isset.expressionsInfos = this.__isset.expressionsInfos;
      if ((InternalConfs != null) && __isset.internalConfs)
      {
        tmp367.InternalConfs = this.InternalConfs.DeepCopy();
      }
      tmp367.__isset.internalConfs = this.__isset.internalConfs;
      return tmp367;
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
              if (field.Type == TType.Map)
              {
                {
                  var _map368 = await iprot.ReadMapBeginAsync(cancellationToken);
                  Confs = new Dictionary<string, string>(_map368.Count);
                  for(int _i369 = 0; _i369 < _map368.Count; ++_i369)
                  {
                    string _key370;
                    string _val371;
                    _key370 = await iprot.ReadStringAsync(cancellationToken);
                    _val371 = await iprot.ReadStringAsync(cancellationToken);
                    Confs[_key370] = _val371;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.List)
              {
                {
                  var _list372 = await iprot.ReadListBeginAsync(cancellationToken);
                  TempViews = new List<global::Apache.Hive.Service.Rpc.Thrift.TDBSqlTempView>(_list372.Count);
                  for(int _i373 = 0; _i373 < _list372.Count; ++_i373)
                  {
                    global::Apache.Hive.Service.Rpc.Thrift.TDBSqlTempView _elem374;
                    _elem374 = new global::Apache.Hive.Service.Rpc.Thrift.TDBSqlTempView();
                    await _elem374.ReadAsync(iprot, cancellationToken);
                    TempViews.Add(_elem374);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.String)
              {
                CurrentDatabase = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.String)
              {
                CurrentCatalog = await iprot.ReadStringAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.Struct)
              {
                SessionCapabilities = new global::Apache.Hive.Service.Rpc.Thrift.TDBSqlSessionCapabilities();
                await SessionCapabilities.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.List)
              {
                {
                  var _list375 = await iprot.ReadListBeginAsync(cancellationToken);
                  ExpressionsInfos = new List<global::Apache.Hive.Service.Rpc.Thrift.TExpressionInfo>(_list375.Count);
                  for(int _i376 = 0; _i376 < _list375.Count; ++_i376)
                  {
                    global::Apache.Hive.Service.Rpc.Thrift.TExpressionInfo _elem377;
                    _elem377 = new global::Apache.Hive.Service.Rpc.Thrift.TExpressionInfo();
                    await _elem377.ReadAsync(iprot, cancellationToken);
                    ExpressionsInfos.Add(_elem377);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 7:
              if (field.Type == TType.Map)
              {
                {
                  var _map378 = await iprot.ReadMapBeginAsync(cancellationToken);
                  InternalConfs = new Dictionary<string, global::Apache.Hive.Service.Rpc.Thrift.TDBSqlConfValue>(_map378.Count);
                  for(int _i379 = 0; _i379 < _map378.Count; ++_i379)
                  {
                    string _key380;
                    global::Apache.Hive.Service.Rpc.Thrift.TDBSqlConfValue _val381;
                    _key380 = await iprot.ReadStringAsync(cancellationToken);
                    _val381 = new global::Apache.Hive.Service.Rpc.Thrift.TDBSqlConfValue();
                    await _val381.ReadAsync(iprot, cancellationToken);
                    InternalConfs[_key380] = _val381;
                  }
                  await iprot.ReadMapEndAsync(cancellationToken);
                }
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
        var tmp382 = new TStruct("TDBSqlSessionConf");
        await oprot.WriteStructBeginAsync(tmp382, cancellationToken);
        var tmp383 = new TField();
        if ((Confs != null) && __isset.confs)
        {
          tmp383.Name = "confs";
          tmp383.Type = TType.Map;
          tmp383.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp383, cancellationToken);
          await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.String, Confs.Count), cancellationToken);
          foreach (string _iter384 in Confs.Keys)
          {
            await oprot.WriteStringAsync(_iter384, cancellationToken);
            await oprot.WriteStringAsync(Confs[_iter384], cancellationToken);
          }
          await oprot.WriteMapEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((TempViews != null) && __isset.tempViews)
        {
          tmp383.Name = "tempViews";
          tmp383.Type = TType.List;
          tmp383.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp383, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, TempViews.Count), cancellationToken);
          foreach (global::Apache.Hive.Service.Rpc.Thrift.TDBSqlTempView _iter385 in TempViews)
          {
            await _iter385.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((CurrentDatabase != null) && __isset.currentDatabase)
        {
          tmp383.Name = "currentDatabase";
          tmp383.Type = TType.String;
          tmp383.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp383, cancellationToken);
          await oprot.WriteStringAsync(CurrentDatabase, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((CurrentCatalog != null) && __isset.currentCatalog)
        {
          tmp383.Name = "currentCatalog";
          tmp383.Type = TType.String;
          tmp383.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp383, cancellationToken);
          await oprot.WriteStringAsync(CurrentCatalog, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((SessionCapabilities != null) && __isset.sessionCapabilities)
        {
          tmp383.Name = "sessionCapabilities";
          tmp383.Type = TType.Struct;
          tmp383.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp383, cancellationToken);
          await SessionCapabilities.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((ExpressionsInfos != null) && __isset.expressionsInfos)
        {
          tmp383.Name = "expressionsInfos";
          tmp383.Type = TType.List;
          tmp383.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp383, cancellationToken);
          await oprot.WriteListBeginAsync(new TList(TType.Struct, ExpressionsInfos.Count), cancellationToken);
          foreach (global::Apache.Hive.Service.Rpc.Thrift.TExpressionInfo _iter386 in ExpressionsInfos)
          {
            await _iter386.WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteListEndAsync(cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if ((InternalConfs != null) && __isset.internalConfs)
        {
          tmp383.Name = "internalConfs";
          tmp383.Type = TType.Map;
          tmp383.ID = 7;
          await oprot.WriteFieldBeginAsync(tmp383, cancellationToken);
          await oprot.WriteMapBeginAsync(new TMap(TType.String, TType.Struct, InternalConfs.Count), cancellationToken);
          foreach (string _iter387 in InternalConfs.Keys)
          {
            await oprot.WriteStringAsync(_iter387, cancellationToken);
            await InternalConfs[_iter387].WriteAsync(oprot, cancellationToken);
          }
          await oprot.WriteMapEndAsync(cancellationToken);
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
      if (!(that is TDBSqlSessionConf other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.confs == other.__isset.confs) && ((!__isset.confs) || (TCollections.Equals(Confs, other.Confs))))
        && ((__isset.tempViews == other.__isset.tempViews) && ((!__isset.tempViews) || (TCollections.Equals(TempViews, other.TempViews))))
        && ((__isset.currentDatabase == other.__isset.currentDatabase) && ((!__isset.currentDatabase) || (global::System.Object.Equals(CurrentDatabase, other.CurrentDatabase))))
        && ((__isset.currentCatalog == other.__isset.currentCatalog) && ((!__isset.currentCatalog) || (global::System.Object.Equals(CurrentCatalog, other.CurrentCatalog))))
        && ((__isset.sessionCapabilities == other.__isset.sessionCapabilities) && ((!__isset.sessionCapabilities) || (global::System.Object.Equals(SessionCapabilities, other.SessionCapabilities))))
        && ((__isset.expressionsInfos == other.__isset.expressionsInfos) && ((!__isset.expressionsInfos) || (TCollections.Equals(ExpressionsInfos, other.ExpressionsInfos))))
        && ((__isset.internalConfs == other.__isset.internalConfs) && ((!__isset.internalConfs) || (TCollections.Equals(InternalConfs, other.InternalConfs))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if ((Confs != null) && __isset.confs)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Confs);
        }
        if ((TempViews != null) && __isset.tempViews)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(TempViews);
        }
        if ((CurrentDatabase != null) && __isset.currentDatabase)
        {
          hashcode = (hashcode * 397) + CurrentDatabase.GetHashCode();
        }
        if ((CurrentCatalog != null) && __isset.currentCatalog)
        {
          hashcode = (hashcode * 397) + CurrentCatalog.GetHashCode();
        }
        if ((SessionCapabilities != null) && __isset.sessionCapabilities)
        {
          hashcode = (hashcode * 397) + SessionCapabilities.GetHashCode();
        }
        if ((ExpressionsInfos != null) && __isset.expressionsInfos)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(ExpressionsInfos);
        }
        if ((InternalConfs != null) && __isset.internalConfs)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(InternalConfs);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp388 = new StringBuilder("TDBSqlSessionConf(");
      int tmp389 = 0;
      if ((Confs != null) && __isset.confs)
      {
        if (0 < tmp389++) { tmp388.Append(", "); }
        tmp388.Append("Confs: ");
        Confs.ToString(tmp388);
      }
      if ((TempViews != null) && __isset.tempViews)
      {
        if (0 < tmp389++) { tmp388.Append(", "); }
        tmp388.Append("TempViews: ");
        TempViews.ToString(tmp388);
      }
      if ((CurrentDatabase != null) && __isset.currentDatabase)
      {
        if (0 < tmp389++) { tmp388.Append(", "); }
        tmp388.Append("CurrentDatabase: ");
        CurrentDatabase.ToString(tmp388);
      }
      if ((CurrentCatalog != null) && __isset.currentCatalog)
      {
        if (0 < tmp389++) { tmp388.Append(", "); }
        tmp388.Append("CurrentCatalog: ");
        CurrentCatalog.ToString(tmp388);
      }
      if ((SessionCapabilities != null) && __isset.sessionCapabilities)
      {
        if (0 < tmp389++) { tmp388.Append(", "); }
        tmp388.Append("SessionCapabilities: ");
        SessionCapabilities.ToString(tmp388);
      }
      if ((ExpressionsInfos != null) && __isset.expressionsInfos)
      {
        if (0 < tmp389++) { tmp388.Append(", "); }
        tmp388.Append("ExpressionsInfos: ");
        ExpressionsInfos.ToString(tmp388);
      }
      if ((InternalConfs != null) && __isset.internalConfs)
      {
        if (0 < tmp389++) { tmp388.Append(", "); }
        tmp388.Append("InternalConfs: ");
        InternalConfs.ToString(tmp388);
      }
      tmp388.Append(')');
      return tmp388.ToString();
    }
  }

}
