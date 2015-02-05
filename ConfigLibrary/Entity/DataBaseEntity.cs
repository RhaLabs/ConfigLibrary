/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 5/13/2014
 * Time: 2:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConfigLibrary.Entity
{
  /// <summary>
  /// Description of DataBaseEntity.
  /// </summary>
  public abstract class DataBaseEntity : EntityInterface
  {
    
    protected string hostName;
    
    protected int port;
    
    protected string socket;
    
    protected string userName;
    
    protected string userPassword;
    
    protected string dataBase;
    
    public DataBaseEntity()
    {
    }
    
    public virtual string ClassName
    {
      get { return "DataBaseEntity"; }
    }
    
    public virtual string HostName 
    {
      get { return hostName; }
      set { hostName = value; }
    }
    
    public virtual int Port
    {
      get { return port; }
      set { port = value; }
    }
    
    public virtual string Socket
    {
      get { return socket; }
      set { socket = value; }
    }
    
    public virtual string UserName
    {
      get { return userName; }
      set { userName = value; }
    }
    
    public virtual string UserPassword
    {
      get { return userPassword; }
      set { userPassword = value; }
    }
    
    public virtual string DataBase
    {
      get { return dataBase; }
      set { dataBase = value; }
    }
  }
}
